using System;
using System.Linq;
using OakStatisticalAnalysis.Models;
using System.Collections.Generic;


namespace OakStatisticalAnalysis
{
    public interface ITrainTestSetsSplitter
    {
        TrainTestStruct Split(List<Sample> database, SplitterConfig config);
    }

    public class BasicTrainTestSetsSplitter : ITrainTestSetsSplitter
    {
        public TrainTestStruct Split(List<Sample> database, SplitterConfig config)
        {
            var train = database.GroupBy(x => x.Class)
                .Select(y => y.Take(Convert.ToInt32(Math.Floor(y.Count() * config.Ratio))));
            var test = database.GroupBy(x => x.Class)
                .Select(y => y.Skip(Convert.ToInt32(Math.Floor(y.Count() * config.Ratio))));
            return new TrainTestStruct
            {
                TrainingSets = new List<List<Sample>>() { train.SelectMany(x => x).ToList()},
                TestSet = new List<List<Sample>>(){ test.SelectMany(x => x).ToList() }
            };
        }
    }
}
