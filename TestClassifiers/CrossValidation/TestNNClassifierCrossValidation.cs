using System.Collections.Generic;
using OakStatisticalAnalysis.Models;
using System.Linq;
using OakStatisticalAnalysis.Utils;

namespace OakStatisticalAnalysis
{
    public class TestNNClassifierCrossValidation : ITestClassifier
    {
        private List<List<Sample>> trainingSet;
        List<Sample> currentPointer;
        private IClassifier classifier;
        private List<double> results = new List<double>();

        public double Test(IClassifier _classifier, List<List<Sample>> _testSet)
        {
            classifier = _classifier;
            trainingSet = classifier.GetTrainingSet();
            for (int i = 0; i < _testSet.Count; i++)
            {
                currentPointer = trainingSet.ElementAt(i);
                _testSet.ElementAt(i).ForEach(x =>
                {
                    var qq = GetNearestNeighbourFromTrainingSet(x);
                    results.Add(qq.Class == x.Class ? 1 : 0);
                });

            }
            return results.Average();
        }

        private Sample GetNearestNeighbourFromTrainingSet(Sample sample)
        {
            return currentPointer.OrderBy(x => MathUtil.CalculateDistnace(sample.Features, x.Features))
                 .FirstOrDefault();
        }
    }
}
