using OakStatisticalAnalysis.Models;
using System.Collections.Generic;

namespace OakStatisticalAnalysis
{
    public  interface ITestClassifier
    {
        double Test(IClassifier classifier, List<Sample> _testSet);
    }
}