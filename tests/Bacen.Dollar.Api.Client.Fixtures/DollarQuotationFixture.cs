using Bacen.Dollar.Api.Client.Models;
using Bogus;

namespace Bacen.Dollar.Api.Client.Fixtures
{
    public static class DollarQuotationFixture
    {
        public static DollarQuotation AutoGenerate()
        {
            return new Faker<DollarQuotation>()
                .RuleFor(u => u.WithdrawQuote, (f) => f.Random.Decimal(0, 10))
                .RuleFor(u => u.PurchaseQuote, (f) => f.Random.Decimal(0, 10))
                .RuleFor(u => u.QuoteDate, (f) => f.Date.Past(1))
                .Generate();
        }

        public static IList<DollarQuotation> AutoGenerate(int numOfRecords)
        {
            return new Faker<DollarQuotation>()
                .RuleFor(u => u.WithdrawQuote, (f) => f.Random.Decimal(0, 10))
                .RuleFor(u => u.PurchaseQuote, (f) => f.Random.Decimal(0, 10))
                .RuleFor(u => u.QuoteDate, (f) => f.Date.Past(1))
                .Generate(numOfRecords);
        }
    }
}