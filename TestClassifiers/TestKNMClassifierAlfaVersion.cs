using System.Collections.Generic;
using OakStatisticalAnalysis.Models;
using System.Linq;
using OakStatisticalAnalysis.Utils;

namespace OakStatisticalAnalysis
{
    public class TestKNMClassifierAlfaVersion : ITestClassifier
    {
        private List<List<Sample>> trainingSet;
        private List<Sample> currentPointer;
        List<Centroid> centroids;
        private int kParam = 3;

        public double Test(IClassifier classifier, List<List<Sample>> _testSet)
        {
            kParam = classifier.GetConfig().KParam;
            double result = 0;
            var kk =classifier as KNMClassifierAlfaVersion;
            centroids = kk.GetCentroid();
            trainingSet = classifier.GetTrainingSet();
            _testSet.ForEach(tS =>
            {
                currentPointer = tS;
                    var properClassification = tS.Count(y => {
                        var nn = GetKNearestNeighbourFromTrainingSet(y);
                        return nn == y.Class;
                        });
                    result += properClassification
                        / (tS.Count * 1.0);
            });
           return  result / _testSet.Count; 
        }


        private string GetKNearestNeighbourFromTrainingSet(Sample sample)
        {
            var distnaces = centroids.Select(x => MathUtil.CalculateDistnace(x.Mod.ToList(), sample.Features));
            var closestCentroid = centroids.OrderBy(x => MathUtil.CalculateDistnace(x.Mod.ToList(), sample.Features))
                .Take(kParam);
            return closestCentroid.Where(x=>x.AcerNum>x.QNum).Count()  > closestCentroid.Where(x => x.QNum > x.AcerNum).Count() ? "Acer" : "Quercus";

        }

    }
}
