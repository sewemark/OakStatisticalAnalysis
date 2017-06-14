using OakStatisticalAnalysis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OakStatisticalAnalysis
{
    public class TrainTestSetsSplitter
    {
        public void Split(List<Sample> database,double ratio)
        {
            var ddd = database.GroupBy(x => x.Class)
                .Select(y => y.Take(Convert.ToInt32(y.Count() * ratio)));


            var aa = 10;

            for (int i = 0; i < ddd.Count(); i++)
            {

            }
        }
    }

    public struct TrainTestStruct
    {
        public List<Sample> TestSet;
        public List<Sample> TrainingSet;
    }
}
