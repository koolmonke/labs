using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Lab3.Benchmark
{
    public class LinearVsBinary
    {
        private const int N = 100_000_000;
        private const int BatchSize = 100_000;

        private int ItemToFind { get; }

        private int[] Data { get; }


        public LinearVsBinary()
        {
            var random = new Random();
            Data = Lab3.Program.GenData(N);
            ItemToFind = Data[random.Next(Data.Length)];
        }

        [Benchmark]
        public int ParallelLinear() => Search.ParallelLinearSearch(Data, ItemToFind, BatchSize);

        [Benchmark]
        public int ParallelBinary() => Search.ParallelBinarySearch(Data, ItemToFind, BatchSize);

        [Benchmark]
        public int SequentialLinear() => Search.LinearSearch(Data, ItemToFind);

        [Benchmark]
        public int SequentialBinary() => Search.BinarySearch(Data, ItemToFind);
    }

    public static class Program
    {
        public static void Main(string[] args)
        {
            var _ = BenchmarkRunner.Run<LinearVsBinary>();
        }
    }
}