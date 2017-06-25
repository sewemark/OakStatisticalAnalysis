using System;
using System.Collections.Generic;
using OakStatisticalAnalysis.Models;

namespace OakStatisticalAnalysis
{
    public class NMClassifier : IClassifier
    {
        private List<List<Sample>> trainingSet;
        private List<Sample> currentPointer;
        private double[][] means;

        public void Classify()
        {

        }

        public void Train(List<List<Sample>> _trainingSet)
        {

            trainingSet = _trainingSet;
            trainingSet.ForEach(x =>
            {
                currentPointer = x;
                CalculateMenasForClass();
            });
        }
        public double[][] GetMeans()
        {
            return means;
        }
        public void CalculateMenasForClass()
        {
            double[] modA = new double[trainingSet.Count];
            double[] modB = new double[trainingSet.Count];
            for (int i = 0; i <trainingSet.Count; i++)
            {
                double _modA = 0;
                double _modB = 0;
                int numOfAMod = 0;
                int numOfBMod = 0;
                for (int j = 0; j < currentPointer[0].Features.Count; j++)
                {
                    if (currentPointer[0].Class == "Acer")
                    {
                        _modA += (double)currentPointer[i].Features[j];
                        numOfAMod++;
                    }
                    else
                    {
                        _modB += (double)currentPointer[i].Features[j];
                        numOfBMod++;
                    }
                }
                modA[i] = (_modA / numOfAMod);
                modB[i] = (_modB / numOfBMod);
            }
            means = new double[][] { modA, modB };
        }

        public List<List<Sample>> GetTrainingSet()
        {
            return trainingSet;
        }
    }
}