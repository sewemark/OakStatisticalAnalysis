using System.Collections.Generic;
using OakStatisticalAnalysis.Models;

namespace OakStatisticalAnalysis
{
    public class NNClassifier : IClassifier
    {
        private List<List<Sample>> trainingSet;
        private ClassifierConfig config;

        public List<List<Sample>> GetTrainingSet()
        {
            return trainingSet;
        }

        public void Train(List<List<Sample>> _trainingSet, ClassifierConfig _config)
        {
            config = _config;
            trainingSet = _trainingSet;
        }

        public ClassifierConfig GetConfig()
        {
            return config;
        }
    }
}
