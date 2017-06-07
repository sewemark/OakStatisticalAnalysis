using OakStatisticalAnalysis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OakStatisticalAnalysis
{
    public interface IFeatureExtractor
    {
        List<int> Extract(int numOfFeatures);
    }

    public class FeatureExtractor : IFeatureExtractor
    {
        List<Sample> samples;
        public FeatureExtractor(List<Sample> _samples)
        {
            samples = _samples;
        }
        public List<int> Extract(int numOfFeatures)
        {
            if(numOfFeatures == 1)
            {
                return HandleOneDimension();
            }
            else
            {
                return HandleManyDimensions();
            }
        }

        private List<int> HandleManyDimensions()
        {
            return new List<int>();
        }

        private List<int> HandleOneDimension()
        {
            double FLD = 0, tmp;
            int max_ind = -1;
            for (int i = 0; i < samples.ElementAt(0).Features.Count; i++)
            {
                if ((tmp = computeFisherLD(i)) > FLD)
                {
                    FLD = tmp;
                    max_ind = i;
                }
            }
            return new List<int>() { max_ind };
        }

        private double computeFisherLD(int index)
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
            sB = sB /countB - mB * mB;
            double sASqrt = Math.Sqrt(sA);
            double sBSqrt = Math.Sqrt(sB);
            double res = Math.Abs(mA - mB) / sASqrt + sBSqrt;
            return res;
        }
    }

   

}
