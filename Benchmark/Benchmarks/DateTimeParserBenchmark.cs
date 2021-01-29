using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using System;
using System.Collections.Generic;
using System.Text;

namespace Benchmark.Benchmarks
{
    [SimpleJob(BenchmarkDotNet.Jobs.RuntimeMoniker.NetCoreApp50, id: "DateTime Benchmark Job")]
    [MinColumn, MaxColumn, MeanColumn, MedianColumn]
    [MemoryDiagnoser]
    [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
    public class DateTimeParserBenchmark
    {
        private string _dateTime;

        [GlobalSetup]
        public void Setup()
        {
            _dateTime = "2021-01-21T12:00:00";
        }

        [Benchmark(Baseline = true)]
        public int GetYearFromDateTime()
        {
            var dateTime = DateTime.Parse(_dateTime);
            return dateTime.Year;
        }

        [Benchmark()]
        public int GetYearFromSplit()
        {
            var splitArr = _dateTime.Split('-');
            return int.Parse(splitArr[0]);
        }

        [Benchmark()]
        public int GetYearFromSubStr()
        {
            var index = _dateTime.IndexOf('-');
            return int.Parse(_dateTime.Substring(0, index));
        }

        [Benchmark()]
        public int GetYearFromWithSpan()
        {
            ReadOnlySpan<char> span = _dateTime;
            var index = _dateTime.IndexOf('-');
            return int.Parse(span.Slice(0, index));
        }

        [Benchmark()]
        public int GetYearFromWithSpanWithManuelConversion()
        {
            ReadOnlySpan<char> span = _dateTime;
            var index = _dateTime.IndexOf('-');
            var yearAsSpan = span.Slice(0, index);

            var temp = 0;

            for (int i = 0; i < yearAsSpan.Length; i++)
            {
                temp *= 10 + (yearAsSpan[i] - '0');
            }

            return temp;
        }
    }
}
