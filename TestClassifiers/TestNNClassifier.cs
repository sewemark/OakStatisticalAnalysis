using System.Collections.Generic;
using OakStatisticalAnalysis.Models;
using System.Linq;
using OakStatisticalAnalysis.Utils;

namespace OakStatisticalAnalysis
{
    public class TestNNClassifier : ITestClassifier
    {
        private List<List<Sample>> trainingSet;
        List<Sample> currentPointer;
        private IClassifier classifier;
        private List<double> results = new List<double>();
        public double Test(IClassifier _classifier, List<List<Sample>> _testSet)
        {
            classifier = _classifier;
            trainingSet = classifier.GetTrainingSet();
            _testSet.ForEach(tS =>
            {

                tS.ToList().ForEach(y =>
                {
                    List<Sample> nns = new List<Sample>();
                    trainingSet.ForEach(zz =>
                    {
                        currentPointer = zz;
                        var qq = GetNearestNeighbourFromTrainingSet(y);
                        nns.Add(qq);
                    });
                    results.Add(nns.Count(x => x.Class == y.Class) / (trainingSet.Count * 1.0));
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