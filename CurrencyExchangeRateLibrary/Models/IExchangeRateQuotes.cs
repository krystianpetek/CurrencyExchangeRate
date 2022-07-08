using CurrencyExchangeRateLibrary.Enum;

namespace CurrencyExchangeRateLibrary.Models
{
    public interface IExchangeRateQuotes
    {
        DateTime DateTo { get; set; }
        DateTime DateFrom { get; set; }
        IList<IRateModel> ExchangeRates { get; set; }
        CurrencyEnum CurrencyCode { get; set; }
        string CurrencyName { get; set; }
    }
}