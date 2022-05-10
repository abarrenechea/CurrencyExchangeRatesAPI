using ApplicationCore.Constants;
using ApplicationCore.Entities;
using ApplicationCore.Exceptions;
using ApplicationCore.Interfaces;
using ApplicationCore.Models;

namespace ApplicationCore.Services
{
    public class AddCurrencyExchangeService : ICommandService<AddCurrencyExchangeCommand>
    {
        private readonly ICurrencyExchangeRepository _currencyExchangeRepository;

        public AddCurrencyExchangeService(ICurrencyExchangeRepository currencyExchangeRepository)
        {
            _currencyExchangeRepository = currencyExchangeRepository;
        }

        public void Execute(AddCurrencyExchangeCommand command)
        {
            if (!Currencies.All.Contains(command.BaseCurrency))
            {
                throw new CurrencyNotSupportedException(command.BaseCurrency);
            }

            if (!Currencies.All.Contains(command.TargetCurrency))
            {
                throw new CurrencyNotSupportedException(command.TargetCurrency);
            }

            if (command.Rate <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(command.Rate));
            }

            var currencyExchange = new CurrencyRate()
            {
                BaseCurrency = command.BaseCurrency,
                Date = command.Date,
                Rate = command.Rate,
                TargetCurrency = command.TargetCurrency,
                Id = Guid.NewGuid().ToString(),
            };
            
            _currencyExchangeRepository.Add(currencyExchange);
        }
    }
}
