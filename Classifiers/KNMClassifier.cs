using System;
using System.Collections.Generic;
using OakStatisticalAnalysis.Models;
using System.Linq;
using OakStatisticalAnalysis.Utils;

namespace OakStatisticalAnalysis
{
    internal class KNMClassifier : IClassifier
    {
        private List<List<Sample>> trainingSet;
        private List<Sample> adjuctesTrainingSet = new List<Sample>();
        private List<Centroid> centroids;
        private List<List<Centroid>> listOfCentroids = new List<List<Centroid>>();
        private const int kParam = 3;
        private double[][] oldCentroids = new double[kParam][];
        private List<Sample> currentPointer;

        public void Classify()
        {

        }

        public List<List<Sample>> GetTrainingSet()
        {
            return trainingSet;
        }

        public List<Centroid> GetCentroid()
        {
            return centroids;
        }

        public void Train(List<List<Sample>> _trainingSet)
        {
            
            trainingSet = _trainingSet;
            trainingSet.ForEach(x =>
            {
                currentPointer = x;
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
                listOfCentroids.Add(centroids);
            });


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
            x.InitValues(currentPointer[0].Features.Count);
            });
        }

        private void InitCentroids()
        {
            centroids = new List<Centroid>(kParam);
            for(int i=0;i<kParam;i++)
            {
                Centroid c = new Centroid(i, currentPointer[0].Features.Count);
                centroids.Add(c);
            }
            
        }

        public  void UpdateSamples()
        {
            adjuctesTrainingSet.Clear();
            currentPointer.ForEach(y => {
                var centroid = centroids.Select(x=>MathUtil.CalculateDistnace(x.Mod.ToList(), y.Features)).ToList();
                var min = Array.IndexOf(centroid.ToArray(), centroid.Min());
                adjuctesTrainingSet.Add(new Sample() { Label = y.Label, Class = min.ToString(), CentoridNumber= min, Features = y.Features });
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

            for (int j = 0; j < currentPointer[0].Features.Count; j++)
            {
                for (int i = 0; i < adjuctesTrainingSet.Count(); i++)
                {
                    int whichCentroid = adjuctesTrainingSet.ElementAt(i).CentoridNumber;
                    var curentCentorid = centroids.ElementAt(whichCentroid);
                    
                    var currentValue = (double)adjuctesTrainingSet[i].Features[j];
                    curentCentorid.Mod[j] += currentValue;
                    curentCentorid.ModOccurencies[j] += 1;
                    curentCentorid.ClassLables.Add(currentPointer[i].Class);
                }
            }
            centroids.ForEach(x => x.ZippValues());

        }

        public void CalculateInitialMeans()
        {
            var randomClastering = RandomPartition(kParam);
          
            for (int j = 0; j < currentPointer[0].Features.Count; j++)
            {
                for (int i = 0; i < randomClastering.Length; i++)
                {
                    int whichCentroid = randomClastering[i];
                    var curentCentorid = centroids.ElementAt(whichCentroid);
                
                    var currentValue = (double)currentPointer[i].Features[j];
                    curentCentorid.Mod[j] += currentValue;
                    curentCentorid.ModOccurencies[j] += 1;
                    curentCentorid.ClassLables.Add(currentPointer[i].Class);
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

        public Centroid(int _number,int numOfFeatures)
        {
            Number = _number;
            InitValues(numOfFeatures);
        }
        public void InitValues(int numOfFeatures)
        {
            Mod = Enumerable.Repeat<double>(0, numOfFeatures).ToArray();
            ModOccurencies  = Enumerable.Repeat<double>(0, numOfFeatures).ToArray();
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
    
}