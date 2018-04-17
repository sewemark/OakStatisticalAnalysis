using OakStatisticalAnalysis.Models;
using OakStatisticalAnalysis.Rules;
using System.Collections.Generic;

namespace OakStatisticalAnalysis
{
    public interface IFeatureSelector
    {
        List<int> Select(List<Sample> parsedDatabaseContent, int numOfFeatures);
    }

    public class FeatureSelector : IFeatureSelector
    {
        private List<Sample> samples;
        private IFeaturesSelectingRules featuresSelectorRules;

        public FeatureSelector(IFeaturesSelectingRules _featuresSelectorRules)
        {
            featuresSelectorRules = _featuresSelectorRules;
        }

        public FeatureSelector(List<Sample> _samples, IFeaturesSelectingRules _featuresSelectorRules)
        {
            samples = _samples;
            featuresSelectorRules = _featuresSelectorRules;
        }
       
        public List<int> Select(List<Sample> parsedDatabaseContent, int numOfFeatures)
        {
            samples = parsedDatabaseContent;
            return featuresSelectorRules.GetRuleForNumberOfFeatures(numOfFeatures)
                                       .Select(samples);
        }
    }
}
