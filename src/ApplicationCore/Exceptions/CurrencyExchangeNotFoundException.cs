namespace ApplicationCore.Exceptions
{
    public class CurrencyExchangeNotFoundException : Exception
    {
        public CurrencyExchangeNotFoundException(string id) : base($"Currency Exchange was not found for ID {id}")
        {

        }
    }
}
