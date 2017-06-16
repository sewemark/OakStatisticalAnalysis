using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


     
    }
}
