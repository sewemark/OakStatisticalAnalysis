using OakStatisticalAnalysis.Models;
using System.Collections.Generic;

namespace OakStatisticalAnalysis.Rules
{
    public class ManyDimensionsFeaturesSelectingRule : IFeaturesSelectingRule
    {
        public List<int> Select(List<Sample> samples)
        {
            ManyDimensionsFeatureSelector selector = new ManyDimensionsFeatureSelector(samples);
            return selector.HandleManyDimensions(numOfFeatures);
        }
    }
}
