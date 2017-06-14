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
    }
}
