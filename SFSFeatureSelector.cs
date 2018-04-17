using OakStatisticalAnalysis.Models;
using OakStatisticalAnalysis.Rules.FisherCalculatoionStrategies;
using System.Collections.Generic;
using System.Linq;

namespace OakStatisticalAnalysis
{
    public interface ISFSFeatureSelector
    {
        List<int> Select(List<Sample> _samples, int numOfFeatures);
    }
    public class SFSFeatureSelector : ISFSFeatureSelector
    {
        private List<Sample> samples;
        private ITwoDimensionsFisherCalculator fisherCalculator;
       
        public SFSFeatureSelector(ITwoDimensionsFisherCalculator _fisherCalculator)
        {
            fisherCalculator = _fisherCalculator;
        }

        public List<int> Select(List<Sample> _samples, int numOfFeatures)
        {
            samples = _samples;
            this.fisherCalculator.UpdateSamples(_samples);
            List<int> initialPerm = new List<int>();
            for (int i = 0; i < numOfFeatures; i++)
            {
                int[] permutationNumber = new int[64];
                for (int j = 0; j < 64; j++)
                {
                    permutationNumber[j] = j;
                }

                List<int[]> perm = CreatePerm(initialPerm, permutationNumber);
                int permIndex = 0;
                double LD = 0;
                for (int j = 0; j < perm.Count; j++)
                {
                    double tmpLD = fisherCalculator.Calc(perm[j], numOfFeatures);
                  

                    if (tmpLD > LD)
                    {
                        LD = tmpLD;
                       
                        permIndex = j;
                    }
                }
                var temp = perm.ElementAt(permIndex);
                initialPerm.Add(temp[temp.Length-1]);


            }
            return initialPerm;
        }

        private List<int[]> CreatePerm(List<int> currentPerm, int[] num)
        {
            List<int[]> listOfPermutations = new List<int[]>();
            for (int i = 0; i < num.Length; i++)
            {
                int[] listOfFeatures = new int[currentPerm.Count + 1];
                for (int j = 0; j < currentPerm.Count; j++)
                {
                    listOfFeatures[j] = currentPerm[j];
                }
                listOfFeatures[currentPerm.Count] = num[i];
                if (listOfFeatures.Count() > 1 && listOfFeatures.Distinct().Count() < listOfFeatures.Count())
                {

                }
                else
                {
                    listOfPermutations.Add(listOfFeatures);
                }
            }
            return listOfPermutations;
        }
    }
}
