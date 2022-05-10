using ApplicationCore.Constants;
using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class CurrencyExchangeContext : DbContext
    {
        public DbSet<CurrencyRate> CurrencyRates { get; set; }

        public CurrencyExchangeContext(DbContextOptions options) : base(options)
        {
            if (CurrencyRates == null || !CurrencyRates.Any())
                SeddExchangeRates();
        }

        public void SeddExchangeRates()
        {
            CurrencyRate currencyRate = new CurrencyRate() 
            {
                Id = Guid.NewGuid().ToString(),
                BaseCurrency = Currencies.GBP,
                Date = new DateTime(2022, 5, 9),
                Rate = 1.2328m,
                TargetCurrency = Currencies.USD,
            };
            CurrencyRates.Add(currencyRate);

            currencyRate = new CurrencyRate()
            {
                Id = Guid.NewGuid().ToString(),
                BaseCurrency = Currencies.GBP,
                Date = new DateTime(2022, 5, 8),
                Rate = 1.2337m,
                TargetCurrency = Currencies.USD
            };
            CurrencyRates.Add(currencyRate);

            currencyRate = new CurrencyRate()
            {
                Id = Guid.NewGuid().ToString(),
                BaseCurrency = Currencies.GBP,
                Date = new DateTime(2022, 5, 7),
                Rate = 1.2341m,
                TargetCurrency = Currencies.USD
            };
            CurrencyRates.Add(currencyRate);

            currencyRate = new CurrencyRate()
            {
                Id = Guid.NewGuid().ToString(),
                BaseCurrency = Currencies.GBP,
                Date = new DateTime(2022, 5, 6),
                Rate = 1.2339m,
                TargetCurrency = Currencies.USD
            };
            CurrencyRates.Add(currencyRate);

            currencyRate = new CurrencyRate()
            {
                Id = Guid.NewGuid().ToString(),
                BaseCurrency = Currencies.GBP,
                Date = new DateTime(2022, 5, 5),
                Rate = 1.2372m,
                TargetCurrency = Currencies.USD
            };
            CurrencyRates.Add(currencyRate);

            currencyRate = new CurrencyRate()
            {
                Id = Guid.NewGuid().ToString(),
                BaseCurrency = Currencies.GBP,
                Date = new DateTime(2022, 5, 4),
                Rate = 1.2610m,
                TargetCurrency = Currencies.USD
            };
            CurrencyRates.Add(currencyRate);

            currencyRate = new CurrencyRate()
            {
                Id = Guid.NewGuid().ToString(),
                BaseCurrency = Currencies.GBP,
                Date = new DateTime(2022, 5, 4),
                Rate = 1.2499m,
                TargetCurrency = Currencies.USD
            };
            CurrencyRates.Add(currencyRate);


            SaveChanges();
        }
    }
}
