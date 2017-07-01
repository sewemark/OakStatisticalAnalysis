using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OakStatisticalAnalysis.Utils
{
    public class Permutations
    {
       

        public static List<int[]> Get(int size,int numOfDimensions)
        {
            int [] featuresCount =  Enumerable.Range(0, numOfDimensions).ToArray();
            if (size < 1)
            {
                return new List<int[]>();
            }

            int itemsPoolCount = featuresCount.Count();

            List<int[]> permutations = new List<int[]>();
            for (int i = 0; i < Math.Pow(itemsPoolCount, size); i++)
            {
                int[] permutation = new int[size];
                for (int j = 0; j < size; j++)
                {
                    // Pick the appropriate item from the item pool given j and i
                    int itemPoolIndex = (int)Math.Floor((double)(i % (int)Math.Pow(itemsPoolCount, j + 1)) / (int)Math.Pow(itemsPoolCount, j));
                    permutation[j] = featuresCount[itemPoolIndex];
                }
                if (permutation.Count() > 1 && permutation.Distinct().Count() < permutation.Count())
                {
                    
                }
                else
                {
                    if (permutations.Exists(x => x.Except(permutation).Count() == 0))
                    { }
                    else
                    {
                        permutations.Add(permutation);
                    }
                }
            }
            return permutations;
        }

        public static bool Duplicates(int[] x, int numElementsInX)
        {
            HashSet<int> set = new HashSet<int>();
            for (int i = 0; i < numElementsInX; ++i)
            {
                if (set.Contains(x[i]))
                {
                    return true;
                }
                else
                {
                    set.Add(x[i]);
                }
            }
            return false;
        }

    }
}
