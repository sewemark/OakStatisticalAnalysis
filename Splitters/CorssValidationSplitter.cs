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
        private SplitterConfig _config;
        private List<List<Sample>> trainingSet;
        private List<List<Sample>> testSets;

        public TrainTestStruct Split(List<Sample> database, SplitterConfig config)
        {
           
            _config= config;
            InitList();
            var grouped = database.GroupBy(x => x.Class);
            for (int i = 0; i < grouped.Count(); i++)
            {
                var currentGrouped = grouped.ElementAt(i).Select(x => x);
                var elementCount = currentGrouped.Count() / config.CrossValidationKParam + 1;

                for (int j = 0; j < currentGrouped.Count();j++)
                {
                    var testSet = currentGrouped.Skip(j).Take(elementCount);
                    var usedIndexs = Enumerable.Range(j, j + elementCount);
                    var trainign = currentGrouped.Where((x, index) => usedIndexs.Contains(index) == false);
                    testSets[j/ elementCount].AddRange(testSet.ToList());
                    trainingSet[j/elementCount].AddRange(trainign.ToList());
                    j = j+ elementCount;

                }
            }
            
            return new TrainTestStruct()
            {
                TrainingSets = trainingSet,
                TestSet = testSets
            };

        }

        public void InitList()
        {
            trainingSet = new List<List<Sample>>(_config.CrossValidationKParam);
            testSets = new List<List<Sample>>(_config.CrossValidationKParam);
                
            for (int i =0;i<_config.CrossValidationKParam;i++)
            {
                trainingSet.Add(new List<Sample>());
                testSets.Add(new List<Sample>());

            }
        }
    }
}
