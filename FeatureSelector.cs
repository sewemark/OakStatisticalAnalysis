using OakStatisticalAnalysis.Models;
using System;
using System.Collections.Generic;
using System.Linq;

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
        public IFeaturesSelectingRule GetRuleForNumberOfFeatures( int numOfFeatures)
        {
            return rules[numOfFeatures];
        }
    }

    public interface IFeaturesSelectingRule
    {
        List<int> Select(List<Sample> samples);
    }

    public class RulesFactory
    {
        public static Dictionary<int, IFeaturesSelectingRule> GetRules()
        {
            var rules = new Dictionary<int, IFeaturesSelectingRule>();
            rules.Add(1, new OneDimensionFeaturesSelectingRule());
            rules.Add(2, new ManyDimensionsFeaturesSelectingRule());
            rules.Add(3, new ManyDimensionsFeaturesSelectingRule());
            rules.Add(4, new ManyDimensionsFeaturesSelectingRule());
            rules.Add(5, new ManyDimensionsFeaturesSelectingRule());
            rules.Add(6, new ManyDimensionsFeaturesSelectingRule());
            rules.Add(7, new ManyDimensionsFeaturesSelectingRule());
            rules.Add(8, new ManyDimensionsFeaturesSelectingRule());
            rules.Add(9, new ManyDimensionsFeaturesSelectingRule());
            return rules;
        }
    }

    public class OneDimensionFeaturesSelectingRule : IFeaturesSelectingRule
    {
        private List<Sample> samples;
        public List<int> Select(List<Sample> _samples)
        {
            samples = _samples;
            double FLD = 0, tmp;
            int max_ind = -1;
            for (int i = 0; i < samples.ElementAt(0).Features.Count; i++)
            {
                if ((tmp = ComputeFisherFor1D(i)) > FLD)
                {
                    FLD = tmp;
                    max_ind = i;
                }
            }
            return new List<int>() { max_ind };
        }
        private double ComputeFisherFor1D(int index)
        {
            double mA = 0, mB = 0, sA = 0, sB = 0;
            for (int i = 0; i < samples.Count; i++)
            {
                double currenValue = (double)samples.ElementAt(i).Features.ElementAt(index);
                var currentSample = samples.ElementAt(i);
                if (currentSample.Class == "Acer")
                {
                    mA += currenValue;
                    sA += currenValue * currenValue;
                }
                else
                {
                    mB += currenValue;
                    sB += currenValue * currenValue;
                }
            }
            int countA = samples.Where(x => x.Class == "Acer").Count();
            int countB = samples.Where(x => x.Class == "Quercus").Count();
            mA /= countA;
            mB /= countB;
            sA = sA / countA - mA * mA;
            sB = sB / countB - mB * mB;
            double sASqrt = Math.Sqrt(sA);
            double sBSqrt = Math.Sqrt(sB);
            double res = Math.Abs(mA - mB) / sASqrt + sBSqrt;
            return res;
        }

    }

    public class ManyDimensionsFeaturesSelectingRule : IFeaturesSelectingRule
    {
        public List<int> Select(List<Sample> samples)
        {
            FeatureSelector3 selector = new FeatureSelector3(samples);
            return selector.HandleManyDimensions(numOfFeatures);
        }
    }
}
