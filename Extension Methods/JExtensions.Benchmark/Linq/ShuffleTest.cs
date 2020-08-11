using BenchmarkDotNet.Attributes;
using JExtensions.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JExtensions.Benchmark.Linq
{
    [MemoryDiagnoser]
    public class ShuffleTest
    {
        private IEnumerable<int> _intCollectionSource;
        private IEnumerable<char> _charCollectionSource;
        public ShuffleTest()
        {
            _intCollectionSource = Enumerable.Range(1, 1000).ToList();
            _charCollectionSource = Enumerable.Repeat(1, 1000).Select(x => 'a').ToList();
        }
        [Benchmark]
        public void ShuffleIntCollectionUsingJExtensions()
        {
            var result = _intCollectionSource.Shuffle();
            var materializeList = result.ToList();
        }

        [Benchmark]
        public void ShuffleIntCollectionUsingLinq()
        {
            var random = new Random();
            var result = _intCollectionSource.OrderBy(x => random.Next());
            var materializeList = result.ToList();
        }


        [Benchmark]
        public void ShuffleCharCollectionUsingJExtensions()
        {
            var result = _charCollectionSource.Shuffle();
            var materializeList = result.ToList();
        }

        [Benchmark]
        public void ShuffleCharCollectionUsingLinq()
        {
            var random = new Random();
            var result = _charCollectionSource.OrderBy(x => random.Next());
            var materializeList = result.ToList();
        }

    }
}
