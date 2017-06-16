using OakStatisticalAnalysis.Models;
using System.Collections.Generic;

namespace OakStatisticalAnalysis
{
    public  interface ITestClassifier
    {
        double Test(List<Sample> _testSet, List<Sample> _trainingSet);
    }
}