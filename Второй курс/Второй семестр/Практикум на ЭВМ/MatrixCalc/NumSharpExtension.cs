using NumSharp;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MatrixCalc
{
	public static class NumSharpExtension
    {
		public static double[,] ToDoubleArray(this NDArray Matrix)
		{
			double[,] res = new double[Matrix.Shape[0], Matrix.Shape[1]];
			for (int i = 0; i < Matrix.Shape[0]; i++)
			{
				for (int j = 0; j < Matrix.Shape[1]; j++)
				{
					res[i, j] = Matrix[i, j].GetDouble();
				}
			}
			return res;
		}

		public static IEnumerable<double> GetDoubleIEnumerable(this NDArray Matrix)
		{
			for (int i = 0; i < Matrix.Shape[0]; i++)
			{
				for (int j = 0; j < Matrix.Shape[1]; j++)
				{
					yield return Matrix[i, j].GetDouble();
				}
			}

		}


		public static double[,] ToInverse(this NDArray nD)
		{
			if (Det.SafeDet(nD.ToDoubleArray()) == 0)
				throw new Exception("Det of Matrix == 0");

			Matrix matrix = new Matrix(nD.Shape[0], nD.Shape[1], nD.GetDoubleIEnumerable().ToArray());
			matrix.InvPartial();
			return np.array(matrix.b).reshape(nD.Shape).ToDoubleArray();
		}
	}
}
