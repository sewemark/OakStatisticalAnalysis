using OakStatisticalAnalysis.Models;
using OakStatisticalAnalysis.Utils;
using System.Collections.Generic;
using System.Linq;

namespace OakStatisticalAnalysis
{
    public class TestNMClassifier : ITestClassifier
    {
        private List<double> Avgs = new List<double>();
        private IClassifier classifier;

        public TestNMClassifier()
        {

        }

        public double Test(IClassifier _classifier, List<List<Sample>> _testSet)
        {
            classifier = _classifier;
            var currnetClassifer = _classifier as NMClassifier;
            _testSet.ForEach(tS =>
            {
                var centroids =currnetClassifer.GetMods();
                centroids.ForEach(y =>
                {
                    var aa = tS.Count(x => GetNearestMean(x,y) == x.Class);
                    Avgs.Add(aa / (tS.Count * 1.0));
                });
            });

            return Avgs.Average();
        }
        
        private string GetNearestMean(Sample x, double [][] means)
        {
            return MathUtil.CalculateDistnace(means[0].ToList(), x.Features)
                <= MathUtil.CalculateDistnace(means[1].ToList(), x.Features) ?
                  "Acer" : "Quercus" ;
        }
    }
}