using OakStatisticalAnalysis.Models;
using System.Collections.Generic;
using System.Linq;
using OakStatisticalAnalysis.Utils;
namespace OakStatisticalAnalysis
{
    public class TestKNNClassifierCrossValidation : ITestClassifier
    {
        private List<List<Sample>> trainingSet;
        private List<Sample> currentPointer;
        private List<double> results = new List<double>();
        private int kParam =3;

        public double Test(IClassifier classifier, List<List<Sample>> _testSet)
        {
            kParam = classifier.GetConfig().KParam;
            trainingSet = classifier.GetTrainingSet();
            for (int i = 0; i < _testSet.Count; i++)
            {
                currentPointer = trainingSet.ElementAt(i);
                _testSet.ElementAt(i).ForEach(x =>
                {
                    var qq = GetKNearestNeighbourFromTrainingSet(x);
                    results.Add(qq == x.Class ? 1 : 0);
                });
            }
            return results.Average();
        }

        private string GetKNearestNeighbourFromTrainingSet(Sample sample)
        {
            return currentPointer.OrderBy(x => MathUtil.CalculateDistnace(sample.Features, x.Features))
                        .Take(kParam).GroupBy(grp => grp.Class)
                        .OrderBy(y => y.Count())
                        .First().Select(x => x.Class).First();
        }
    }
}
