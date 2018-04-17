using System.Collections.Generic;
using System.Linq;

namespace OakStatisticalAnalysis
{
    public class Centroid
    {
        public int Number;
        public double[] Mod;
        public double[] ModOccurencies;
        public List<string> ClassLables;
        public int AcerNum = 0;
        public int QNum = 0;

        public Centroid(int _number, int numOfFeatures)
        {
            Number = _number;
            InitValues(numOfFeatures);
        }
        public void InitValues(int numOfFeatures)
        {
            Mod = Enumerable.Repeat<double>(0, numOfFeatures).ToArray();
            ModOccurencies = Enumerable.Repeat<double>(0, numOfFeatures).ToArray();
            ClassLables = new List<string>();
        }
        public void ZippValues()
        {
            Mod = Mod.Zip(ModOccurencies, (x, y) =>
            {
                return x / y;
            }).ToArray();

        }
    }
}
