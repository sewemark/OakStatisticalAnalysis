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
        private Matrix<double> classAFeatures;
        private Matrix<double> classBFeatures;
        private List<double> modA;
        private List<double> modB;
        private List<Matrix<double>> projetctedClassFateures;
        private List<List<double>> mods;
        private List<Matrix> normalizedMods;
        public TwoDimensionsFisherCalculator(int _numOfFeatures, List<Sample> samples)
        {
            numOfFeatures = _numOfFeatures;
            this.samples = samples;
            projetctedClassFateures = new List<Matrix<double>>();
            mods = new List<List<double>>();
            normalizedMods = new List<Matrix>();
        }

        public double Calc(int[] currentTestingFeatures)
        {
            projetctedClassFateures.Clear();
            InitMatrix();
            var lookup = ProjectFeatureSpace(currentTestingFeatures);
            for(int i=0; i<lookup.Count;i++)
            {
                var values =lookup.ElementAt(i).Value;
                var matrix = DenseMatrix.OfArray(values.Select(x => x.ToArray()).ToArray().To2DArray<double>());
                projetctedClassFateures.Add(matrix);
            }
            projetctedClassFateures.ForEach(x =>
            {
                var currentMod = x.ColumnSums().Select(y => y / x.RowCount);
                mods.Add(currentMod.ToList());
            });

            NormalizeMods();
            Matrix classABeforeTranspose = DenseMatrix.OfArray(new double[numOfFeatures, 176]);
            classAFeatures.Subtract(modAMatrix, classABeforeTranspose);
            Matrix<double> classBBeforeTranspose = DenseMatrix.OfArray(new double[numOfFeatures, 608]);
            classBFeatures.Subtract(modBMatrix, classBBeforeTranspose);


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

        private void InitMatrix()
        {
            classAFeatures = DenseMatrix.OfArray(new double[numOfFeatures, SampleInfo.Get().ClassElements[0]]);
            classBFeatures = DenseMatrix.OfArray(new double[numOfFeatures, SampleInfo.Get().ClassElements[0]]);
            modA = new List<double>();
            modB = new List<double>();
        }

        public void NormalizeMods()
        {
            for(int i =0;i<mods.Count;i++)
            {
                var x = mods[i];
                var resutl = Enumerable.Repeat(x, projetctedClassFateures[i].RowCount);
                var normalized = DenseMatrix.OfArray(resutl.To2DArray());
                normalizedMods.Add(normalized);
            }
        }

        public Dictionary<string, IEnumerable<IEnumerable<double>>> ProjectFeatureSpace(int[] currentTestingFeatures)
        {
            return samples
                        .GroupBy(x => x.Class)
                        .ToDictionary(y => y.Key, y => y
                          .Select(x => x.Features
                              .Where((m, index) => currentTestingFeatures
                                      .Contains(index))));
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
            fisherCalculator = new TwoDimensionsFisherCalculator(numOfFeatures, samples);
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
