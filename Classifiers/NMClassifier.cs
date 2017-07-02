using System.Collections.Generic;
using OakStatisticalAnalysis.Models;

namespace OakStatisticalAnalysis
{
    public class NMClassifier : IClassifier
    {
        private List<List<Sample>> trainingSet;
        private List<Sample> currentPointer;
        private List<double[][]> mods = new List<double[][]>();
        private ClassifierConfig config;

        public void Train(List<List<Sample>> _trainingSet, ClassifierConfig _config)
        {
            config = _config;
            trainingSet = _trainingSet;
            mods.Clear();
            trainingSet.ForEach(x =>
            {
                currentPointer = x;
                CalculateMenasForClass();
            });
        }

        public List<double[][]> GetMods()
        {
            return mods;
        }

        public void CalculateMenasForClass()
        {
            double[] modA = new double[currentPointer[0].Features.Count];
            double[] modB = new double[currentPointer[0].Features.Count];
            for (int z = 0; z < currentPointer[0].Features.Count; z++)
            {
                double _modA = 0;
                double _modB = 0;
                int numOfAMod = 0;
                int numOfBMod = 0;
                for (int i = 0; i < currentPointer.Count; i++)
                {
                    if (currentPointer[i].Class.Equals("Acer"))
                    {
                        _modA += (double)currentPointer[i].Features[z];
                        numOfAMod++;
                    }
                    else
                    {
                        _modB += (double)currentPointer[i].Features[z];
                        numOfBMod++;
                    }
                }
                modA[z] = _modA / numOfAMod;
                modB[z] = _modB / numOfBMod;
            }
            mods.Add(new double[][] { modA, modB });
        }

        public List<List<Sample>> GetTrainingSet()
        {
            return trainingSet;
        }

        public ClassifierConfig GetConfig()
        {
            return config;
        }
    }
}