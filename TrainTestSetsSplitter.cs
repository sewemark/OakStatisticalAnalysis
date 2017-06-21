using System;
using System.Linq;
using OakStatisticalAnalysis.Models;
using System.Collections.Generic;


namespace OakStatisticalAnalysis
{
    public interface ITrainTestSetsSplitter
    {
        TrainTestStruct Split(List<Sample> database, double ratio);
    }

    public class BasicTrainTestSetsSplitter : ITrainTestSetsSplitter
    {
        public TrainTestStruct Split(List<Sample> database,double ratio)
        {
            var train = database.GroupBy(x => x.Class)
                .Select(y => y.Take(Convert.ToInt32(Math.Floor(y.Count() * ratio))));
            var test = database.GroupBy(x => x.Class)
                .Select(y => y.Skip(Convert.ToInt32(Math.Floor(y.Count() * ratio))));
            return new TrainTestStruct
            {
                TrainingSet = train.SelectMany(x => x).ToList(),
                TestSet = test.SelectMany(x => x).ToList()
            };
        }
    }

    public struct TrainTestStruct
    {
        public List<Sample> TestSet;
        public List<Sample> TrainingSet;
    }
}
