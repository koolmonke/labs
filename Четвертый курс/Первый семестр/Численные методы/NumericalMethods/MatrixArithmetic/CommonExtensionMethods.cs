﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace MatrixArithmetic
{
    public static class CommonExtensionMethods
    {
        public static T[,] CreateCopy<T>(this T[,] input)
        {
            var rowCount = input.GetLength(0);
            var colCount = input.GetLength(1);

            var output = new T[rowCount, colCount];


            for (int row = 0; row < rowCount; row++)
            {
                for (int col = 0; col < colCount; col++)
                {
                    output[row, col] = input[row, col];
                }
            }

            return output;
        }

        public static T[][] ToJaggedArray<T>(this T[,] twoDimensionalArray)
        {
            int rowsFirstIndex = twoDimensionalArray.GetLowerBound(0);
            int rowsLastIndex = twoDimensionalArray.GetUpperBound(0);
            int numberOfRows = rowsLastIndex + 1;

            int columnsFirstIndex = twoDimensionalArray.GetLowerBound(1);
            int columnsLastIndex = twoDimensionalArray.GetUpperBound(1);
            int numberOfColumns = columnsLastIndex + 1;

            T[][] jaggedArray = new T[numberOfRows][];
            for (int i = rowsFirstIndex; i <= rowsLastIndex; i++)
            {
                jaggedArray[i] = new T[numberOfColumns];

                for (int j = columnsFirstIndex; j <= columnsLastIndex; j++)
                {
                    jaggedArray[i][j] = twoDimensionalArray[i, j];
                }
            }

            return jaggedArray;
        }

        public static Matrix Apply(this Func<Vector, double>[,] matrixFunc, Vector vector)
        {
            var n = matrixFunc.GetLength(0);
            var m = matrixFunc.GetLength(1);
            var result = new Matrix(n, m);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    result[i, j] = matrixFunc[i, j](vector);
                }
            }

            return result;
        }

        public static Vector Apply(this IEnumerable<Func<Vector, double>> vectorFunc, Vector vector) =>
            vectorFunc.Select(f => f(vector)).ToVector();
    }
}