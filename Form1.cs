using OakStatisticalAnalysis.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace OakStatisticalAnalysis
{
    public partial class OakStatisticalAnalisysisForm : Form
    {
        private string[] databaseContent;
        private IDatabaseContentParser dbContentParser;
        private IFeatureExtractor featureExtractor;
        private List<Sample> parsedDatabaseContent;
        private List<int> featuresUI = new List<int>();
        public OakStatisticalAnalisysisForm()
        {
            InitializeComponent();
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
        
        private void ExtractFeatures(int numOfFeatures)
        {
            featureExtractor = new FeatureExtractor(parsedDatabaseContent);
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
