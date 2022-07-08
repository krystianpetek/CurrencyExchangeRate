using CurrencyExchangeRateLibrary;
using CurrencyExchangeRateLibrary.Enum;

namespace CurrencyExchangeRateConsole
{
    internal partial class Program
    {
        public async static Task Main(string[] args)
        {
            CurrencyExchangeRateLib currencyRate = new CurrencyExchangeRateLib();

            if (args.Length != 3)
                return;

            string currency = args[0];
            string dataFrom = args[1];
            string dataTo = args[2];

            if (!IsValid(currency, dataFrom, dataTo, out CurrencyEnum currencyValid))
                return;

            Console.WriteLine($"Date range: {dataFrom} - {dataTo}\nCurrency: {currencyValid}\n\n" +
                await currencyRate.GetXMLDocument(currencyValid, dataFrom, dataTo)); ;

        }

        public static bool IsValid(
            string currency,
            string dateFrom,
            string dateTo,
            out CurrencyEnum currencyValid)
        {
            if (!Enum.TryParse<CurrencyEnum>(currency, out currencyValid))
                return false;

            if (!DateTime.TryParse(dateFrom, out DateTime dateFromValid))
                return false;

            if (!DateTime.TryParse(dateTo, out DateTime dateToValid))
                return false;

            if (dateFromValid.Date > DateTime.Now.Date || dateFromValid.Date < DateTime.Parse("2002-01-01").Date)
                return false;

            if (dateToValid.Date > DateTime.Now.Date || dateToValid.Date < DateTime.Parse("2002-01-01").Date)
                return false;

            if (dateFromValid.Date > dateToValid.Date)
                return false;

            return true;
        }
    }
}
