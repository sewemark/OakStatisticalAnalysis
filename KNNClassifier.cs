using System;
using System.Collections.Generic;
using OakStatisticalAnalysis.Models;

namespace OakStatisticalAnalysis
{
    public class KNNClassifier : IClassifier
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