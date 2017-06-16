using System;
using System.Collections.Generic;
using OakStatisticalAnalysis.Models;
using System.Linq;

namespace OakStatisticalAnalysis
{
    public class TestNNClassifier : ITestClassifier
    {
        private List<Sample> testSet;
        private List<Sample> trainingSet;
        public TestNNClassifier(List<Sample> _trainningSet)
        {
            trainingSet = _trainningSet;
        }
        public TestNNClassifier()
        {

        }

        public double Test(List<Sample> _testSet, List<Sample> _trainingSet)
        {
            trainingSet = _trainingSet;
           var count = _testSet.Count(x =>
            {
                var nn = GetNearestNeighbourFromTrainingSet(x);
                return nn.Class == x.Class;
            });
            return count / _testSet.Count;
            //testSet = _testSet;
            //for (int i = 0; i < _testSet.Count; i++)
            //{
              //  double minDistance = 0;
               // int index = 0;
               
            //}
            //return 0;
        }


        private Sample GetNearestNeighbourFromTrainingSet(Sample sample)
        {
            return trainingSet.OrderBy(x => CalculateDistnace(sample.Features, x.Features))
                 .FirstOrDefault();
            //double minDistance = 0;
            //for (int j = 0; j < trainingSet.Count; j++)
            //{
            //    double currDistance = CalculateDistnace(sample.Features, trainingSet[j].Features);
            //    if (currDistance < minDistance)
            //    {
            //        currDistance = minDistance;
            //    }
            //}
        }

        protected double CalculateDistnace(List<decimal> v1, List<decimal> v2)
        {
            if (v1.Count!= v2.Count)
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