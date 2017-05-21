using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Attributes.Jobs;
using BenchmarkDotNet.Running;
using System;
using WorldBank.Models;
using WorldBank.Repository;

namespace JustForTest
{
    [SimpleJob(launchCount: 1, warmupCount: 1,invocationCount:3,targetCount: 2, id: "QuickJob")]
    //[ShortRunJob]
    [MemoryDiagnoser]
    //[MediumRunJob]
    //[RJ]
    //[JobConfigBase]
    //[DryJob]
    public class BasicData
    {
        [Benchmark]
        public Indicator[] GetIndicators()
        {
            Console.WriteLine("indicators");
            var i = new IndicatorRepository();
            var dataIndicator = i.GetIndicators().Result;
            Console.WriteLine(dataIndicator.Length);
            //foreach (var item in dataIndicator)
            //{
            //    Console.WriteLine(item.id + "--" + item.name);
            //}
            return dataIndicator;
            

        }
        public Country[] GetCountries()
        {
            Console.WriteLine("countries");
            var c = new CountriesRepository();
            var data = c.GetCountries().Result;
            Console.WriteLine(data.Length);
            //foreach (var item in data)
            //{
            //    Console.WriteLine(item.id + "--" + item.name + " - " + "-" + item.incomeLevel.value);
            //}
            return data;
        }
    }
}