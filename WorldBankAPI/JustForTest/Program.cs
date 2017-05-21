using BenchmarkDotNet.Running;
using System;

namespace JustForTest
{


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World Bank!");
            //GetCountries();
            //GetIndicators();
            var summary = BenchmarkRunner.Run<BasicData>();
        }
        
        
    }
}