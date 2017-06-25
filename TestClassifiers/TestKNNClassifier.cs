using OakStatisticalAnalysis.Models;
using System.Collections.Generic;
using System;
using System.Linq;
using OakStatisticalAnalysis.Utils;

namespace OakStatisticalAnalysis
{
    public class TestKNNClassifier : ITestClassifier
    {
        private List<Sample> testSet;
        private List<List<Sample>> trainingSet;
        private List<Sample> currentPointer;
        private int kParam = 3;

        public void SetKParam(int k)
        {
            kParam = k; 
        }

        public double Test(IClassifier classifier, List<Sample> _testSet)
        {
            double result = 0;
            trainingSet = classifier.GetTrainingSet();
            trainingSet.ForEach(x =>
            {
                currentPointer = x;
                result += _testSet.Count(y => GetKNearestNeighbourFromTrainingSet(y) == y.Class)
                    / (_testSet.Count * 1.0);
            });
            return result / trainingSet.Count() * 1.0;
        }


        private string GetKNearestNeighbourFromTrainingSet(Sample sample)
        {
            var rr = currentPointer.OrderBy(x => MathUtil.CalculateDistnace(sample.Features, x.Features))
                        .Take(kParam).GroupBy(grp => grp.Class)
                        .OrderBy(y => y.Count())
                        .First().Select(x => x.Class).First();

            return rr;
        }
    }
}