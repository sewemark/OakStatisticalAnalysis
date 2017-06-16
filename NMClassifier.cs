using System;
using System.Collections.Generic;
using OakStatisticalAnalysis.Models;

namespace OakStatisticalAnalysis
{
    public class NMClassifier : IClassifier
    {
        private List<Sample> trainingSet;
        private double[][] means;

        public void Classify()
        {

        }

        public void Train(List<Sample> _trainingSet)
        {
            trainingSet = _trainingSet;
            CalculateMenasForClass();
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
                for (int j = 0; j < trainingSet[0].Features.Count; j++)
                {
                    if (trainingSet[0].Class == "Acer")
                    {
                        _modA += (double)trainingSet[i].Features[j];
                        numOfAMod++;
                    }
                    else
                    {
                        _modB += (double)trainingSet[i].Features[j];
                        numOfBMod++;
                    }
                }
                modA[i] = (_modA / numOfAMod);
                modB[i] = (_modB / numOfBMod);
            }
            means = new double[][] { modA, modB };
        }

        public List<Sample> GetTrainingSet()
        {
            return trainingSet;
        }
    }
}