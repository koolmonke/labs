using System;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using MoreLinq;

namespace Lab3.Benchmark
{
    public class LinearVsBinary
    {
        private const int N = 100_000_000;
        private const int BatchSize = 100_000;

        private (int[] array, int index)[] Data { get; }

        private int ItemToFind { get; }

        private int[] GenData { get; }


        public LinearVsBinary()
        {
            var random = new Random();
            GenData = Lab3.Program.GenData(N);
            ItemToFind = GenData[random.Next(GenData.Length)];
            Data = GenData.OrderBy(x => x)
                .Batch(BatchSize)
                .Select(item => item.ToArray())
                .Select((array, index) => (array, index))
                .ToArray();
        }

        [Benchmark]
        public int ParallelLinear() => Data.AsParallel()
            .Select(item => (IndexInInnerArray: item.array.MyLinearSearch(ItemToFind), ArrayIndex: item.index))
            .Where(item => item.IndexInInnerArray != -1)
            .Select(item => item.IndexInInnerArray + item.ArrayIndex * BatchSize)
            .First();

        [Benchmark]
        public int ParallelBinary() => Data.AsParallel()
            .Select(item => (IndexInInnerArray: item.array.MyBinarySearch(ItemToFind), ArrayIndex: item.index))
            .Where(item => item.IndexInInnerArray != -1)
            .Select(item => item.IndexInInnerArray + item.ArrayIndex * BatchSize)
            .First();

        [Benchmark]
        public int SequentialLinear() => GenData.MyLinearSearch(ItemToFind);

        [Benchmark] 
        public int SequentialBinary() => GenData.MyBinarySearch(ItemToFind);
    }

    public static class Program
    {
        public static void Main(string[] args)
        {
            var _ = BenchmarkRunner.Run<LinearVsBinary>();
        }
    }
}