using System;
using System.Collections.Generic;

namespace OakStatisticalAnalysis
{
    internal class TestClassifierFactory
    {
        private Dictionary<string, ITestClassifier> classifierSelectingRules
           = new Dictionary<string, ITestClassifier>();
        public TestClassifierFactory()
        {
            classifierSelectingRules.Add("NN", new TestNNClassifier());
            classifierSelectingRules.Add("NM", new TestNMClassifier());
            classifierSelectingRules.Add("kNN", new TestKNNClassifier());
        }

        public ITestClassifier Select(string classifierName)
        {
            return classifierSelectingRules[classifierName];
        }
    }
}