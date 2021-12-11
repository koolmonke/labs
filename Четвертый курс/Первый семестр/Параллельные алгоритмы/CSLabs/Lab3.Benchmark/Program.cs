using System;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Lab3.Benchmark
{
    public class LinearVsBinary
    {
        public int N = 10_000_000;

        private int ItemToFind { get; }

        private int[] Data { get; }

        public int[] SortedData { get; }

        public LinearVsBinary()
        {
            var random = new Random();
            Data = Lab3.Program.GenData(N);
            ItemToFind = Data[random.Next(Data.Length)];
            SortedData = Data.OrderBy(id => id).ToArray();
        }

        public static IEnumerable<object[]> BatchSizes()
        {
            yield return new object[] {1000};
            yield return new object[] {10_000};
            yield return new object[] {100_000};
            yield return new object[] {1_000_000};
        }

        [Benchmark]
        [ArgumentsSource(nameof(BatchSizes))]
        public int ParallelLinear(int batchSize) => Search.ParallelLinear(Data, ItemToFind, batchSize);
        
        
        [Benchmark]
        [ArgumentsSource(nameof(BatchSizes))]
        public int ParallelBinary(int batchSize) => Search.ParallelBinaryUnsorted(Data, ItemToFind, batchSize);

        [Benchmark]
        [ArgumentsSource(nameof(BatchSizes))]
        public int ParallelBinaryWithoutSort(int batchSize) =>
            Search.ParallelBinary(SortedData, ItemToFind, batchSize);

        [Benchmark]
        public int SequentialBinary() => Search.Binary(Data, ItemToFind);
        
        [Benchmark]
        public int SequentialLinear() => Search.Linear(Data, ItemToFind);
    }

    public static class Program
    {
        public static void Main()
        {
            var _ = BenchmarkRunner.Run<LinearVsBinary>();
        }
    }
}