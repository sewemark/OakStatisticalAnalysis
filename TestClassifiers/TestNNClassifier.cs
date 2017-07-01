using System.Collections.Generic;
using OakStatisticalAnalysis.Models;
using System.Linq;
using OakStatisticalAnalysis.Utils;

namespace OakStatisticalAnalysis
{
    public class TestNNClassifier : ITestClassifier
    {
        private List<Sample> testSet;
        private List<List<Sample>> trainingSet;
        List<Sample> currentPointer;
        private IClassifier classifier;
        private List<double> results = new List<double>();
        public double Test(IClassifier _classifier, List<List<Sample>> _testSet)
        {
            classifier = _classifier;
            trainingSet = classifier.GetTrainingSet();
            //return _testSet.Count(x => GetNearestNeighbourFromTrainingSet(x).Class == x.Class)
            // / _testSet.Count;
            _testSet.ForEach(tS =>
            {

                tS.Take(10).ToList().ForEach(y =>
                {
                    trainingSet.ForEach(zz =>
                   {
                       currentPointer = zz;
                        var qq =zz.Count(zzz => GetNearestNeighbourFromTrainingSet(zzz).Class == y.Class);
                        var aa = zz.Count;
                        double r = qq / (aa * 1.0);
                        results.Add(r);
                    });
                });
            });
            return results.Average();
        }

        private Sample GetNearestNeighbourFromTrainingSet(Sample sample)
        {
            return currentPointer.OrderBy(x => MathUtil.CalculateDistnace(sample.Features, x.Features))
                 .FirstOrDefault();
        }
    }
}