using System;
using System.IO;
using System.Threading.Tasks;
using WorldBank.Repository;
/// <summary>
/// http://haacked.com/archive/2012/01/02/structuring-unit-tests.aspx/
/// </summary>
namespace WorldBank.Test
{
    class JsonFromHard : IJsonData
    {
        public string NameFile { get; private set; }
        public JsonFromHard(string nameFile)
        {
            NameFile = nameFile;
        }
        /// <summary>
        /// generating data with 
        ///System.IO.File.WriteAllText("countries" + page + ".txt", str);
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public Task<string> JsonData(int page = 1) {
            return Task.FromResult( File.ReadAllText($@"{NameFile}\{NameFile}{page}.txt"));
        }

    }
}
