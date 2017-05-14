using WorldBank.Repository;
using Xunit;
/// <summary>
/// http://haacked.com/archive/2012/01/02/structuring-unit-tests.aspx/
/// </summary>
namespace WorldBank.Test
{
    public class GetIndicatorsFacts
    {
        [Fact]
        public void GetAndInterpretData()
        {
            //uses [assembly: InternalsVisibleTo("WorldBank.Test")]
            var c = new IndicatorRepository(new JsonFromHard("indicators"));
            var data = c.GetIndicators().Result;
            Assert.Equal(16174, data.Length);
        }
    }
}
