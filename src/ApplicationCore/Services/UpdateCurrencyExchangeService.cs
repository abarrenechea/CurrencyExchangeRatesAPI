using ApplicationCore.Exceptions;
using ApplicationCore.Interfaces;
using ApplicationCore.Models;

namespace ApplicationCore.Services
{
    public class UpdateCurrencyExchangeService : ICommandService<UpdateCurrencyExchangeCommand>
    {
        private readonly ICurrencyExchangeRepository _currencyExchangeRepository;

        public UpdateCurrencyExchangeService(ICurrencyExchangeRepository currencyExchangeRepository)
        {
            _currencyExchangeRepository = currencyExchangeRepository;
        }

        public void Execute(UpdateCurrencyExchangeCommand command)
        {
            if (command.Rate <= 0)
            {
                throw new ArgumentOutOfRangeException("Rate mus be greater then 0.");
            }

            var currencyExchange = _currencyExchangeRepository.GetById(command.Id);

            if (currencyExchange == null)
            {
                throw new CurrencyExchangeNotFoundException(command.Id);
            }

            currencyExchange.Rate = command.Rate;
            _currencyExchangeRepository.Update(currencyExchange);
        }
    }
}
