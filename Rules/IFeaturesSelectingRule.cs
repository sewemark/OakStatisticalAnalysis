using OakStatisticalAnalysis.Models;
using System.Collections.Generic;

namespace OakStatisticalAnalysis.Rules
{
    public interface IFeaturesSelectingRule
    {
        List<int> Select(List<Sample> samples);
    }
}
