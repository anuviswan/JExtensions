using BenchmarkDotNet.Running;
using JExtensions.Benchmark.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JExtensions.Benchmark
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<ShuffleTest>();
        }
    }
}
