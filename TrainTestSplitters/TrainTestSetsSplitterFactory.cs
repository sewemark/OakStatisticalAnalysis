using System;

namespace OakStatisticalAnalysis
{
    public class TrainTestSetsSplitterFactory
    {
        public  static ITrainTestSetsSplitter Get(string text)
        {
            if (text.Equals("basic"))
                return new BasicTrainTestSetsSplitter();
            else
                return new BootstrapTrainTestSetsSplitter();
        }
    }
}