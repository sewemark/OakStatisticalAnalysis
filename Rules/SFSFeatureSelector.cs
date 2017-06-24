using OakStatisticalAnalysis.Models;
using OakStatisticalAnalysis.Rules;
using OakStatisticalAnalysis.Rules.FisherCalculatoionStrategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OakStatisticalAnalysis
{
    public class SFSFeatureSelector : IFeatureSelector
    {
        private List<Sample> samples;
        private IFeaturesSelectingRules featuresSelectorRules;

        public SFSFeatureSelector(List<Sample> _samples, IFeaturesSelectingRules _featuresSelectorRules)
        {
            samples = _samples;
            featuresSelectorRules = _featuresSelectorRules;
        }

        public List<int> Select(int numOfFeatures)
        {

            List<int> initialPerm = new List<int>();
            for (int i = 0; i < numOfFeatures; i++)
            {
                TwoDimensionsFisherCalculator calculatr = new TwoDimensionsFisherCalculator(i + 1, samples);
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
                    double tmpLD = calculatr.Calc(perm[j]);
                    if (tmpLD > LD)
                    {
                        LD = tmpLD;
                        permIndex = j;
                    }
                }
                initialPerm.Add(permIndex);


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
                listOfPermutations.Add(listOfFeatures);
            }
            return listOfPermutations;
        }
    }
}
