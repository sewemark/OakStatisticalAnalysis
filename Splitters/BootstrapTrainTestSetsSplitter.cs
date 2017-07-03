using OakStatisticalAnalysis.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OakStatisticalAnalysis
{
    internal class BootstrapTrainTestSetsSplitter :ITrainTestSetsSplitter
    {
        private List<Sample> testSet = new List<Sample>();
        private List<Sample> trainningSet;
        private List<List<Sample>> lista;
        private SplitterConfig config;

        public void Split()
        {
            int numOfElementsInBag = Convert.ToInt32(Math.Floor(Convert.ToDouble((trainningSet.Count)/config.BootstrapBags)));
            lista = new List<List<Sample>>(config.KParam);
            for(int i =0;i<config.KParam;i++)
            {
                lista.Add(new List<Sample>());
            }
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

        public TrainTestStruct Split(List<Sample> database, SplitterConfig _config)
        {
            trainningSet = database;
            config = _config;
            Split();
            return new TrainTestStruct()
            {
                TrainingSets = lista,
                TestSet = new List<List<Sample>>() { testSet }
            };
        }
    }
}