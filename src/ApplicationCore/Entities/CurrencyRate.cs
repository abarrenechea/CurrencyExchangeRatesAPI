namespace ApplicationCore.Entities;
public class CurrencyRate
{
    public string Id { get; set; }
    public string BaseCurrency { get; set; }
    public string TargetCurrency { get; set; }
    public DateTime Date { get; set; }
    public decimal Rate { get; set; }
}
