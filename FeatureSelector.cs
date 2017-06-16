using OakStatisticalAnalysis.Models;
using OakStatisticalAnalysis.Rules;
using System.Collections.Generic;

namespace OakStatisticalAnalysis
{
    public interface IFeatureSelector
    {
        List<int> Extract(int numOfFeatures);
    }

    public class FeatureSelector : IFeatureSelector
    {
        private List<Sample> samples;
        private IFeaturesSelectingRules featuresSelectorRules;

        public FeatureSelector(List<Sample> _samples, IFeaturesSelectingRules _featuresSelectorRules)
        {
            samples = _samples;
            featuresSelectorRules = _featuresSelectorRules;
        }

        public List<int> Extract(int numOfFeatures)
        {
            return featuresSelectorRules.GetRuleForNumberOfFeatures(numOfFeatures)
                                        .Select(samples);
        }
    }
   
}
