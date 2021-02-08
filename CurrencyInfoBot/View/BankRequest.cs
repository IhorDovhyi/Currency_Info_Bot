using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CurrencyInfoBot.Models.Client;
using CurrencyInfoBot.Models.Currency;
using Newtonsoft.Json;

namespace CurrencyInfoBot.View
{
    public class BankRequest
    {
        HttpClientRequest httpClientRequest;
        BanksResponse bunkReleases;
        DateTime dateTime;

        public BankRequest(DateTime dateTime)
        {
            httpClientRequest = new HttpClientRequest();
            this.dateTime = dateTime;
            httpClientRequest.SetDate(this.dateTime);
        }

        public BanksResponse GetBanksResponse()
        {
            this.bunkReleases = JsonConvert.DeserializeObject<BanksResponse>(GetReleases(httpClientRequest));
            return this.bunkReleases;
        }

        private string GetReleases(HttpClientRequest requestHandler)
        {
            return requestHandler.GetReleases();
        }
    }
}
