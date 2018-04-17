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
        private IClassifierFactory factory;
        private ITestClassifierFactory testClassifierFactory;
        private ITrainTestSetsSplitterFactory trainTestSetsSplitterFactory;
        private ISFSFeatureSelector sfsFeatureSelector;
        private List<Sample> parsedDatabaseContent;
        private List<int> featuresUI = new List<int>();
        private TrainTestStruct trainTestStruct;
        private string[] databaseContent;

        public OakStatisticalAnalisysisForm(IDatabaseContentParser _dbContentParser, 
                                            IFeaturesSelectingRules _featureSelectingRules,
                                            IFeatureSelector _featureExtractor,
                                            IClassifierFactory _classifierFactory,
                                            ITestClassifierFactory _testClassifierFactory,
                                            ITrainTestSetsSplitterFactory _trainTestSetsSplitterFactory,
                                            ISFSFeatureSelector _sfsFeatureSelector)
        {
            this.dbContentParser = _dbContentParser;
            this.featureSelectingRules = _featureSelectingRules;
            this.featureExtractor = _featureExtractor;
            this.factory = _classifierFactory;
            this.trainTestSetsSplitterFactory = _trainTestSetsSplitterFactory;
            this.testClassifierFactory = _testClassifierFactory;
            this.sfsFeatureSelector = _sfsFeatureSelector;
            InitializeComponent();
        }

        private void ReadFromFileButtonClick(object sender, EventArgs e)
        {
            ReadFromFile();
            ParseContent();
        }

        private void ParseContent()
        {
            parsedDatabaseContent = dbContentParser.ParseContent(databaseContent);
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
            featuresUI = this.featureExtractor.Select(parsedDatabaseContent, numOfFeatures);
        }

        private void ExtractFeaturesSFS(int numOfFeatures)
        {
            featuresUI = this.sfsFeatureSelector.Select(parsedDatabaseContent, numOfFeatures);
        }

        private void UpdateUI()
        {
            parsedDatabaseContent.ForEach(x =>
            {
                x.Features = x.Features.Where((y, index) => featuresUI.Contains(index)).Select(y => y).ToList();
            });
           featureExtractionResultLabel.Text =  " " + String.Join(", ", featuresUI);
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
            var selectedRadioButton = this.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
            var splitter = this.trainTestSetsSplitterFactory.Get(selectedRadioButton.Text);
            trainTestStruct = splitter.Split(parsedDatabaseContent,GetCurrentConfig());
            currentClassifier = factory.Select(selectClassifierComboBox.SelectedItem.ToString());
            currentClassifier.Train(trainTestStruct.TrainingSets, GetCurrentClassifierConfig());
        }

        private void ExecuteTestButtonClick(object sender, EventArgs e)
        {
            var selectedRadioButton = this.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
            var testClassifier = testClassifierFactory.Select(selectClassifierComboBox.SelectedItem.ToString(), selectedRadioButton.Text);
            var result = testClassifier.Test(currentClassifier,trainTestStruct.TestSet);
            classificationResultLabel.Text += 
                             "\n" + selectClassifierComboBox.SelectedItem.ToString() + " " + result.ToString();

        }

        public SplitterConfig GetCurrentConfig()
        {
            return new SplitterConfig()
            {
                Ratio = Convert.ToDouble(trainTestRatioTextBox.Text),
                BootstrapBags = Convert.ToInt32(bootstrapBagsNumberTextBox.Text),
                KParam = Convert.ToInt32(kParamTextBox.Text),
                CrossValidationKParam = Convert.ToInt32(crossvalidationNumOfPartsTextBox.Text)
            };
        }

        public ClassifierConfig GetCurrentClassifierConfig()
        {
            return new ClassifierConfig()
            {
                KParam = Convert.ToInt32(kParamTextBox.Text),
            };
        }

        private void OakStatisticalAnalisysisForm_Load(object sender, EventArgs e)
        {

        }
    }
}
