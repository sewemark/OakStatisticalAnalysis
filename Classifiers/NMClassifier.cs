using System.Linq;
using System.Collections.Generic;
using OakStatisticalAnalysis.Models;

namespace OakStatisticalAnalysis
{
    public class NMClassifier : IClassifier
    {
        private List<List<Sample>> trainingSet;
        private List<Sample> currentPointer;
        private List<double[][]> mods = new List<double[][]>();
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
            for (int j = 0; j < trainingSet.Count; j++)
            {
                var currentPointer = trainingSet[j];
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
            var aa = mods.Select(x => x[0]).ToArray();
            var bb = mods.Select(x => x[1]).ToArray();

            var aaMeans = Enumerable.Range(0, aa[0].Length)
                                    .Select(i => aa.Average(a => a[i]))
                                    .ToArray();
            var bbMeans = Enumerable.Range(0, bb[0].Length)
                                    .Select(i => bb.Average(a => a[i]))
                                    .ToArray();
            means = new double[][] { aaMeans, bbMeans };
        }

        public List<List<Sample>> GetTrainingSet()
        {
            return trainingSet;
        }
    }
}