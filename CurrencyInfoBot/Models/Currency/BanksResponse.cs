using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CurrencyInfoBot.Models.Currency
{
    public class BanksResponse
    {
        public DateTime date { get; set; }
        public string bank { get; set; }
        public int baseCurrency { get; set; }
        public string baseCurrencyLit { get; set; }
        public List<Exchangerate> exchangeRate { get; set; }
        public override string ToString()
        {
            return $"    Currency\n" +
                   $"date - {this.date}\n" +
                   $"bank - {this.bank}\n" +
                   $"baseCurrency - {this.baseCurrency}\n" +
                   $"baseCurrencyLit - {this.baseCurrencyLit}\n" +
                   $"    exchangeRate \n{this.exchangeRate[1]}\n";
        }

        public string GetResponse(string currency)
        {
            string currensyToFind = currency;

            string response = String.Empty;
            if (currensyToFind != String.Empty)
            {
                if (exchangeRate.Any(x => x.currency == currensyToFind.ToUpper()))
                {
                    Exchangerate exchangerateResponse = exchangeRate.Where(x => x.currency == currensyToFind.ToUpper()).First();
                    response = this.date.ToString("MM.dd.yyyy") + "\n" +
                               "1 " + exchangerateResponse.currency + $" = {Math.Round(exchangerateResponse.saleRateNB, 2)} " + exchangerateResponse.baseCurrency;
                }
            }
            return response;
        }
    }
}
