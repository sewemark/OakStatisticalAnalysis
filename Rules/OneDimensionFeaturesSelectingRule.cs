﻿using OakStatisticalAnalysis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OakStatisticalAnalysis.Rules
{
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
                if (currentSample.Class == SampleInfo.ClassNames[0])
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
            int countA = samples.Where(x => x.Class == SampleInfo.ClassNames[0]).Count();
            int countB = samples.Where(x => x.Class == SampleInfo.ClassNames[0]).Count();
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
}
