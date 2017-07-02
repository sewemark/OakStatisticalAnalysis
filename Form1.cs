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
            parsedDatabaseContent.ForEach(x => {
                x.Features = x.Features.Where((y, index) => featuresUI.Contains(index)).Select(y => y).ToList();
                //x.Features.Clear();
               //x.Features.AddRange(newFeatures);
            });
           featureExtractionResultLabel.Text +=  " "+ String.Join(", ", featuresUI);

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
            var selectedRadioButton = this.Controls.OfType<RadioButton>()
                                          .FirstOrDefault(r => r.Checked);
            var splitter = TrainTestSetsSplitterFactory.Get(selectedRadioButton.Text);
            trainTestStruct = splitter.Split(parsedDatabaseContent,GetCurrentConfig());
            ClassifierFactory factory = new ClassifierFactory();
            currentClassifier = factory.Select(selectClassifierComboBox.SelectedItem.ToString());
            currentClassifier.Train(trainTestStruct.TrainingSets);
        }

        private void ExecuteTestButtonClick(object sender, EventArgs e)
        {
            var selectedRadioButton = this.Controls.OfType<RadioButton>()
                                        .FirstOrDefault(r => r.Checked);
            TestClassifierFactory factory = new TestClassifierFactory();
            var testClassifier = factory.Select(selectClassifierComboBox.SelectedItem.ToString(), selectedRadioButton.Text);
            var result = testClassifier.Test(currentClassifier,trainTestStruct.TestSet);
            classificationResultLabel.Text += 
                "\n" + selectClassifierComboBox.SelectedItem.ToString() + " " + result.ToString();

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void selectClassifierComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public SpitterConfig GetCurrentConfig()
        {
            return new SpitterConfig()
            {
                Ratio = Convert.ToDouble(trainTestRatioTextBox.Text),
                BootstrapBags = Convert.ToInt32(bootstrapBagsNumberTextBox.Text),
                KParam = Convert.ToInt32(kParamTextBox.Text),
                CrossValidationKParam = Convert.ToInt32(crossvalidationNumOfPartsTextBox.Text)
            };
        }
    }

    public class SpitterConfig
    {
        public double Ratio { get; set; }
        public int BootstrapBags { get; set; }
        public int KParam { get; set; }
        public int CrossValidationKParam { get; set; }
    }
}
