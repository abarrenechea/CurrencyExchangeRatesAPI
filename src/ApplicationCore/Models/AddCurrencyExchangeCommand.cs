namespace ApplicationCore.Models
{
    public class AddCurrencyExchangeCommand
    {
        /// <summary>
        /// Base currency code (ISO 4217)
        /// </summary>
        public string BaseCurrency { get; set; }

        /// <summary>
        /// Target currency code (ISO 4217)
        /// </summary>
        public string TargetCurrency { get; set; }
        public DateTime Date { get; set; }
        public decimal Rate { get; set; }
    }
}
