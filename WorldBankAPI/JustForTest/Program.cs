using System;
using WorldBank.Repository;

namespace JustForTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World Bank!");
            //GetCountries();
            Console.WriteLine("indicators");
            var i = new IndicatorRepository();
            var dataIndicator = i.GetIndicators().Result;
            Console.WriteLine(dataIndicator.Length);
            foreach (var item in dataIndicator)
            {
                Console.WriteLine(item.id + "--" + item.name );
            }
        }
        static void GetCountries()
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