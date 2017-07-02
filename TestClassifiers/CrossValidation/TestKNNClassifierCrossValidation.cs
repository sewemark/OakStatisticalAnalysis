using OakStatisticalAnalysis.Models;
using System.Collections.Generic;
using System.Linq;
using OakStatisticalAnalysis.Utils;
namespace OakStatisticalAnalysis
{
    public class TestKNNClassifierCrossValidation : ITestClassifier
    {
        private List<Sample> testSet;
        private List<List<Sample>> trainingSet;
        private List<Sample> currentPointer;
        private List<double> results = new List<double>();
        private int kParam = 3;

        public void SetKParam(int k)
        {
            kParam = k;
        }

        public double Test(IClassifier classifier, List<List<Sample>> _testSet)
        {

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
            //for(int i=0;i< _testSet.Count;i++)
            //{
            //    currentPointer = trainingSet.ElementAt(i);
            //    _testSet.ElementAt(i).ForEach(x =>
            //    {

            //        result += tS.Count(y => GetKNearestNeighbourFromTrainingSet(y) == y.Class)
            //            / (_testSet.Count * 1.0);
            //    });
            //    results.Add(result / tS.Count() * 1.0);
            //});

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
