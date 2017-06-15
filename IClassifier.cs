using System.Collections.Generic;
using OakStatisticalAnalysis.Models;

namespace OakStatisticalAnalysis
{
    public interface IClassifier
    {
        void Classify();
        void Train(List<Sample> trainingSet);
    }
}