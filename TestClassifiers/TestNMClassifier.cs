using OakStatisticalAnalysis.Models;
using OakStatisticalAnalysis.Utils;
using System.Collections.Generic;
using System.Linq;

namespace OakStatisticalAnalysis
{
    public class TestNMClassifier : ITestClassifier
    {
        private List<Sample> testSet;

        private IClassifier classifier;

        public TestNMClassifier()
        {

        }

        public double Test(IClassifier _classifier, List<Sample> _testSet)
        {
            classifier = _classifier;
            var trainingSet = classifier.GetTrainingSet();
            var aa = _testSet.Count(x => GetNearestMean(x) == x.Class);
            return aa / (_testSet.Count * 1.0);
        }
        
        private string GetNearestMean(Sample x)
        {
            var currentclassfier  = classifier as NMClassifier;
            var means = currentclassfier.GetMeans();
            return MathUtil.CalculateDistnace(means[0].ToList(), x.Features)
                <= MathUtil.CalculateDistnace(means[1].ToList(), x.Features) ?
                  "Acer" : "Quercus" ;
        }
    }
}