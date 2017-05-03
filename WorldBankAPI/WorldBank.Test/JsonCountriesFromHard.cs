using System;
using System.IO;
using System.Threading.Tasks;
using WorldBank.Repository;
/// <summary>
/// http://haacked.com/archive/2012/01/02/structuring-unit-tests.aspx/
/// </summary>
namespace WorldBank.Test
{
    class JsonCountriesFromHard : IJsonData
    {

        /// <summary>
        /// generating data with 
        ///System.IO.File.WriteAllText("countries" + page + ".txt", str);
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public Task<string> JsonData(int page = 1) {
            return Task.FromResult( File.ReadAllText($@"Countries\countries{page}.txt"));
        }

    }
}
