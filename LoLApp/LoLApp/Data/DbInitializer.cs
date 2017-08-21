using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoLApp.Data;
using Newtonsoft.Json;
using LoLApp.Models;

namespace LoLApp.Data
{
    public class DbInitializer
    {
        public static void Initialize(LoLContext context)
        {
            var key = "api_key=RGAPI-e79e25a4-0ce3-4411-8d01-5b64266bd7f9";
            var url = "https://na1.api.riotgames.com/lol/static-data/v3/champions?";
            var param = "locale=en_US&dataById=false";

            context.Database.EnsureCreated();

            if (context.Champions.Any())
            {
                return;
            }

            var apiCall = new API();

            string champData = apiCall.HttpGet(url, param, key);

            if (!String.IsNullOrWhiteSpace(champData))
            {
                var jArray = JsonConvert.DeserializeObject<RootChampionDTO>(champData);

                foreach (KeyValuePair<string, Champion> champ in jArray.Data)

                {
                    context.Champions.Add(champ.Value);
                }

                context.SaveChanges();
            }
        }
    }
}
