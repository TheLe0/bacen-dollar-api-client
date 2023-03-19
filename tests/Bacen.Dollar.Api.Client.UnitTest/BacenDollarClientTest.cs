using Bacen.Dollar.Api.Client.Common;
using Bacen.Dollar.Api.Client.Fixtures;
using Bacen.Dollar.Api.Client.Responses;

namespace Bacen.Dollar.Api.Client.UnitTest
{
    public class BacenDollarClientTest
    {
        private readonly IBacenDollarClient _client;
        private readonly Mock<IBacenDollarHttpClient> _mockHttpClient;

        public BacenDollarClientTest()
        {
            _mockHttpClient = new Mock<IBacenDollarHttpClient>();
            _client = new BacenDollarClient(_mockHttpClient.Object);
        }

        [Fact]
        public async void DailyDollarQuotationAsync_Success()
        {
            _mockHttpClient.Setup(_ =>
                _.GetAsync<DollarQuotationResponse>(It.IsAny<string>()))
                .ReturnsAsync(DollarQuotationResponseFixture.AutoGenerate(1));

            var dollarQuotation = await _client.DailyDollarQuotationAsync(DateTime.Now);

            Assert.NotNull(dollarQuotation);
            Assert.True(dollarQuotation.PurchaseQuote > 0);
            Assert.True(dollarQuotation.WithdrawQuote > 0);
            Assert.NotEqual(DateTime.MinValue, dollarQuotation.QuoteDate);
        }

        [Fact]
        public async void DailyDollarQuotationAsync_Fail_NullResponse()
        {
            _mockHttpClient.Setup(_ =>
                _.GetAsync<DollarQuotationResponse>(It.IsAny<string>()))
                .ReturnsAsync((DollarQuotationResponse) null);

            var dollarQuotation = await _client.DailyDollarQuotationAsync(DateTime.Now);

            Assert.Null(dollarQuotation);
        }

        [Fact]
        public async void DailyDollarQuotationAsync_Fail_NullInsideResponse()
        {
            var response = new DollarQuotationResponse
            {
                Context = null,
                QuotationContent = null
            };

            _mockHttpClient.Setup(_ =>
                _.GetAsync<DollarQuotationResponse>(It.IsAny<string>()))
                .ReturnsAsync(response);

            var dollarQuotation = await _client.DailyDollarQuotationAsync(DateTime.Now);

            Assert.Null(dollarQuotation);
        }

        [InlineData(10)]
        [InlineData(7)]
        [InlineData(1)]
        [Theory]
        public async void PeriodicDollarQuotationAsync_Success(int numOfRecords)
        {
            _mockHttpClient.Setup(_ =>
                _.GetAsync<DollarQuotationResponse>(It.IsAny<string>()))
                .ReturnsAsync(DollarQuotationResponseFixture.AutoGenerate(numOfRecords));

            var dollarQuotation = await _client.PeriodicDollarQuotationAsync(
                DateTime.Now.AddDays(-7),
                DateTime.Now);

            Assert.NotNull(dollarQuotation);
            Assert.Equal(numOfRecords, dollarQuotation.Count);
        }

        [Fact]
        public async void PeriodicDollarQuotationAsync_Fail_NullResponse()
        {
            _mockHttpClient.Setup(_ =>
                _.GetAsync<DollarQuotationResponse>(It.IsAny<string>()))
                .ReturnsAsync((DollarQuotationResponse)null);

            var dollarQuotation = await _client.PeriodicDollarQuotationAsync(
                DateTime.Now.AddDays(-7),
                DateTime.Now);

            Assert.Null(dollarQuotation);
        }

        [Fact]
        public async void PeriodicDollarQuotationAsync_Fail_NullInsideResponse()
        {
            var response = new DollarQuotationResponse
            {
                Context = null,
                QuotationContent = null
            };

            _mockHttpClient.Setup(_ =>
                _.GetAsync<DollarQuotationResponse>(It.IsAny<string>()))
                .ReturnsAsync(response);
            
            var dollarQuotation = await _client.PeriodicDollarQuotationAsync(
                DateTime.Now.AddDays(-7),
                DateTime.Now);

            Assert.Null(dollarQuotation);
        }
    }
}
