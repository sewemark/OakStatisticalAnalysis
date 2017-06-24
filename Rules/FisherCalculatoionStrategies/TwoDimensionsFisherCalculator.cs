using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using OakStatisticalAnalysis.Models;
using OakStatisticalAnalysis.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OakStatisticalAnalysis.Rules.FisherCalculatoionStrategies
{
    public class TwoDimensionsFisherCalculator
    {
        private int numOfFeatures;
        private List<Sample> samples;
        private List<Matrix<double>> projetctedClassFateures;
        private List<List<double>> mods;
        private List<Matrix> normalizedMods;
        private List<Matrix> subtractedMatrix;
        private List<Matrix<double>> convariances;
        private List<Matrix<double>> transposed;
        private Dictionary<string, IEnumerable<IEnumerable<double>>> lookup;

        public TwoDimensionsFisherCalculator(int _numOfFeatures, List<Sample> _samples)
        {
            samples = _samples;
            numOfFeatures = _numOfFeatures;

        }
        private void Init()
        {
            projetctedClassFateures = new List<Matrix<double>>();
            mods = new List<List<double>>();
            normalizedMods = new List<Matrix>();
            subtractedMatrix = new List<Matrix>();
            convariances = new List<Matrix<double>>();
            transposed = new List<Matrix<double>>();
        }
        public double Calc(int[] currentTestingFeatures)
        {
            Init();
            ProjectFeatureSpace(currentTestingFeatures);
            CopyProjectedLookupToMatrixes();
            CalculateProjectedMeans();
            NormalizeMods();
            SubTractMatrix();
            CalculateTransposed();
            return CalculateFisher();
        }

        private double CalculateFisher()
        {
            var fisherDownResult = CalculateFisherDown();
            var fisherUpper = CalculateFisherUpper();

            return fisherDownResult == 0 ? 0 : fisherUpper / fisherDownResult;
        }

        private void CalculateProjectedMeans()
        {
            projetctedClassFateures.ForEach(x =>
            {
                var currentMod = x.ColumnSums().Select(y => y / x.RowCount);
                mods.Add(currentMod.ToList());
            });
        }

        private double CalculateFisherUpper()
        {
            double fisherUpperRes = 0;
            List<double> fisherUpper = mods.Aggregate((x, y) => {
                return x.MinusTwoList(y).ToList();
            });

            fisherUpperRes = fisherUpper.Select(x => Math.Pow(x, 2)).Sum();
            return Math.Sqrt(fisherUpperRes);
        }

        private double CalculateFisherDown()
        {
            double det = 0;
            for(int i =0;i<transposed.Count;i++)
            {
               var result = transposed[i] * subtractedMatrix[i];
                det += result.Determinant();
            }
            return det;
        }

     
        public void NormalizeMods()
        {
            for (int i = 0; i < mods.Count; i++)
            {
                var x = mods[i];
                var resutl = Enumerable.Repeat(x, projetctedClassFateures[i].RowCount);
                var normalized = DenseMatrix.OfArray(resutl.To2DArray());
                normalizedMods.Add(normalized);
            }
        }

        public void ProjectFeatureSpace(int[] currentTestingFeatures)
        {
            lookup = samples
                        .GroupBy(x => x.Class)
                        .ToDictionary(y => y.Key, y => y
                          .Select(x => x.Features
                              .Where((m, index) => currentTestingFeatures
                                      .Contains(index))));
        }

        public void CopyProjectedLookupToMatrixes()
        {
            for (int i = 0; i < lookup.Count; i++)
            {
                var values = lookup.ElementAt(i).Value;
                var matrix = DenseMatrix.OfArray(values.Select(x => x.ToArray()).ToArray().To2DArray<double>());
                projetctedClassFateures.Add(matrix);
            }
        }

        public void SubTractMatrix()
        {
            for (int i = 0; i < mods.Count; i++)
            {
                Matrix matrixBeforeTranspose = DenseMatrix.OfArray(new double[ projetctedClassFateures[i].RowCount, numOfFeatures]);
                projetctedClassFateures[i].Subtract(normalizedMods[i], matrixBeforeTranspose);
                subtractedMatrix.Add(matrixBeforeTranspose);
            }
        }

        public void CalculateTransposed()
        {
            subtractedMatrix.ForEach(x =>
            {
                var result = x.Transpose();
                transposed.Add(result);
            });
        }

    }
}
