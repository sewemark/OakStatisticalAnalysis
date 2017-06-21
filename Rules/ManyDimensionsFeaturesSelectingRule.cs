using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using OakStatisticalAnalysis.Models;
using OakStatisticalAnalysis.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OakStatisticalAnalysis.Rules
{
    public class TwoDimensionsFisherCalculator
    {
        private int numOfFeatures;
        private List<Sample> samples;
      
        public TwoDimensionsFisherCalculator(int _numOfFeatures, List<Sample> samples)
        {
            numOfFeatures = _numOfFeatures;
            this.samples = samples;
        }

        public double Calc(int[] permArray)
        {
            Matrix<double> classAFeatures = DenseMatrix.OfArray(new double[numOfFeatures, SampleInfo.]);
            Matrix<double> classBFeatures = DenseMatrix.OfArray(new double[numOfFeatures, 608]);
            List<double> modA = new List<double>();
            List<double> modB = new List<double>();
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
                double mATruncate = (mA / 176);
                modA.Add(mATruncate);
                double mBTruncate = mB / 608;
                modB.Add(mBTruncate);
            }
            Matrix modAMatrix = DenseMatrix.OfArray(new double[numOfFeatures, 176]);
            for (int i = 0; i < 176; i++)
            {
                for (int k = 0; k < numOfFeatures; k++)
                {
                    modAMatrix[k, i] = modA.ElementAt(k);
                }
            }
            Matrix modBMatrix = DenseMatrix.OfArray(new double[numOfFeatures, 608]);
            for (int i = 0; i < 608; i++)
            {
                for (int z = 0; z < numOfFeatures; z++)
                {
                    modBMatrix[z, i] = modB.ElementAt(z);
                }
            }
            Matrix classABeforeTranspose = DenseMatrix.OfArray(new double[numOfFeatures, 176]);
            classAFeatures.Subtract(modAMatrix, classABeforeTranspose);
            // Matrix test = this.computeCovarianceMatrix(classABeforeTranspose.getArray());
            Matrix<double> classBBeforeTranspose = DenseMatrix.OfArray(new double[numOfFeatures, 608]);
            classBFeatures.Subtract(modBMatrix, classBBeforeTranspose);
            // BigMatrix m matrix = new BigMatrix();


            Matrix<double> classAS = classABeforeTranspose.ComputeCovarianceMatrix();
            Matrix<double> classBS = classBBeforeTranspose.ComputeCovarianceMatrix();

            Matrix<double> resultTODeterminant = classAS.Add(classBS);
            double fisherUpperRes = 0;
            List<double> fisherUpper = modA.MinusTwoList(modB).ToList();
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
    }

    public class ManyDimensionsFeaturesSelectingRule : IFeaturesSelectingRule
    {
        private int numOfFeatures;
        private List<Sample> samples;
        private TwoDimensionsFisherCalculator fisherCalculator;
        public ManyDimensionsFeaturesSelectingRule(int _numOfFeatures)
        {
            numOfFeatures = _numOfFeatures;
          
        }

        public List<int> Select(List<Sample> _samples)
        {
            samples = _samples;
            fisherCalculator = new TwoDimensionsFisherCalculator(numOfFeatures,samples);
            return this.HandleManyDimensions(numOfFeatures);
        }

        public List<int> HandleManyDimensions(int _dimensions)
        {
            int dimensions = _dimensions;
            var permutations = Permutations.Get(dimensions, samples.ElementAt(0).Features.Count());
            int permIndex = 0;
            double LD = 0;
            for (int currentPermutation = 0; currentPermutation < permutations.Count; currentPermutation++)
            {
                var permArray = permutations.ElementAt(currentPermutation);
                double tmpLD = fisherCalculator.Calc(permArray);
                if (tmpLD > LD)
                {
                    LD = tmpLD;
                    permIndex = currentPermutation;
                }
            }
            return permutations.ElementAt(permIndex).ToList();
        }
    
    }
}
