using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OakStatisticalAnalysis.Models;

namespace OakStatisticalAnalysis.Splitter
{
    public class CorssValidationSplitter : ITrainTestSetsSplitter
    {
        private SpitterConfig _config;
        private List<List<Sample>> trainingSet = new List<List<Sample>>();
        private List<List<Sample>> testSets = new List<List<Sample>>();

        public TrainTestStruct Split(List<Sample> database, SpitterConfig config)
        {
            _config= config;
            var elementCount = database.Count / config.CrossValidationKParam;
            for(int i =0;i<database.Count;i+=elementCount)
            {
                var testSet = database.Skip(i).Take(elementCount);
                var usedIndexs = Enumerable.Range(i,  i + elementCount);
                var trainign = database.Where((x, index) => usedIndexs.Contains(index) == false);
                testSets.Add(testSet.ToList());
                trainingSet.Add(trainign.ToList());

            }
            return new TrainTestStruct()
            {
                TrainingSets = trainingSet,
                TestSet = testSets
            };

        }
    }
}
