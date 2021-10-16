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

        private (int[] array, int index)[] BatchedData { get; }

        private int ItemToFind { get; }

        private int[] Data { get; }


        public LinearVsBinary()
        {
            var random = new Random();
            Data = Lab3.Program.GenData(N);
            ItemToFind = Data[random.Next(Data.Length)];
            BatchedData = Data.OrderBy(x => x)
                .Batch(BatchSize)
                .Select(item => item.ToArray())
                .Select((array, index) => (array, index))
                .ToArray();
        }

        [Benchmark]
        public int ParallelLinear() => BatchedData.AsParallel()
            .Select(item => (IndexInInnerArray: item.array.MyLinearSearch(ItemToFind), ArrayIndex: item.index))
            .Where(item => item.IndexInInnerArray != -1)
            .Select(item => item.IndexInInnerArray + item.ArrayIndex * BatchSize)
            .First();

        [Benchmark]
        public int ParallelBinary() => BatchedData.AsParallel()
            .Select(item => (IndexInInnerArray: item.array.MyBinarySearch(ItemToFind), ArrayIndex: item.index))
            .Where(item => item.IndexInInnerArray != -1)
            .Select(item => item.IndexInInnerArray + item.ArrayIndex * BatchSize)
            .First();

        [Benchmark]
        public int SequentialLinear() => Data.MyLinearSearch(ItemToFind);

        [Benchmark] 
        public int SequentialBinary() => Data.MyBinarySearch(ItemToFind);
    }

    public static class Program
    {
        public static void Main(string[] args)
        {
            var _ = BenchmarkRunner.Run<LinearVsBinary>();
        }
    }
}