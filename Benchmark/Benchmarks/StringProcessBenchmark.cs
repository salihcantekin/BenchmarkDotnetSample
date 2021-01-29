using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Benchmark.Benchmarks
{
    [SimpleJob(BenchmarkDotNet.Jobs.RuntimeMoniker.NetCoreApp50, id: "String Benchmark Job 5.0")]
    [SimpleJob(BenchmarkDotNet.Jobs.RuntimeMoniker.NetCoreApp31, id: "String Benchmark Job 3.1")]
    [MinColumn, MaxColumn, MeanColumn, MedianColumn]
    [MemoryDiagnoser]
    [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
    public class StringProcessBenchmark
    {
        int counter = 10000;

        [Benchmark(Baseline = true)]
        public void Append()
        {
            String emptyStr = "";

            for (int i = 0; i < counter; i++)
            {
                emptyStr += i.ToString();
            }
        }

        [Benchmark()]
        public void AppendWithStringBuilder()
        {
            StringBuilder sb = new StringBuilder(counter);

            for (int i = 0; i < counter; i++)
            {
                sb.Append(i.ToString());
            }
        }

    }
}
