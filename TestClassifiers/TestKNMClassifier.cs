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
        List<Centroid> centroids;
        private int kParam = 3;
        public double Test(IClassifier classifier, List<List<Sample>> _testSet)
        {
            kParam = classifier.GetConfig().KParam;
            double result = 0;
            var kk =classifier as KNMClassifier;
            centroids = kk.GetCentroid();
            trainingSet = classifier.GetTrainingSet();
            _testSet.ForEach(tS =>
            {
                currentPointer = tS;
                tS.ForEach(x =>
                {
                    var properClassification = tS.Count(y => GetKNearestNeighbourFromTrainingSet(y) == y.Class);
                    result += properClassification
                        / (tS.Count * 1.0);
                });
            });
            return result / trainingSet.Select(x => x.Count).Sum();
        }


        private string GetKNearestNeighbourFromTrainingSet(Sample sample)
        {
            var closestCentroid = centroids.OrderBy(x => MathUtil.CalculateDistnace(x.Mod.ToList(), sample.Features))
                .FirstOrDefault();
            return closestCentroid.QNum > closestCentroid.AcerNum ? "Quercus" : "Acer";

        }

    }
}
