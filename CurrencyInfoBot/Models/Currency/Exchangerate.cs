using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CurrencyInfoBot.Models.Currency
{
    public class Exchangerate
    {
        public string baseCurrency { get; set; }
        public string currency { get; set; }
        public float saleRateNB { get; set; }
        public float purchaseRateNB { get; set; }
        public override string ToString()
        {
            return $"baseCurrency - {this.baseCurrency}\n" +
                   $"currency - {this.currency}\n" +
                   $"saleRateNB - {Math.Round(this.saleRateNB, 2)}\n" +
                   $"purchaseRateNB - {Math.Round(this.purchaseRateNB, 2)}\n";
        }
    }
}
