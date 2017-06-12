using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using OakStatisticalAnalysis.Models;
using OakStatisticalAnalysis.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OakStatisticalAnalysis
{
    public class FeatureSelector
    {
        private List<Sample> samples;
        int dimensions;
        public  FeatureSelector(List<Sample> _samples)
        {
            samples = _samples;
        }

        public List<int> HandleManyDimensions(int dimensions)
        {
            this.dimensions = dimensions;
            var permutations =Permutations.get(dimensions,samples.ElementAt(0).Features.Count());
            int permIndex = 0;
            double LD = 0;
            for (int currentPermutation =0; currentPermutation < permutations.Count; currentPermutation++)
            {
                var permArray = permutations.ElementAt(currentPermutation);
                double tmpLD = Calc(permArray);
                if (tmpLD > LD)
                {
                    LD = tmpLD;
                    permIndex = currentPermutation;
                }
            }
            return permutations.ElementAt(permIndex).ToList();
        }

        private double Calc(int [] permArray)
        {
            Matrix<double> classAFeatures = DenseMatrix.OfArray(new double[dimensions, 176]);
            Matrix<double> classBFeatures = DenseMatrix.OfArray(new double[dimensions, 608]);
            List<Double> modA = new List<double>();
            List<Double> modB = new List<Double>();
            for (int featrureIndex = 0; featrureIndex < permArray.Count(); featrureIndex++)
            {

                double mA = 0, mB = 0;

                for (int j = 0; j < 176; j++)
                {
                    double tmp = (double)samples.ElementAt(j).Features.ElementAt(permArray[featrureIndex]);
                    mA += tmp;
                    classAFeatures[featrureIndex, j] = tmp;
                }
                for (int j = 176; j < 784; j++)
                {
                        double tmp = (double)samples.ElementAt(j).Features.ElementAt(permArray[featrureIndex]);
                    mB += tmp;
                    classBFeatures[featrureIndex, j - 176] = tmp;
                }
                Double mATruncate = (mA / 176);
                modA.Add(mATruncate);
                Double mBTruncate = mB / 608;
                modB.Add(mBTruncate);
            }
            Matrix modAMatrix = DenseMatrix.OfArray(new double[dimensions, 176]);
            for (int i = 0; i < 176; i++)
            {
                for (int k = 0; k < dimensions; k++)
                {
                    modAMatrix[k, i] = modA.ElementAt(k);
                }
            }
            Matrix modBMatrix = DenseMatrix.OfArray(new double[dimensions, 608]);
            for (int i = 0; i < 608; i++)
            {
                for (int z = 0; z < dimensions; z++)
                {
                    modBMatrix[z, i] = modB.ElementAt(z);
                }
            }
            Matrix classABeforeTranspose = DenseMatrix.OfArray(new double[dimensions, 176]);
            classAFeatures.Subtract(modAMatrix, classABeforeTranspose);
            // Matrix test = this.computeCovarianceMatrix(classABeforeTranspose.getArray());
            Matrix<double> classBBeforeTranspose = DenseMatrix.OfArray(new double[dimensions, 608]);
            classBFeatures.Subtract(modBMatrix, classBBeforeTranspose);
            // BigMatrix m matrix = new BigMatrix();


            Matrix<double> classAS = this.computeCovarianceMatrix(classABeforeTranspose);
            Matrix<double> classBS = this.computeCovarianceMatrix(classBBeforeTranspose);

            Matrix<double> resultTODeterminant = classAS.Add(classBS);
            double fisherUpperRes = 0;
            List<double> fisherUpper = MinusTwoList(modA, modB).ToList();
            for (int i = 0; i < fisherUpper.Count(); i++)
            {
                fisherUpperRes += Math.Pow(fisherUpper.ElementAt(i), 2);
              
            }
            double fiherUpperResult = Math.Sqrt(fisherUpperRes);
            double fisherDownResult = resultTODeterminant.Determinant();
            if (fisherDownResult == 0)
                return 0;
            double finalRes = fiherUpperResult / fisherDownResult;

            return finalRes;
        }
        public IEnumerable<double> MinusTwoList(List<double> first, List<double> second)
        {
            for(int i = 0; i < first.Count; i++)
            {
                yield return first.ElementAt(i) - second.ElementAt(i);
            }
        }
        private Matrix<double> computeCovarianceMatrix(Matrix<double> matrix)
        {


            Matrix<double> MT = matrix.Transpose();
            Matrix<double> C = matrix.Multiply(MT);
            return C;
        }
    }
}
