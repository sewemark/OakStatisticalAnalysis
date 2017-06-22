using System;
using System.Collections.Generic;
using System.Linq;

namespace OakStatisticalAnalysis.Models
{
    public class SampleInfo
    {
        public  string[] ClassNames;
        public int[] ClassElements;
        private static SampleInfo sampleInfo;
        public  static SampleInfo Get()
        {
            if (sampleInfo == null)
                throw new NullReferenceException();

            return sampleInfo;
        }

        public  static void Init(List<Sample> _samples)
        {
            sampleInfo = new SampleInfo(_samples);
        }

        private SampleInfo(List<Sample> samples)
        {
            var ordered = samples
                .OrderByDescending(d => d.Class);

            ClassElements = ordered
                            .GroupBy(x => x.Class)
                            .Select(x => x.Count()).ToArray();
            ClassNames = ordered
                            .Select(x => x.Class).ToArray();
        }
    }
}
