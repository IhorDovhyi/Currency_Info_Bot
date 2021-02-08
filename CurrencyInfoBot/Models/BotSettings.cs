using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CurrencyInfoBot.Models
{
    public class BotSettings
    {
        public string fileName = @"config.json";

        public string json { get; set; } 
        public string Url { get; set; } 
        public string Name { get; set; }
        public string Token { get; set; } 

        public BotSettings()
        {
            Deserialize();
        }

        public void Deserialize()
        {
            json = File.ReadAllText(fileName);

            var dic = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);

            this.Url = dic["Url"];
            this.Name = dic["Name"];
            this.Token = dic["Token"];
        }
    }
}
