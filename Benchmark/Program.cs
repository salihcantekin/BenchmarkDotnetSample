using Benchmark.Benchmarks;
using BenchmarkDotNet.Running;
using System;

namespace Benchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<StringProcessBenchmark>();

            Console.ReadLine();
        }
    }
}
