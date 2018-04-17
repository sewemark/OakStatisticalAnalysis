using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OakStatisticalAnalysis.Utils
{
    public static class Extensions
    {
        public static IEnumerable<double> MinusTwoList(this List<double> first, List<double> second)
        {
            for (int i = 0; i < first.Count; i++)
            {
                yield return first.ElementAt(i) - second.ElementAt(i);
            }
        }

        public static IEnumerable<double> MinusTwoList(this List<double> first, IEnumerable<double> second)
        {
            for (int i = 0; i < first.Count; i++)
            {
                yield return first.ElementAt(i) - second.ElementAt(i);
            }
        }

        public static Matrix<double> ComputeCovarianceMatrix(this Matrix<double> matrix)
        {
            Matrix<double> MT = matrix.Transpose();
            Matrix<double> C = matrix.Multiply(MT);
            return C;
        }

        private static double CalculateDistnace(this List<decimal> v1, List<decimal> v2)
        {
            if (v1.Count != v2.Count)
                return -1;
            double res = 0;
            for (int i = 0; i < v1.Count; i++)
            {
                res += Math.Pow((double)v2[i] - (double)v1[i], 2);
            }
            return Math.Sqrt(res);
        }

        public static T[,] To2DArray<T>(this IEnumerable<IEnumerable<T>> source)
        {
            var jaggedArray = source.Select(r => r.ToArray()).ToArray();
            int rows = jaggedArray.GetLength(0);
            int columns = jaggedArray.Max(r => r.Length);
            var array = new T[rows, columns];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    array[i, j] = jaggedArray[i][j];
                }
            }
            return array;
        }
    }
}
