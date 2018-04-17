using System.Collections.Generic;

namespace OakStatisticalAnalysis
{
    public interface IClassifierFactory
    {
        IClassifier Select(string classifierName);
    }
    public class ClassifierFactory: IClassifierFactory
    {
        private Dictionary<string, IClassifier> classifierSelectingRules = new Dictionary<string, IClassifier>();

        public ClassifierFactory()
        {
            classifierSelectingRules.Add("NN", new NNClassifier());
            classifierSelectingRules.Add("NM", new NMClassifier());
            classifierSelectingRules.Add("kNN", new KNNClassifier());
            classifierSelectingRules.Add("kNM", new KNMClassifierAlfaVersion());
        }
        public IClassifier Select(string classifierName)
        {
            return classifierSelectingRules[classifierName];
        }
    }
  
}