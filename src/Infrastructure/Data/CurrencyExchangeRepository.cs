using ApplicationCore.Entities;
using ApplicationCore.Interfaces;

namespace Infrastructure.Data
{
    public class CurrencyExchangeRepository : ICurrencyExchangeRepository
    {
        private readonly CurrencyExchangeContext _dbContext;
        public CurrencyExchangeRepository(CurrencyExchangeContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(CurrencyRate model)
        {
            _dbContext.CurrencyRates.Add(model);
            _dbContext.SaveChanges();
        }

        public IEnumerable<CurrencyRate> Get(string baseCurrency)
        {
            return _dbContext.CurrencyRates
                .Where(c => c.BaseCurrency == baseCurrency)
                .OrderByDescending(c => c.Date)
                .ToList<CurrencyRate>();
        }

        public CurrencyRate GetById(string id)
        {
            return _dbContext.CurrencyRates.FirstOrDefault(c => c.Id == id);
        }

        public void Update(CurrencyRate model)
        {
            _dbContext.CurrencyRates.Update(model);
            _dbContext.SaveChanges();
        }
    }
}
