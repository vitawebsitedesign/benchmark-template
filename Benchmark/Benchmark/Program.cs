using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System.Collections.Generic;
using System.Linq;

namespace Benchmark
{
    [MemoryDiagnoser]
    public class Benchmark
    {
        private readonly IEnumerable<int> _enumerable;
        private readonly IList<int> _list;

        public Benchmark()
        {
            _enumerable = Enumerable.Range(0, 100);
            _list = new List<int>(_enumerable);
        }

        // Set your own benchmarks below
        [Benchmark]
        public int ElementAtEnumerable() => _enumerable.ElementAt(99);
        [Benchmark]
        public int ElementAtList() => _list.ElementAt(99);
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<Benchmark>();
        }
    }
}
