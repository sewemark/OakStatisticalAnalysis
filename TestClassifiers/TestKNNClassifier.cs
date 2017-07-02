using OakStatisticalAnalysis.Models;
using System.Collections.Generic;
using System.Linq;
using OakStatisticalAnalysis.Utils;

namespace OakStatisticalAnalysis
{
    public class TestKNNClassifier : ITestClassifier
    {
        private List<List<Sample>> trainingSet;
        private List<Sample> currentPointer;
        private List<double> results = new List<double>();
        private int kParam = 3;

        public double Test(IClassifier classifier, List<List<Sample>> _testSet)
        {
            kParam = classifier.GetConfig().KParam;
            trainingSet = classifier.GetTrainingSet();
            _testSet.ForEach(tS =>
            {
                trainingSet.ForEach(x =>
                {
                    currentPointer = x;
                    results.Add(tS.Count(y => GetKNearestNeighbourFromTrainingSet(y) == y.Class)
                        / (tS.Count * 1.0));
                });
            });

            return results.Average();
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