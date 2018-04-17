using System;
using System.Collections.Generic;
using OakStatisticalAnalysis.Models;
using System.Linq;
using OakStatisticalAnalysis.Utils;

namespace OakStatisticalAnalysis
{
    internal class KNMClassifierAlfaVersion : IClassifier
    {
        private List<List<Sample>> trainingSet;
        private List<Sample> adjuctesTrainingSet = new List<Sample>();
        private List<List<Sample>> listOfSetsByClass = new List<List<Sample>>();
        private List<Centroid> centroids;
        private List<List<Centroid>> listOfCentroids = new List<List<Centroid>>();
        private Centroid[] backCentorids;
        private List<Sample> currentPointer;
        private int[] randomClastering;
        private ClassifierConfig config;
        private bool isAnyMenasChanged = true;
        private bool areAllsCentroidsAsignes = true;
        private int  maxCount = 0;

        public void Train(List<List<Sample>> _trainingSet, ClassifierConfig _config)
        {
            config = _config;
            trainingSet = _trainingSet;
            trainingSet.ForEach(x =>
            {
                GroupSamplesByClass(x);
                listOfSetsByClass.ForEach(p =>
                {
                    SetuCurrentPointer(p);
                    InitCentroids();
                    CalculateInitialMeans();
                    UpdateInitialSamples();
                    RestState();
                    while (CheckState())
                    {
                        CleanCentroids();
                        CalculateMeans();
                        CheckChanged();
                        UpdateSamples();
                        if(CheckIfAllCentroidsAreAssignedSample())
                        {
                            RollBack();
                        }
                        UpdateInfo();
                    }
                    listOfCentroids.Add(centroids);
                });
            });
        }

        public void RollBack()
        {
            centroids.Clear();
            centroids.AddRange(backCentorids.ToList());
        }

        public bool CheckState()
        {
            return isAnyMenasChanged == true && areAllsCentroidsAsignes == true && maxCount < 5;
        }

        public bool CheckIfAllCentroidsAreAssignedSample()
        {
            return areAllsCentroidsAsignes == false;
        }

        private void SetuCurrentPointer(List<Sample> p)
        {
            currentPointer = p;
        }

        private void GroupSamplesByClass(List<Sample> x)
        {
            listOfSetsByClass.Clear();
            var grouped = x.GroupBy(y => y.Class);
            for (int i = 0; i < grouped.Count(); i++)
            {
                listOfSetsByClass.Add(grouped.ElementAt(i).Select(q => q).ToList());
            }
        }

        private void UpdateInfo()
        {
            maxCount++;
            centroids.ForEach(x =>
            {
                x.AcerNum = x.ClassLables.Count(y => string.Equals(y, "Acer"));
                x.QNum = x.ClassLables.Count() - x.AcerNum;
            });
        }

        private void CleanCentroids()
        {
            backCentorids = new Centroid[config.KParam];
            centroids.CopyTo(backCentorids);
            centroids.ForEach(x =>
            {
              x.InitValues(currentPointer[0].Features.Count);
            });
        }

        private void InitCentroids()
        {
            centroids = new List<Centroid>(config.KParam);
            for(int i=0;i< config.KParam; i++)
            {
                Centroid c = new Centroid(i, currentPointer[0].Features.Count);
                centroids.Add(c);
            }
        }

        public  void UpdateSamples()
        {
            var bakc = new Sample[adjuctesTrainingSet.Count];
            adjuctesTrainingSet.CopyTo(bakc);
            adjuctesTrainingSet.Clear();

            currentPointer.ForEach(y => {
                var centroid = centroids.Select(x=>MathUtil.CalculateDistnace(x.Mod.ToList(), y.Features)).ToList();
                var min = Array.IndexOf(centroid.ToArray(), centroid.Min());
                adjuctesTrainingSet.Add(new Sample() { Label = y.Label, Class = min.ToString(), CentoridNumber= min, Features = y.Features });
            });

            for (int i = 0; i < centroids.Count; i++)
            {
                if (!adjuctesTrainingSet.Any(x => x.CentoridNumber == i))
                {
                    adjuctesTrainingSet.Clear();
                    adjuctesTrainingSet.AddRange(bakc.ToList());
                    areAllsCentroidsAsignes = false;
                    return;
                }
             }
            areAllsCentroidsAsignes= true;
        }

        public bool UpdateInitialSamples()
        {
            for (int i = 0; i < currentPointer.Count; i++)
            {
                var y = currentPointer[i];
                var min = randomClastering[i];
                adjuctesTrainingSet.Add(new Sample() { Label = y.Label, Class = min.ToString(), CentoridNumber = min, Features = y.Features });
            }
            return true;
        }

        public void CheckChanged()
        {
            for(int i=0;i<centroids.Count;i++)
            {
                if (centroids[i].Mod.Except(backCentorids[i].Mod).Count() != 0)
                {
                    isAnyMenasChanged = true;
                    return;
                }
            }
            isAnyMenasChanged = false;
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
           randomClastering = MathUtil.RandomPartition(config.KParam, currentPointer.Count);
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

        public void RestState()
        {
            isAnyMenasChanged = true;
            areAllsCentroidsAsignes = true;
            maxCount = 0;
        }
        public List<List<Sample>> GetTrainingSet()
        {
            return trainingSet;
        }

        public List<Centroid> GetCentroid()
        {
            return listOfCentroids.SelectMany(x => x).ToList();
        }

        public List<List<Centroid>> GetListCentroid()
        {
            return listOfCentroids;
        }

        public ClassifierConfig GetConfig()
        {
            return config;
        }
    }
}