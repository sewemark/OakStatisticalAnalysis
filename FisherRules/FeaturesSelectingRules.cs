using System.Collections.Generic;

namespace OakStatisticalAnalysis.Rules
{
    public interface IFeaturesSelectingRules
    {
        IFeaturesSelectingRule GetRuleForNumberOfFeatures(int numOfFeatures);
    }
    public class FeaturesSelectingRules : IFeaturesSelectingRules
    {
        private Dictionary<int, IFeaturesSelectingRule> rules;

        public FeaturesSelectingRules(Dictionary<int, IFeaturesSelectingRule> _rules)
        {
            rules = _rules;
        }
        public IFeaturesSelectingRule GetRuleForNumberOfFeatures(int numOfFeatures)
        {
            return rules[numOfFeatures];
        }
    }
}
