using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using OakStatisticalAnalysis.Models;
using OakStatisticalAnalysis.Rules.FisherCalculatoionStrategies;
using OakStatisticalAnalysis.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OakStatisticalAnalysis.Rules
{
  

    public class ManyDimensionsFeaturesSelectingRule : IFeaturesSelectingRule
    {
        private int numOfFeatures;
        private List<Sample> samples;
        private TwoDimensionsFisherCalculator fisherCalculator;
        public ManyDimensionsFeaturesSelectingRule(int _numOfFeatures)
        {
            numOfFeatures = _numOfFeatures;

        }

        public List<int> Select(List<Sample> _samples)
        {
            samples = _samples;
            fisherCalculator = new TwoDimensionsFisherCalculator(numOfFeatures, samples);
            return this.HandleManyDimensions(numOfFeatures);
        }

        public List<int> HandleManyDimensions(int _dimensions)
        {
            int dimensions = _dimensions;
            var permutations = Permutations.Get(dimensions, samples.ElementAt(0).Features.Count());
            int permIndex = 0;
            double LD = 0;
            for (int currentPermutation = 0; currentPermutation < permutations.Count; currentPermutation++)
            {
                var permArray = permutations.ElementAt(currentPermutation);
                double tmpLD = fisherCalculator.Calc(permArray);
                if (tmpLD > LD)
                {
                    LD = tmpLD;
                    permIndex = currentPermutation;
                }
            }
            return permutations.ElementAt(permIndex).ToList();
        }

    }
}
