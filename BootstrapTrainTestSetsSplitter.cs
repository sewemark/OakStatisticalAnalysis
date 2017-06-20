using OakStatisticalAnalysis.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OakStatisticalAnalysis
{
    internal class BootstrapTrainTestSetsSplitter
    {
        private int k;
        private double percentage;
        private List<Sample> bootstrapSet;
        private List<List<Sample>> lista;
        public BootstrapTrainTestSetsSplitter(int k,int numOfElementsInBag, double percentage, List<Sample> trainningSet)
        {
            this.k = k;
            lista = new List<List<Sample>>(k);
            lista.ForEach(x => x = new List<Sample>());
            this.percentage = percentage;
            bootstrapSet = trainningSet
                .GroupBy(x => x.Class)
                .SelectMany(x => x.Take(Convert.ToInt32(Math.Floor(x.Count() * this.percentage))))
                .ToList();
            int max = bootstrapSet.Count;
            Random random = new Random(0);
            random.Next(0, max);
            lista.ForEach(x => { 
                for(int i =0;i< numOfElementsInBag;i++)
                {
                    var index = random.Next(0, max);
                    var elemnt = bootstrapSet.ElementAt(index);
                    x.Add(elemnt);
                }
            });
        }

        public void Bootstrap()
        {
           
        }
    }
}