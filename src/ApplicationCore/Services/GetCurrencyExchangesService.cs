using ApplicationCore.Constants;
using ApplicationCore.Entities;
using ApplicationCore.Exceptions;
using ApplicationCore.Interfaces;

namespace ApplicationCore.Services
{
    public class GetCurrencyExchangesService : IQueryService<string, CurrencyRate>
    {
        private readonly ICurrencyExchangeRepository _currencyExchangeRepository;

        public GetCurrencyExchangesService(ICurrencyExchangeRepository currencyExchangeRepository)
        {
            _currencyExchangeRepository = currencyExchangeRepository;
        }

        public IEnumerable<CurrencyRate> Run(string currency)
        {
            if (!Currencies.All.Contains(currency))
            {
                throw new CurrencyNotFoundException(currency);
            }

            return _currencyExchangeRepository.Get(currency);
        }
    }
}
