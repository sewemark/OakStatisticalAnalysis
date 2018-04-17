using OakStatisticalAnalysis.Rules.FisherCalculatoionStrategies;
using System.Collections.Generic;

namespace OakStatisticalAnalysis.Rules
{
    public class RulesFactory
    {
        public static Dictionary<int, IFeaturesSelectingRule> GetRules()
        {
            var rules = new Dictionary<int, IFeaturesSelectingRule>();
            rules.Add(1, new OneDimensionFeaturesSelectingRule(new OneDimensionsFisherCalculator()));
            rules.Add(2, new ManyDimensionsFeaturesSelectingRule(new TwoDimensionsFisherCalculator(), 2));
            rules.Add(3, new ManyDimensionsFeaturesSelectingRule(new TwoDimensionsFisherCalculator(), 3));
            rules.Add(4, new ManyDimensionsFeaturesSelectingRule(new TwoDimensionsFisherCalculator(), 4));   
            rules.Add(5, new ManyDimensionsFeaturesSelectingRule(new TwoDimensionsFisherCalculator(), 5));
            rules.Add(6, new ManyDimensionsFeaturesSelectingRule(new TwoDimensionsFisherCalculator(), 6));
            rules.Add(7, new ManyDimensionsFeaturesSelectingRule(new TwoDimensionsFisherCalculator(), 7));
            rules.Add(8, new ManyDimensionsFeaturesSelectingRule(new TwoDimensionsFisherCalculator(), 8));
            rules.Add(9, new ManyDimensionsFeaturesSelectingRule(new TwoDimensionsFisherCalculator(), 9));
            return rules;
        }
    }
}
