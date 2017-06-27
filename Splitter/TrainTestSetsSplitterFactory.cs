using OakStatisticalAnalysis.Splitter;

namespace OakStatisticalAnalysis
{
    internal class TrainTestSetsSplitterFactory
    {
        public static ITrainTestSetsSplitter Get(string text)
        {
            if (text.Equals("bootstrap"))
                return new BootstrapTrainTestSetsSplitter();
            else if(text.Equals("crossvalidation"))
                return new CorssValidationSplitter();
            else 
                return new BasicTrainTestSetsSplitter();
        }
    }
}