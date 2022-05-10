namespace ApplicationCore.Exceptions
{
    public class CurrencyNotSupportedException : Exception
    {
        public CurrencyNotSupportedException(string currency) : base($"{currency} currency is not supported")
        {

        }
    }
}
