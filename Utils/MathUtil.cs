using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OakStatisticalAnalysis.Utils
{
    public  class MathUtil
    {
        public static double CalculateDistnace(List<decimal> v1, List<decimal> v2)
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

        public static double CalculateDistnace( List<double> v1, List<double> v2)
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

        public static double CalculateDistnace( List<double> v1, List<decimal> v2)
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
