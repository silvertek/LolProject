using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json.Serialization;
using System.IO;

namespace LoLApp.Data
{
    public class API
    {
        public string HttpGet(string api, string param, string key)
        {
            var uri = api + param + "&" + key;
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                try
                {
                    using (Stream stream = response.GetResponseStream())
                    {
                        StreamReader reader = new StreamReader(stream);

                        return reader.ReadToEnd();
                    }
                }
                finally
                {
                    response.Close();
                }


            }
            catch (WebException ex)
            {
                using (var stream = ex.Response.GetResponseStream())
                using (var reader = new StreamReader(stream))
                {
                    Console.WriteLine(reader.ReadToEnd());
                    return null;
                }
            }
        }
    }
}
