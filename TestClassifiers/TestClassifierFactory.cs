using System;
using System.Collections.Generic;

namespace OakStatisticalAnalysis
{
    public interface ITestClassifierFactory
    {
        ITestClassifier Select(string classifierName, string methodName);
    }
    public class TestClassifierFactory: ITestClassifierFactory
    {
        private Dictionary<string, ITestClassifier> classifierSelectingRules
           = new Dictionary<string, ITestClassifier>();
        public TestClassifierFactory()
        {
            classifierSelectingRules.Add("NNbasic", new TestNNClassifier());
            classifierSelectingRules.Add("NMbasic", new TestNMClassifier());
            classifierSelectingRules.Add("kNNbasic", new TestKNNClassifier());
            classifierSelectingRules.Add("kNMbasic", new TestKNMClassifierAlfaVersion());

            classifierSelectingRules.Add("NNbootstrap", new TestNNClassifier());
            classifierSelectingRules.Add("NMbootstrap", new TestNMClassifier());
            classifierSelectingRules.Add("kNNbootstrap", new TestKNNClassifier());
            classifierSelectingRules.Add("kNMbootstrap", new TestKNMClassifierAlfaVersion());

            classifierSelectingRules.Add("NNcrossvalidation", new TestNNClassifierCrossValidation());
            classifierSelectingRules.Add("NMcrossvalidation", new TestNMClassifierCrossValidation());
            classifierSelectingRules.Add("kNNcrossvalidation", new TestKNNClassifierCrossValidation());
            classifierSelectingRules.Add("kNMcrossvalidation", new TestKNMClassifierAlfaVersionCrossValidation());
        }

        public ITestClassifier Select(string classifierName, string methodName)
        {
            return classifierSelectingRules[classifierName + methodName];
        }
    }
}