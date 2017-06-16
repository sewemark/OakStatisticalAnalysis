using System;
using System.Collections.Generic;
using OakStatisticalAnalysis.Models;
using System.Linq;
using OakStatisticalAnalysis.Utils;

namespace OakStatisticalAnalysis
{
    public class TestNNClassifier : ITestClassifier
    {
        private List<Sample> testSet;
        private List<Sample> trainingSet;

        public double Test(IClassifier classifier, List<Sample> _testSet)
        {
            trainingSet = classifier.GetTrainingSet();
            return _testSet.Count(x => GetNearestNeighbourFromTrainingSet(x).Class == x.Class)
            / _testSet.Count;
        }

        private Sample GetNearestNeighbourFromTrainingSet(Sample sample)
        {
            return trainingSet.OrderBy(x => MathUtil.CalculateDistnace(sample.Features, x.Features))
                 .FirstOrDefault();
        }
    }
}