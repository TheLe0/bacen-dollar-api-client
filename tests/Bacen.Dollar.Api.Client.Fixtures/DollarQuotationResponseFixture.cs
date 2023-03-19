using Bacen.Dollar.Api.Client.Responses;
using Bogus;
namespace Bacen.Dollar.Api.Client.Fixtures
{
    public class DollarQuotationResponseFixture
    {
        public static DollarQuotationResponse AutoGenerate(int numOfRecords)
        {
            return new Faker<DollarQuotationResponse>()
                .RuleFor(u => u.Context, (f) => f.Random.String(10))
                .RuleFor(u => u.QuotationContent, QuotationResponseContentFixture.AutoGenerate(numOfRecords))
                .Generate();
        }
    }
}
