using System;
using System.Collections.Generic;
using OakStatisticalAnalysis.Models;
using System.Linq;
using OakStatisticalAnalysis.Utils;

namespace OakStatisticalAnalysis
{
    internal class KNMClassifier : IClassifier
    {
        private List<Sample> trainingSet;
        private List<Sample> adjuctesTrainingSet = new List<Sample>();
        private List<Centroid> centroids;
        private const int kParam = 5;
        private double[][] oldCentroids = new double[kParam][];
        public void Classify()
        {

        }

        public List<Sample> GetTrainingSet()
        {
            return trainingSet;
        }

        public void Train(List<Sample> _trainingSet)
        {
            trainingSet = _trainingSet;
            InitCentroids();
            CalculateInitialMeans();
            UpdateSamples();
            bool isAnyMenasChanged = true;
            int maxCount = 0;
            while (isAnyMenasChanged == true && maxCount < 5)
            {
                CleanCentroids();
                CalculateMeans();
                isAnyMenasChanged = CheckChanged();
                UpdateSamples();
                maxCount++;
                UpdateInfo();

            }

        }

        private void UpdateInfo()
        {
            centroids.ForEach(x =>
            {
                x.AcerNum = x.ClassLables.Count(y => string.Equals(y, "Acer"));
                x.QNum = x.ClassLables.Count() - x.AcerNum;
            });
        }

        private void CleanCentroids()
        {
            for(int i =0;i<centroids.Count;i++)
            {
                oldCentroids[i] = new double[centroids.ElementAt(i).Mod.Count()];
                 Array.Copy(centroids.ElementAt(i).Mod, oldCentroids[i], centroids.ElementAt(i).Mod.Count());
            }

            centroids.ForEach(x =>
            {
                x.InitValues();
            });
        }

        private void InitCentroids()
        {
            centroids = new List<Centroid>(kParam);
            for(int i=0;i<kParam;i++)
            {
                Centroid c = new Centroid(i);
                centroids.Add(c);
            }
            
        }

        public  void UpdateSamples()
        {
            adjuctesTrainingSet.Clear();
            trainingSet.ForEach(y => {
                var centroid = centroids.OrderByDescending(x =>
                 MathUtil.CalculateDistnace(x.Mod.ToList(), y.Features)).FirstOrDefault();
                adjuctesTrainingSet.Add(new Sample() { Label = y.Label, Class = centroid.Number.ToString(), CentoridNumber= centroid.Number, Features = y.Features });

            });
        }
        public bool CheckChanged()
        {
            for(int i=0;i<centroids.Count;i++)
            {
               if (centroids[i].Mod.Except(oldCentroids[i]).Count() != 0) 
                    return true;
            }

            return false;
        }

        public void CalculateMeans()
        {

            var randomClastering = RandomPartition(kParam);

            for (int j = 0; j < trainingSet[0].Features.Count; j++)
            {
                for (int i = 0; i < adjuctesTrainingSet.Count(); i++)
                {
                    int whichCentroid = adjuctesTrainingSet.ElementAt(i).CentoridNumber;
                    var curentCentorid = centroids.ElementAt(whichCentroid);
                    
                    var currentValue = (double)adjuctesTrainingSet[i].Features[j];
                    curentCentorid.Mod[j] += currentValue;
                    curentCentorid.ModOccurencies[j] += 1;
                    curentCentorid.ClassLables.Add(trainingSet[i].Class);
                }
            }
            centroids.ForEach(x => x.ZippValues());

        }

        public void CalculateInitialMeans()
        {
            var randomClastering = RandomPartition(kParam);
          
            for (int j = 0; j < trainingSet[0].Features.Count; j++)
            {
                for (int i = 0; i < randomClastering.Length; i++)
                {
                    int whichCentroid = randomClastering[i];
                    var curentCentorid = centroids.ElementAt(whichCentroid);
                
                    var currentValue = (double)trainingSet[i].Features[j];
                    curentCentorid.Mod[j] += currentValue;
                    curentCentorid.ModOccurencies[j] += 1;
                    curentCentorid.ClassLables.Add(trainingSet[i].Class);
                }
            }
            centroids.ForEach(x => x.ZippValues());
        }
           
        

        public  int[] RandomPartition(int numOfClasters)
        {
            Random r = new Random(12);
            int[] randomClastering = new int[trainingSet.Count];
            for(int i = 0; i < trainingSet.Count; i++)
            {
             randomClastering[i] =  r.Next(0, numOfClasters);
            }
            return randomClastering;
        }
    }

    public class Centroid
    {
        public int Number;
        public double[] Mod;
        public double[] ModOccurencies;
        public List<string> ClassLables;
        public int AcerNum = 0;
        public int QNum = 0;

        public Centroid(int _number)
        {
            Number = _number;
            InitValues();
        }
        public void InitValues()
        {
            Mod = Enumerable.Repeat<double>(0, 64).ToArray();
            ModOccurencies  = Enumerable.Repeat<double>(0, 64).ToArray();
            ClassLables = new List<string>();
    }
        public void ZippValues()
        {
            Mod = Mod.Zip(ModOccurencies, (x, y) =>
            {
                return x / y;
            }).ToArray();
           
        }
    }

    public class Claster
    {

    }
}