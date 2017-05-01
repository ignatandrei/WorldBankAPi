using System;
using WorldBank.Repository;

namespace JustForTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World Bank!");
            var c = new CountriesRepository();
            var data = c.GetCountries().Result;
            Console.WriteLine(data.Length);
            foreach(var item in data)
            {                
                Console.WriteLine(item.id + "--" + item.name + " - " + item.capitalCity);
            }
        }
    }
}