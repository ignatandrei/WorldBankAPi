using BenchmarkDotNet.Attributes.Jobs;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;
using System;

namespace JustForTest
{


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World Bank!");
            //var b = new BasicData();
            //var indics = b.GetIndicators();
            ////var country = b.GetCountries();
            //foreach(var i in indics)
            //{
            //    Console.WriteLine(i.name);
            //}

            var summary = BenchmarkRunner.Run<BasicData>();
        }
                
    }
   

}