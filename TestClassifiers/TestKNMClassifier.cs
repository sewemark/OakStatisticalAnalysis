using System;
using System.Collections.Generic;
using OakStatisticalAnalysis.Models;
using System.Linq;
using OakStatisticalAnalysis.Utils;

namespace OakStatisticalAnalysis
{
    internal class TestKNMClassifier : ITestClassifier
    {
        private List<Sample> testSet;
        private List<List<Sample>> trainingSet;
        private List<Sample> currentPointer;
        private int kParam = 0;
        public double Test(IClassifier classifier, List<Sample> _testSet)
        {
            double result = 0;
            trainingSet = classifier.GetTrainingSet();
            trainingSet.ForEach(x =>
            {
                currentPointer = x;
                result += _testSet.Count(y => GetKNearestNeighbourFromTrainingSet(y) == y.Class)
                    / _testSet.Count;
            });
            return result / trainingSet.Select(x => x.Count).Sum();
        }


        private string GetKNearestNeighbourFromTrainingSet(Sample sample)
        {
            return currentPointer.OrderBy(x => MathUtil.CalculateDistnace(sample.Features, x.Features))
                       .Take(kParam).OrderByDescending(grp => grp.Class)
                       .Select(grp => grp.Class).First();
        }
    }
}