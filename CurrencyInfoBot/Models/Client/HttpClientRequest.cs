using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CurrencyInfoBot.Models.Client
{
    class HttpClientRequest
    {
        public string BaseUrl = "https://api.privatbank.ua/";
        public string Url = @"https://api.privatbank.ua/p24api/exchange_rates?json&date=";

        public void SetDate(DateTime dateTime)
        {
            Url += dateTime.ToString("d");
        }

        public string GetReleases()
        {
            using (var httpClient = new HttpClient())
            {
                var response = httpClient.GetStringAsync(new Uri(this.Url)).Result;
                return response;
            }
        }
    }
}
