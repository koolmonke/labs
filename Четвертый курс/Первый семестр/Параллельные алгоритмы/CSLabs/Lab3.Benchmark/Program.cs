using System;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Lab3.Benchmark
{
    public class LinearVsBinary
    {
        private const int N = 100_000;
        private const int BatchSize = 1000;


        private int ItemToFind { get; }

        private int[] Data { get; }


        public LinearVsBinary()
        {
            var random = new Random();
            Data = Lab3.Program.GenData(N).OrderBy(x => x).ToArray();
            ItemToFind = Data[random.Next(Data.Length)];
        }

        [Benchmark]
        public int ParallelLinear() => Search.ParallelLinear(Data, ItemToFind, BatchSize);


        [Benchmark]
        public int ParallelBinary() => Search.ParallelBinary(Data, ItemToFind, BatchSize);

        [Benchmark]
        public int SequentialLinear() => Search.Linear(Data, ItemToFind);

        [Benchmark]
        public int SequentialBinary() => Search.Binary(Data, ItemToFind);
    }

    public static class Program
    {
        public static void Main(string[] args)
        {
            var _ = BenchmarkRunner.Run<LinearVsBinary>();
        }
    }
}