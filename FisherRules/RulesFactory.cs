using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OakStatisticalAnalysis.Rules
{
    public class RulesFactory
    {
        public static Dictionary<int, IFeaturesSelectingRule> GetRules()
        {
            var rules = new Dictionary<int, IFeaturesSelectingRule>();
            rules.Add(1, new OneDimensionFeaturesSelectingRule());
            rules.Add(2, new ManyDimensionsFeaturesSelectingRule(2));
            rules.Add(3, new ManyDimensionsFeaturesSelectingRule(3));
            rules.Add(4, new ManyDimensionsFeaturesSelectingRule(4));   
            rules.Add(5, new ManyDimensionsFeaturesSelectingRule(5));
            rules.Add(6, new ManyDimensionsFeaturesSelectingRule(6));
            rules.Add(7, new ManyDimensionsFeaturesSelectingRule(7));
            rules.Add(8, new ManyDimensionsFeaturesSelectingRule(8));
            rules.Add(9, new ManyDimensionsFeaturesSelectingRule(9));
            return rules;
        }
    }
}
