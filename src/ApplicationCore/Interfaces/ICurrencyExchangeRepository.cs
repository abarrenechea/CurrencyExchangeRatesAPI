using ApplicationCore.Entities;

namespace ApplicationCore.Interfaces
{
    public interface ICurrencyExchangeRepository
    {
        void Add(CurrencyRate model);

        void Update(CurrencyRate model);

        IEnumerable<CurrencyRate> Get(string baseCurrency);

        CurrencyRate GetById(string id);
    }
}
