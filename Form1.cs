using OakStatisticalAnalysis.Models;
using OakStatisticalAnalysis.Rules;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace OakStatisticalAnalysis
{
    public partial class OakStatisticalAnalisysisForm : Form
    {
        private IDatabaseContentParser dbContentParser;
        private IFeatureSelector featureExtractor;
        private IFeaturesSelectingRules featureSelectingRules;
        private IClassifier currentClassifier;

        private List<Sample> parsedDatabaseContent;
        private List<int> featuresUI = new List<int>();
        private TrainTestStruct trainTestStruct;
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
            SampleInfo.Init(parsedDatabaseContent);
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
            featuresUI = featureExtractor.Select(numOfFeatures);
        }

        private void ExtractFeaturesSFS(int numOfFeatures)
        {
            featureExtractor = new SFSFeatureSelector(parsedDatabaseContent, featureSelectingRules);
            featuresUI = featureExtractor.Select(numOfFeatures);
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

        private void TrainButtonClick(object sender, EventArgs e)
        {
            BasicTrainTestSetsSplitter splitter = new BasicTrainTestSetsSplitter();
            double ration = Convert.ToDouble(trainTestRatioTextBox.Text);
            trainTestStruct =  splitter.Split(parsedDatabaseContent, ration);
            ClassifierFactory factory = new ClassifierFactory();
            var selectedRadioButton =this.Controls.OfType<RadioButton>()
                                        .FirstOrDefault(r => r.Checked);
            TrainTestSetsSplitterFactory.Get(selectedRadioButton.Text);
            currentClassifier = factory.Select(selectClassifierComboBox.SelectedItem.ToString());
            currentClassifier.Train(trainTestStruct.TrainingSet);
        }

        private void ExecuteTestButtonClick(object sender, EventArgs e)
        {
            TestClassifierFactory factory = new TestClassifierFactory();
            var testClassifier = factory.Select(selectClassifierComboBox.SelectedItem.ToString());
            testClassifier.Test(currentClassifier,trainTestStruct.TestSet);

        }

        private void BootstrapTrainButtonClick(object sender, EventArgs e)
        {
            int k = Convert.ToInt32(bootstrapBagsNumberTextBox.Text);
            double percentage = Convert.ToDouble(bootstrapPercentageTextBox.Text);
             BasicTrainTestSetsSplitter splitter = new BasicTrainTestSetsSplitter();
            double ration = Convert.ToDouble(trainTestRatioTextBox.Text);
            trainTestStruct = splitter.Split(parsedDatabaseContent, ration);
            BootstrapTrainTestSetsSplitter bootstrap = new BootstrapTrainTestSetsSplitter(k, 30, percentage,parsedDatabaseContent);
            
        }
    }
}
