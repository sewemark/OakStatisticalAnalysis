using OakStatisticalAnalysis.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OakStatisticalAnalysis
{
    internal class BootstrapTrainTestSetsSplitter :ITrainTestSetsSplitter
    {
        private double percentage;
        private List<Sample> testSet = new List<Sample>();
        private List<Sample> trainningSet;
        private List<List<Sample>> lista;
        private SpitterConfig config;

        public BootstrapTrainTestSetsSplitter()
        {

        }

        public void Init()
        {
            
            int numOfElementsInBag = Convert.ToInt32(Math.Floor(Convert.ToDouble((trainningSet.Count)/config.BootstrapBags)));
            lista = new List<List<Sample>>(config.KParam);
            for(int i =0;i<config.KParam;i++)
            {
                lista.Add(new List<Sample>());
            }
            //bootstrapSet = trainningSet
              ///  .GroupBy(x => x.Class)
                //.SelectMany(x => x.Take(Convert.ToInt32(Math.Floor(Convert.ToDouble(x.Count())))))
                //ToList();
            int max = trainningSet.Count;
            List<int> selectedIndex = new List<int>();
            Random random = new Random(0);
            random.Next(0, max);
            lista.ForEach(x => {
                for (int i = 0; i < numOfElementsInBag; i++)
                {
                    var index = random.Next(0, max);
                    selectedIndex.Add(index);
                    var elemnt = trainningSet.ElementAt(index);
                    x.Add(elemnt);
                }
            });
            testSet.AddRange(trainningSet.Where((x,index) =>selectedIndex.Contains(index)==false));
        }

        public void Bootstrap()
        {
           
        }

        public TrainTestStruct Split(List<Sample> database, SpitterConfig _config)
        {
            trainningSet = database;
            config = _config;
            Init();
            return new TrainTestStruct()
            {
                TrainingSets = lista,
                TestSet = testSet
            };
        }
    }
}