using System.Threading.Tasks;
using WorldBank.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("WorldBank.Test")]
namespace WorldBank.Repository
{
    public class CountriesRepository
    {
        private IJsonData data;
        public CountriesRepository():this(new JsonCountries())
        {

        }
        internal CountriesRepository(IJsonData data)
        {
            this.data = data;
        }
        
        public async Task<Country[]> GetCountries()
        {
            var data = await GetCountriesWithAggregates();
            return data.Where(it => it.region.id != "NA").ToArray();
        }
        public async Task<Country[]> GetCountriesWithAggregates()
        {
            var ret = new List<Country>();            
            var jsonData = await data.JsonData();            
            var jo = JArray.Parse(jsonData);            
            var page = jo[0].ToObject<Pagination>();
            var countries = jo[1].ToObject<Country[]>();
            ret.AddRange(countries);
            var currentPage = 1;            
            while (currentPage < page.pages)
            {
                currentPage++;
                jsonData = await data.JsonData(currentPage);
                jo = JArray.Parse(jsonData);                
                countries = jo[1].ToObject<Country[]>();
                ret.AddRange(countries);


            }
            Debug.Assert(ret.Count == page.total, $"{nameof(ret.Count)} : {ret.Count} should be equal {nameof(page.total)} : {page.total}");
            return ret.ToArray();
        }
    }
}
