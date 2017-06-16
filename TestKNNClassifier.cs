using OakStatisticalAnalysis.Models;
using System.Collections.Generic;
using System;

namespace OakStatisticalAnalysis
{
    public class TestKNNClassifier : ITestClassifier
    {
        private List<Sample> testSet;

        public double Test(List<Sample> _testSet, List<Sample> _trainingSet)
        {
            testSet = _testSet;

            return 0;
        }
    }
}