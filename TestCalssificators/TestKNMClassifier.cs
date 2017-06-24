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
        private List<Sample> trainingSet;
        private int kParam = 0;
        public double Test(IClassifier classifier, List<Sample> _testSet)
        {
            trainingSet = classifier.GetTrainingSet();
            return _testSet.Count(x => GetKNearestNeighbourFromTrainingSet(x) == x.Class)
                    / _testSet.Count;
        }


        private string GetKNearestNeighbourFromTrainingSet(Sample sample)
        {
            return trainingSet.OrderBy(x => MathUtil.CalculateDistnace(sample.Features, x.Features))
                       .Take(kParam).OrderByDescending(grp => grp.Class)
                       .Select(grp => grp.Class).First();
        }
    }
}