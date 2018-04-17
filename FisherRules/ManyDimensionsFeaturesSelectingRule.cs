using OakStatisticalAnalysis.Models;
using OakStatisticalAnalysis.Rules.FisherCalculatoionStrategies;
using OakStatisticalAnalysis.Utils;
using System.Collections.Generic;
using System.Linq;

namespace OakStatisticalAnalysis.Rules
{
    public class ManyDimensionsFeaturesSelectingRule : IFeaturesSelectingRule
    {
        private int numOfFeatures;
        private ITwoDimensionsFisherCalculator fisherCalculator;

        public ManyDimensionsFeaturesSelectingRule(ITwoDimensionsFisherCalculator _fisherCalculator, int _numOfFeatures)
        {
            numOfFeatures = _numOfFeatures;
            fisherCalculator = _fisherCalculator;
        }

        public List<int> Select(List<Sample> _samples)
        {
            fisherCalculator.UpdateSamples(_samples);
            return this.HandleManyDimensions(numOfFeatures);
        }

        public List<int> HandleManyDimensions(int _dimensions)
        {
            int dimensions = _dimensions;
            var permutations = Permutations.GetPermutations2(Enumerable.Range(0,64), _dimensions)
                                           .ToList();
            int permIndex = 0;
            double currentResult = 0;
            for (int currentPermutation = 0; currentPermutation < permutations.Count; currentPermutation++)
            {
                var permArray = permutations.ElementAt(currentPermutation);
                double tmpLD = fisherCalculator.Calc(permArray.ToArray(), _dimensions);
                if (tmpLD > currentResult)
                {
                    currentResult = tmpLD;
                    permIndex = currentPermutation;
                }
            }
            return permutations.ElementAt(permIndex).ToList();
        }

    }
}
