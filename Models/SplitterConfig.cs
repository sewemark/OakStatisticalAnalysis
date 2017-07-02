using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OakStatisticalAnalysis
{
    public class SplitterConfig
    {
        public double Ratio { get; set; }
        public int BootstrapBags { get; set; }
        public int KParam { get; set; }
        public int CrossValidationKParam { get; set; }
    }
    public class ClassifierConfig
    {
        public int KParam { get; set; }
    }
}
