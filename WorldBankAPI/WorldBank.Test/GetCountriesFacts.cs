﻿using WorldBank.Repository;
using Xunit;
/// <summary>
/// http://haacked.com/archive/2012/01/02/structuring-unit-tests.aspx/
/// </summary>
namespace WorldBank.Test
{
    public class GetCountriesFacts
    {
        [Fact]
        public void GetAndInterpretData()
        {
            //uses [assembly: InternalsVisibleTo("WorldBank.Test")]
            var c = new CountriesRepository(new JsonFromHard("Countries"));
            var data = c.GetCountries().Result;
            Assert.Equal(218, data.Length);
        }
    }
}
