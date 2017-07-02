using System.Collections.Generic;
using OakStatisticalAnalysis.Models;

namespace OakStatisticalAnalysis
{
    public interface IClassifier
    {
        void Train(List<List<Sample>> trainingSet);
        List<List<Sample>> GetTrainingSet();
    }
}