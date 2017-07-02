using OakStatisticalAnalysis.Models;
using OakStatisticalAnalysis.Utils;
using System.Collections.Generic;
using System.Linq;

namespace OakStatisticalAnalysis
{
    public class TestNMClassifierCrossValidation : ITestClassifier
    {
        private List<Sample> testSet;
        private List<double> Avgs = new List<double>();
        private IClassifier classifier;

        public TestNMClassifierCrossValidation()
        {

        }

        public double Test(IClassifier _classifier, List<List<Sample>> _testSet)
        {
            var currentClassifier = _classifier as NMClassifier;
            var trainingSet = currentClassifier.GetTrainingSet();
            var mods = currentClassifier.GetMods();
            for (int i = 0; i < _testSet.Count; i++)
            {

                var aa = _testSet.ElementAt(i).Count(x => GetNearestMean(x, mods.ElementAt(i)) == x.Class);
                Avgs.Add(aa / _testSet.ElementAt(i).Count * 1.0);
            }

            return Avgs.Average();
        }

        private string GetNearestMean(Sample x, double[][] means)
        {
            return MathUtil.CalculateDistnace(means[0].ToList(), x.Features)
                <= MathUtil.CalculateDistnace(means[1].ToList(), x.Features) ?
                  "Acer" : "Quercus";
        }
    }
}
