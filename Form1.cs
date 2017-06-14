using OakStatisticalAnalysis.Models;
using OakStatisticalAnalysis.Rules;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace OakStatisticalAnalysis
{
    public partial class OakStatisticalAnalisysisForm : Form
    {
        private IDatabaseContentParser dbContentParser;
        private IFeatureSelector featureExtractor;
        private IFeaturesSelectingRules featureSelectingRules;
        private List<Sample> parsedDatabaseContent;
        private List<int> featuresUI = new List<int>();
        private string[] databaseContent;

        public OakStatisticalAnalisysisForm()
        {
            InitializeComponent();
            InitDependencies();
        }

        public void InitDependencies()
        {
            featureSelectingRules = new FeaturesSelectingRules(RulesFactory.GetRules());
        }

        private void ReadFromFileButtonClick(object sender, EventArgs e)
        {
            ReadFromFile();
            ParseContent();
        }

        private void ParseContent()
        {
            dbContentParser = new DatabaseContentParser(databaseContent);
            parsedDatabaseContent = dbContentParser.ParseContent();
        }

        private void ExtractFeaturesButtonClick(object sender, EventArgs e)
        {
            ExtractFeatures((int)featureNumberComboBox.SelectedIndex + 1);
            UpdateUI();
        }

        private void ExtractFeaturesSFSButtonClick(object sender, EventArgs e)
        {
            ExtractFeaturesSFS((int)featureNumberComboBox.SelectedIndex + 1);
            UpdateUI();
        }

        private void ExtractFeatures(int numOfFeatures)
        {
            featureExtractor = new FeatureSelector(parsedDatabaseContent, featureSelectingRules);
            featuresUI = featureExtractor.Extract(numOfFeatures);
        }

        private void ExtractFeaturesSFS(int numOfFeatures)
        {
            featureExtractor = new SFSFeatureSelector(parsedDatabaseContent, featureSelectingRules);
            featuresUI = featureExtractor.Extract(numOfFeatures);
        }

        private void UpdateUI()
        {
            featureNumberLabel.Text += String.Join(", ", featuresUI);
        }

        private void ReadFromFile()
        {
            DialogResult result = selectDatabaseFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string file = selectDatabaseFileDialog.FileName;
                try
                {
                    databaseContent = File.ReadAllLines(file);
                }
                catch (IOException ioException)
                {
                    MessageBox.Show(ioException.Message.ToString());
                }
            }
        }
    }
}
