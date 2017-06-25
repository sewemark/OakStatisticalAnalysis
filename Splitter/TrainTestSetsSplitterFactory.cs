using System;

namespace OakStatisticalAnalysis
{
    internal class TrainTestSetsSplitterFactory
    {
        public static ITrainTestSetsSplitter Get(string text)
        {
            if (text.Equals("basic"))
                return new BasicTrainTestSetsSplitter();
            else
                return new BootstrapTrainTestSetsSplitter();
        }
    }
}