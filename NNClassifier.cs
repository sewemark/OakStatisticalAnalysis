using System;
using System.Collections.Generic;
using System.Linq;
using OakStatisticalAnalysis.Models;

namespace OakStatisticalAnalysis
{
    public class NNClassifier : IClassifier
    {
        private List<Sample> trainingSet;
        public void Classify()
        {
        }

        public List<Sample> GetTrainingSet()
        {
            return trainingSet;
        }

        public void Train(List<Sample> _trainingSet)
        {
            trainingSet = _trainingSet;
        }
    }

}
