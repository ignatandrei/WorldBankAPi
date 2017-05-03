using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace WorldBank.Repository
{
    class JsonCountries : IJsonData
    {
        public async Task<string> JsonData(int page=1)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://api.worldbank.org/");
                string req = "countries?format=json" +((page != 1) ? $"&page={page}" : "");
                var response = await client.GetAsync(req);
                response.EnsureSuccessStatusCode();
                var str= await response.Content.ReadAsStringAsync();
                //System.IO.File.WriteAllText("countries" + page + ".txt", str);
                return str;
            }
        }

        
    }

}
