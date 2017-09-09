using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OakStatisticalAnalysis.Utils
{
    public class Permutations
    {

       public static IEnumerable<IEnumerable<T>> GetPermutations2<T>(IEnumerable<T> items, int count)
        {
            int i = 0;
            foreach (var item in items)
            {
                if (count == 1)
                    yield return new T[] { item };
                else
                {
                    foreach (var result in GetPermutations2(items.Skip(i + 1), count - 1))
                        yield return new T[] { item }.Concat(result);
                }

                ++i;
            }
        }
        public static List<int[]> Get(int size,int numOfDimensions)
        {
            int [] featuresCount =  Enumerable.Range(0, numOfDimensions).ToArray();
            if (size < 1)
            {
                return new List<int[]>();
            }

            int itemsPoolCount = featuresCount.Count();

            List<int[]> permutations = new List<int[]>();


            var permutationsNumber = GetPermutatinNumber(size, numOfDimensions);
            for (int i = 0; i < permutationsNumber; i++)
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
                    {
                    }
                    else
                    {
                        permutations.Add(permutation);
                    }
                }
            }
            return permutations;
        }

        private  static int GetPermutatinNumber(int size, int numOfDimensions)
        {
            int res = 1;
            for(int i=0;i<size;i++)
            {
                res *= (numOfDimensions - i);
            }

            return res;
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

        private static int Factory(int n)
        {
            int result = 1;
            for (int i = 1; i <= n; i++)
            {
                result *= i;
            }
            return result;
        }
    }
}
