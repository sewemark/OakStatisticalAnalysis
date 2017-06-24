﻿using OakStatisticalAnalysis.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OakStatisticalAnalysis
{
    internal class BootstrapTrainTestSetsSplitter :ITrainTestSetsSplitter
    {
        private int k;
        private double percentage;
        private List<Sample> bootstrapSet;
        private List<Sample> trainningSet;
        private List<List<Sample>> lista;
        private SpitterConfig config;
        public BootstrapTrainTestSetsSplitter()
        {

        }

       

        public void Init()
        {
            this.k = k;
            int numOfElementsInBag = Convert.ToInt32(Math.Floor(trainningSet.Count * percentage));
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
                for (int i = 0; i < numOfElementsInBag; i++)
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

        public TrainTestStruct Split(List<Sample> database, SpitterConfig _config)
        {
            trainningSet = database;
            config = _config;
            Init();
            return new TrainTestStruct()
            {
                TrainingSets = lista,
                TestSet = new List<Sample>()
            };
        }
    }
}