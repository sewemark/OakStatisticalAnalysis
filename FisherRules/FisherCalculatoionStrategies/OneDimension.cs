using OakStatisticalAnalysis.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OakStatisticalAnalysis.Rules.FisherCalculatoionStrategies
{
    public interface IFisherCalculator
    {
       void UpdateSamples(List<Sample> samples);
    }

    public interface IOneDimensionsFisherCalculator: IFisherCalculator
    {
        double ComputeFisherFor1D(int index);
    }

    public  class OneDimensionsFisherCalculator: IOneDimensionsFisherCalculator
    {
        private List<Sample> samples;

        public double ComputeFisherFor1D(int index)
        {
            double mA = 0, mB = 0, sA = 0, sB = 0;
            for (int i = 0; i < samples.Count; i++)
            {
                double currenValue = (double)samples.ElementAt(i).Features.ElementAt(index);
                var currentSample = samples.ElementAt(i);
                if (currentSample.Class == SampleInfo.Get().ClassNames[0])
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

            int countA = samples.Where(x => x.Class == SampleInfo.Get().ClassNames[0]).Count();
            int countB = samples.Where(x => x.Class == SampleInfo.Get().ClassNames[0]).Count();
            mA /= countA;
            mB /= countB;
            sA = sA / countA - mA * mA;
            sB = sB / countB - mB * mB;
            double sASqrt = Math.Sqrt(sA);
            double sBSqrt = Math.Sqrt(sB);
            double res = Math.Abs(mA - mB) / sASqrt + sBSqrt;
            return res;
        }

        public void UpdateSamples(List<Sample> samples)
        {
            this.samples = samples;
        }
    }
}
