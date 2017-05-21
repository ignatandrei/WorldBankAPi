using Polly;
using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace WorldBank.Repository
{
    class JsonIndicators : IJsonData
    {
        public async Task<string> JsonData(int page = 1)
        {
            string req = "indicators?format=json" + ((page != 1) ? $"&page={page}" : "");
            Context c = new Context(req);
            
            var task = Policy
                .Handle<HttpRequestException>()
                .Or<WebException>()
                .WaitAndRetryAsync(3,
                    (t) => TimeSpan.FromSeconds(10),
                    (ex, ts, nr, context) =>
                    {
                        Console.WriteLine($"!!!{context["req"]} {DateTime.Now.ToString("HHmmss")}  retrying {nr} for error ");
                    }
                    )
                    .ExecuteAsync(async (ct) => 
                        {
                            ct["req"] = req;
                            return await DownloadData(req);
                        }
                        ,c);


            return await task;
                
        }

        async Task<string> DownloadData(string req)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://api.worldbank.org/");                
                var response = await client.GetAsync(req);
                response.EnsureSuccessStatusCode();
                var str = await response.Content.ReadAsStringAsync();
                //System.IO.File.WriteAllText("indicators" + page + ".txt", str);
                return str;
            }
        }


    }

}
