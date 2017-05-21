using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Attributes.Jobs;
using BenchmarkDotNet.Running;
using System;
using WorldBank.Repository;

namespace JustForTest
{
    [ShortRunJob]
    [MemoryDiagnoser]
    //[MediumRunJob]
    //[RJ]
    //[DryJob]
    public class BasicData
    {
        [Benchmark]
        public void GetIndicators()
        {
            Console.WriteLine("indicators");
            var i = new IndicatorRepository();
            var dataIndicator = i.GetIndicators().Result;
            Console.WriteLine(dataIndicator.Length);
            //foreach (var item in dataIndicator)
            //{
            //    Console.WriteLine(item.id + "--" + item.name);
            //}
            

        }
        public void GetCountries()
        {
            Console.WriteLine("countries");
            var c = new CountriesRepository();
            var data = c.GetCountries().Result;
            Console.WriteLine(data.Length);
            foreach (var item in data)
            {
                Console.WriteLine(item.id + "--" + item.name + " - " + "-" + item.incomeLevel.value);
            }
        }
    }
}