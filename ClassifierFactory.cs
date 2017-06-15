﻿using System;
using System.Collections.Generic;

namespace OakStatisticalAnalysis
{
    public class ClassifierFactory
    {
        private Dictionary<string, IClassifier> classifierSelectingRules
            = new Dictionary<string, IClassifier>();
        public ClassifierFactory()
        {
            classifierSelectingRules.Add("NN", new NNClassifier());
        }
        public IClassifier Select(string classifierName)
        {
            return classifierSelectingRules[classifierName];
        }
    }
  
}