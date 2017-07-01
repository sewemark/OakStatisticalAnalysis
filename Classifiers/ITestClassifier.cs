using OakStatisticalAnalysis.Models;
using System.Collections.Generic;

namespace OakStatisticalAnalysis
{
    public  interface ITestClassifier
    {
        double Test(IClassifier classifier, List<List<Sample>> _testSet);
    }
}