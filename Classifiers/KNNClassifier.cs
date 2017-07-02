using System;
using System.Collections.Generic;
using OakStatisticalAnalysis.Models;

namespace OakStatisticalAnalysis
{
    public class KNNClassifier : IClassifier
    {
        private List<List<Sample>> trainingSet;

   

        public List<List<Sample>> GetTrainingSet()
        {
            return trainingSet;
        }

        public void Train(List<List<Sample>> _trainingSet)
        {
            trainingSet = _trainingSet;
        }
    }
}