namespace CurrencyExchangeRateLibrary.Models
{
    public interface IBuySell<T>
    {
        T Buy { get; set; }
        T Sell { get; set; }
    }
}
