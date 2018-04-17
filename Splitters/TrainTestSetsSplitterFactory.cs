using OakStatisticalAnalysis.Splitter;

namespace OakStatisticalAnalysis
{
    public interface ITrainTestSetsSplitterFactory
    {
        ITrainTestSetsSplitter Get(string text);
    }
    public class TrainTestSetsSplitterFactory: ITrainTestSetsSplitterFactory
    {
        public  ITrainTestSetsSplitter Get(string text)
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