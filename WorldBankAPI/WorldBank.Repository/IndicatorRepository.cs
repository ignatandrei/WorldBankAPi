using Newtonsoft.Json.Linq;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using WorldBank.Models;

namespace WorldBank.Repository
{
    public class IndicatorRepository
    {
        private IJsonData data;
        public IndicatorRepository():this(new JsonIndicators())
        {

        }
        internal IndicatorRepository(IJsonData data)
        {
            this.data = data;
        }

        public async Task<Indicator[]> GetIndicators()
        {
            //var ret = new List<Indicator>();
            //var jsonData = await data.JsonData();
            //var jo = JArray.Parse(jsonData);
            //var page = jo[0].ToObject<Pagination>();
            //var array = jo[1].ToObject<Indicator[]>();
            //ret.AddRange(array);
            //var currentPage = 1;
            //while (currentPage < page.pages)
            //{
            //    currentPage++;
            //    jsonData = await data.JsonData(currentPage);
            //    jo = JArray.Parse(jsonData);
            //    array = jo[1].ToObject<Indicator[]>();
            //    ret.AddRange(array);

            //}
            //Debug.Assert(ret.Count == page.total, $"{nameof(ret.Count)} : {ret.Count} should be equal {nameof(page.total)} : {page.total}");
            //return ret.ToArray();



            var jsonData = await data.JsonData();
            var jo = JArray.Parse(jsonData);
            var page = jo[0].ToObject<Pagination>();
            var array = jo[1].ToObject<Indicator[]>();
            var ret = new ConcurrentBag<Indicator>(array);

            var currentPage = 1;
            var downloads = new List<Task>();
            while (currentPage < page.pages)
            {
                currentPage++;
                var itemPage = currentPage;
                var task = data.JsonData(itemPage)
                    .ContinueWith(it =>
                    {

                        var data = JArray.Parse(it.Result);
                        var pageNr = data[0].ToObject<Pagination>();
                        var indicators = data[1].ToObject<Indicator[]>();
                        //Console.WriteLine($"reading {pageNr.page} with {item.Length}");
                        foreach (var item in indicators)
                        {
                            ret.Add(item);
                        }

                    }
                );

                downloads.Add(task);
            }
            await Task.WhenAll(downloads);
            //Console.WriteLine($"total records {ret.Count}");
            Debug.Assert(ret.Count == page.total, $"{nameof(ret.Count)} : {ret.Count} should be equal {nameof(page.total)} : {page.total}");
            return ret.ToArray();

        }
    }
}
