using OakStatisticalAnalysis.Models;
using OakStatisticalAnalysis.Rules.FisherCalculatoionStrategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OakStatisticalAnalysis.Rules
{
    public class OneDimensionFeaturesSelectingRule : IFeaturesSelectingRule
    {
        private OneDimensionsFisherCalculator fisherCalcation;

        public List<int> Select(List<Sample> _samples)
        {
            fisherCalcation = new OneDimensionsFisherCalculator(_samples);
            double FLD = 0, tmp;
            int max_ind = -1;
            for (int i = 0; i < _samples.ElementAt(0).Features.Count; i++)
            {
                if ((tmp = fisherCalcation.ComputeFisherFor1D(i)) > FLD)
                {
                    FLD = tmp;
                    max_ind = i;
                }
            }
            return new List<int>() { max_ind };
        }
    }
}
