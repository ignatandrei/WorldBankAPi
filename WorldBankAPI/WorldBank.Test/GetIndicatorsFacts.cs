using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Attributes.Jobs;
using BenchmarkDotNet.Running;
using WorldBank.Repository;
using Xunit;
using System.Linq;
using System.IO;
using System.Diagnostics;
using System.Threading.Tasks;
using System;
/// <summary>
/// http://haacked.com/archive/2012/01/02/structuring-unit-tests.aspx/
/// </summary>
namespace WorldBank.Test
{
    [ShortRunJob]    
    [MemoryDiagnoser]
    //[MediumRunJob]
    //[RJ]
    //[DryJob]
    public class GetIndicatorsFacts
    {
        

        [Fact]
        [Benchmark]        
        public async Task GetAndInterpretData()
        {
            //uses [assembly: InternalsVisibleTo("WorldBank.Test")]
            var c = new IndicatorRepository(new JsonFromHard("indicators"));
            var data = await c.GetIndicators();
            //Console.WriteLine($"total {data.Length}");
            Assert.Equal(16174, data.Length);
        }
        [Fact]
        public void BenchMark()
        {
            var summary = BenchmarkRunner.Run(this.GetType());
            //Process.Start(summary.ResultsDirectoryPath);
        }
    }
}
