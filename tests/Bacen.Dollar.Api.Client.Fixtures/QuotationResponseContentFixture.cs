using Bacen.Dollar.Api.Client.Responses;
using Bogus;

namespace Bacen.Dollar.Api.Client.Fixtures
{
    public class QuotationResponseContentFixture
    {
        public static IList<QuotationResponseContent> AutoGenerate(int numOfRecords)
        {
            return new Faker<QuotationResponseContent>()
                .RuleFor(u => u.WithdrawQuote, (f) => f.Random.Decimal(0, 10))
                .RuleFor(u => u.PurchaseQuote, (f) => f.Random.Decimal(0, 10))
                .RuleFor(u => u.QuotationDateTime, (f) => f.Date.Past(1).ToString())
                .Generate(numOfRecords);
        }
    }
}
