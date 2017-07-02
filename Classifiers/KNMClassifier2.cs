using System;
using System.Collections.Generic;
using OakStatisticalAnalysis.Models;
using System.Linq;
using OakStatisticalAnalysis.Utils;

namespace OakStatisticalAnalysis
{
    internal class KNMClassifier2 : IClassifier
    {
        private List<List<Sample>> trainingSet;
        private List<Sample> adjuctesTrainingSet = new List<Sample>();
        private List<List<Sample>> listOfSetsByClass = new List<List<Sample>>();
        private List<Centroid> centroids;
        private List<List<Centroid>> listOfCentroids = new List<List<Centroid>>();
        private const int kParam = 3;
        private double[][] oldCentroids = new double[kParam][];
        private Centroid[] backCentorids = new Centroid[kParam];
        private List<Sample> currentPointer;
        private int[] randomClastering;

        public void Classify()
        {

        }

        public double[][] GetMeans()
        {
            // return means;

            return null;
        }

        public List<List<Sample>> GetTrainingSet()
        {
            return trainingSet;
        }

        public List<Centroid> GetCentroid()
        {
            return listOfCentroids.SelectMany(x => x).ToList();
        }

        public void Train(List<List<Sample>> _trainingSet)
        {
            
            trainingSet = _trainingSet;
            trainingSet.ForEach(x =>
            {

                var grouped = x.GroupBy(y => y.Class);
                for(int i =0;i< grouped.Count();i++)
                {
                    listOfSetsByClass.Add(grouped.ElementAt(i).Select(q => q).ToList());
                }
                listOfSetsByClass.ForEach(p =>
                {
                    currentPointer = p;
                    InitCentroids();
                    CalculateInitialMeans();
                    UpdateInitialSamples();
                    bool isAnyMenasChanged = true;
                    bool areAllsCentroidsAsignes = true;
                    int maxCount = 0;
                    while (isAnyMenasChanged == true && areAllsCentroidsAsignes  == true && maxCount < 5)
                    {
                        CleanCentroids();
                        CalculateMeans();
                        isAnyMenasChanged = CheckChanged();
                        areAllsCentroidsAsignes =UpdateSamples();
                        if(areAllsCentroidsAsignes == false)
                        {
                            centroids.Clear();
                            centroids.AddRange(backCentorids.ToList());
                           
                        }
                        maxCount++;
                        UpdateInfo();
                    }
                    listOfCentroids.Add(centroids);
                });
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
            //backCentorids = new double[oldCentroids.Count()][];
            // oldCentroids.CopyTo(backCentorids, 0);
          //  var oldTemp = new Sample[centroids.Count]; 
            centroids.CopyTo(backCentorids);
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

        public  bool UpdateSamples()
        {
            var bakc = new Sample[adjuctesTrainingSet.Count];
            adjuctesTrainingSet.CopyTo(bakc);
            adjuctesTrainingSet.Clear();
            currentPointer.ForEach(y => {
                var centroid = centroids.Select(x=>MathUtil.CalculateDistnace(x.Mod.ToList(), y.Features)).ToList();
                 
                var min = Array.IndexOf(centroid.ToArray(), centroid.Min());
                adjuctesTrainingSet.Add(new Sample() { Label = y.Label, Class = min.ToString(), CentoridNumber= min, Features = y.Features });
            });

            var test = adjuctesTrainingSet.Select(x => x.CentoridNumber);
            for (int i = 0; i < centroids.Count; i++)
            {
                if (!adjuctesTrainingSet.Any(x => x.CentoridNumber == i))
                {
                    adjuctesTrainingSet.Clear();
                    adjuctesTrainingSet.AddRange(bakc.ToList());
                    return false;
                }
             }
            return true;
        }
        public bool UpdateInitialSamples()
        {
            // var bakc = new Sample[adjuctesTrainingSet.Count];
            // adjuctesTrainingSet.CopyTo(bakc);
            //   adjuctesTrainingSet.Clear();
            for (int i = 0; i < currentPointer.Count; i++)
            {
                var y = currentPointer[i];
                var min = randomClastering[i];
                adjuctesTrainingSet.Add(new Sample() { Label = y.Label, Class = min.ToString(), CentoridNumber = min, Features = y.Features });
            }
            return true;
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

          
            for (int j = 0; j < currentPointer[0].Features.Count; j++)
            {
                for (int i = 0; i < currentPointer.Count(); i++)
                {
                    int whichCentroid = adjuctesTrainingSet.ElementAt(i).CentoridNumber;
                    var curentCentorid = centroids.ElementAt(whichCentroid);
                    
                    var currentValue = (double)adjuctesTrainingSet[i].Features[j];
                    curentCentorid.Mod[j] += currentValue;
                    curentCentorid.ModOccurencies[j] += 1;
                    if (j == 0)
                    {
                        
                        curentCentorid.ClassLables.Add(currentPointer[i].Class);
                    }
                }
            }
            centroids.ForEach(x => x.ZippValues());

        }

        public void CalculateInitialMeans()
        {
           randomClastering = RandomPartition(kParam);
          
            for (int j = 0; j < currentPointer[0].Features.Count; j++)
            {
                for (int i = 0; i < randomClastering.Length; i++)
                {
                    int whichCentroid = randomClastering[i];
                    var curentCentorid = centroids.ElementAt(whichCentroid);
                
                    var currentValue = (double)currentPointer[i].Features[j];
                    curentCentorid.Mod[j] += currentValue;
                    curentCentorid.ModOccurencies[j] += 1;
                    if (j == 0)
                    {
                       
                        curentCentorid.ClassLables.Add(currentPointer[i].Class);
                    }
                }
            }
            centroids.ForEach(x => x.ZippValues());
        }
           
        

        public  int[] RandomPartition(int numOfClasters)
        {
            Random r = new Random(12);
            int[] randomClastering = new int[currentPointer.Count];
            for(int i = 0; i < currentPointer.Count; i++)
            {
                 randomClastering[i] =  r.Next(0, numOfClasters);
            }
            return randomClastering;
        }
    }

    
    
}