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
            Features = new List<decimal>();
        }

        public List<decimal> Features { get; set; }
        public string Class { get; set; }
        public string Label { get; set; }
    }
}
