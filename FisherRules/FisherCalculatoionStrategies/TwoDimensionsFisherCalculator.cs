using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using OakStatisticalAnalysis.Models;
using OakStatisticalAnalysis.Utils;
using System.Collections.Generic;
using System.Linq;
using System;

namespace OakStatisticalAnalysis.Rules.FisherCalculatoionStrategies
{
    public class TwoDimensionsFisherCalculator
    {
        private int numOfFeatures;
        private List<Sample> samples;
        private List<Matrix<double>> projetctedClassFateures;
        private List<List<double>> mods;
        private List<Matrix<double>> normalizedMods;
        private List<Matrix<double>> subtractedMatrix;
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
            normalizedMods = new List<Matrix<double>>();
            subtractedMatrix = new List<Matrix<double>>();
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
                var currentMod = x.RowSums().Select(y => y / x.ColumnCount);
                mods.Add(currentMod.ToList());
            });
        }

        private double CalculateFisherUpper()
        {
            double fisherUpperRes = 0;
            List<double> fisherUpper = mods.Aggregate((x, y) => {
                return y.MinusTwoList(x).ToList();
            });

            fisherUpperRes = fisherUpper.Select(x => Math.Pow(x, 2)).Sum();
            return Math.Sqrt(fisherUpperRes);
        }

        private double CalculateFisherDown()
        {
            double det = 0;
            for(int i =0;i<transposed.Count;i++)
            {
                var tt = subtractedMatrix[i].Transpose();
                var result = new DenseMatrix(subtractedMatrix[i].RowCount, tt.ColumnCount);
                subtractedMatrix[i].Multiply(tt, result);
                det += result.Determinant();
            }
            return det;
        }

     
        public void NormalizeMods()
        {
            for (int i = 0; i < mods.Count; i++)
            {
                var x = mods[i];
                var resutl = Enumerable.Repeat(x, projetctedClassFateures[i].ColumnCount);
                var normalized = DenseMatrix.OfArray(resutl.To2DArray());
                normalizedMods.Add(normalized.Transpose());
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
                projetctedClassFateures.Add(matrix.Transpose());
            }
        }

        public void SubTractMatrix()
        {
            for (int i = 0; i < mods.Count; i++)
            {
                Matrix matrixBeforeTranspose = DenseMatrix.OfArray(new double[ numOfFeatures, projetctedClassFateures[i].ColumnCount]);
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
