using System.Collections.Generic;
using OakStatisticalAnalysis.Models;
using System.Linq;

namespace OakStatisticalAnalysis
{
    public class TestNNClassifier : ITestClassifier
    {
        private List<Sample> testSet;
        private List<Sample> trainingSet;
        private IClassifier classifier;

        public double Test(IClassifier _classifier, List<Sample> _testSet)
        {
            classifier = _classifier;
            var trainingSet = classifier.GetTrainingSet();
            return _testSet.Count(x => GetNearestMean(x) == x.Class)
            / _testSet.Count;
        }

        private string GetNearestMean(Sample x)
        {
            var currentclassfier = classifier as KNMClassifier;
            var means = currentclassfier.GetCentroid();
            var grouped = means.GroupBy(y=> y.Number);
            //  grouped.Count(yy=>yy.Count(r=>r.ClassLables ))
            // return MathUtil.CalculateDistnace(means[0].ToList(), x.Features)
            //   >= MathUtil.CalculateDistnace(means[0].ToList(), x.Features) ?
            // "Acer" : "Quercus";
            return "Acer";
        }
    }
}