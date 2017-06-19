using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OakStatisticalAnalysis.Models
{
    public class Sample
    {
        public Sample()
        {
            Features = new List<double>();
        }

        public List<double> Features { get; set; }
        public string Class { get; set; }
        public string Label { get; set; }
        public int CentoridNumber { get; set; }
    }
}
