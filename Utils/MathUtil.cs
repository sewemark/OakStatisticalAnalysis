using System;
using System.Collections.Generic;

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

        public static int[] RandomPartition(int numOfClasters, int numOfElements)
        {
            Random r = new Random(12);
            int[] randomClastering = new int[numOfElements];
            for (int i = 0; i < numOfElements; i++)
            {
                randomClastering[i] = r.Next(0, numOfClasters);
            }
            return randomClastering;
        }
    }
}
