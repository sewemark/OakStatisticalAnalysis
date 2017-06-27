namespace OakStatisticalAnalysis
{
    partial class OakStatisticalAnalisysisForm
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Wymagana metoda obsługi projektanta — nie należy modyfikować 
        /// zawartość tej metody z edytorem kodu.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OakStatisticalAnalisysisForm));
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.readDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.readFromFile = new System.Windows.Forms.ToolStripMenuItem();
            this.selectDatabaseFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.extractFeaturesSFSButton = new System.Windows.Forms.Button();
            this.featureExtractionResultLabel = new System.Windows.Forms.Label();
            this.ekstractFeaturesButton = new System.Windows.Forms.Button();
            this.featureNumberLabel = new System.Windows.Forms.Label();
            this.featureNumberComboBox = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.kParamTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.executeTestButton = new System.Windows.Forms.Button();
            this.selectClassifierComboBox = new System.Windows.Forms.ComboBox();
            this.trainButton = new System.Windows.Forms.Button();
            this.trainTestRatioTextBox = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.bootstrapBagsNumberTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bootstrapPercentageTextBox = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.crossvalidationNumOfPartsTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.classificationResultLabel = new System.Windows.Forms.Label();
            this.menuStrip2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip2
            // 
            this.menuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.readDatabaseToolStripMenuItem});
            resources.ApplyResources(this.menuStrip2, "menuStrip2");
            this.menuStrip2.Name = "menuStrip2";
            // 
            // readDatabaseToolStripMenuItem
            // 
            this.readDatabaseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.readFromFile});
            this.readDatabaseToolStripMenuItem.Name = "readDatabaseToolStripMenuItem";
            resources.ApplyResources(this.readDatabaseToolStripMenuItem, "readDatabaseToolStripMenuItem");
            // 
            // readFromFile
            // 
            this.readFromFile.Name = "readFromFile";
            resources.ApplyResources(this.readFromFile, "readFromFile");
            this.readFromFile.Click += new System.EventHandler(this.ReadFromFileButtonClick);
            // 
            // selectDatabaseFileDialog
            // 
            this.selectDatabaseFileDialog.FileName = "databaseFilePath";
            resources.ApplyResources(this.selectDatabaseFileDialog, "selectDatabaseFileDialog");
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.extractFeaturesSFSButton);
            this.panel1.Controls.Add(this.featureExtractionResultLabel);
            this.panel1.Controls.Add(this.ekstractFeaturesButton);
            this.panel1.Controls.Add(this.featureNumberLabel);
            this.panel1.Controls.Add(this.featureNumberComboBox);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // extractFeaturesSFSButton
            // 
            resources.ApplyResources(this.extractFeaturesSFSButton, "extractFeaturesSFSButton");
            this.extractFeaturesSFSButton.Name = "extractFeaturesSFSButton";
            this.extractFeaturesSFSButton.UseVisualStyleBackColor = true;
            this.extractFeaturesSFSButton.Click += new System.EventHandler(this.ExtractFeaturesSFSButtonClick);
            // 
            // featureExtractionResultLabel
            // 
            resources.ApplyResources(this.featureExtractionResultLabel, "featureExtractionResultLabel");
            this.featureExtractionResultLabel.BackColor = System.Drawing.Color.Chartreuse;
            this.featureExtractionResultLabel.Name = "featureExtractionResultLabel";
            // 
            // ekstractFeaturesButton
            // 
            resources.ApplyResources(this.ekstractFeaturesButton, "ekstractFeaturesButton");
            this.ekstractFeaturesButton.Name = "ekstractFeaturesButton";
            this.ekstractFeaturesButton.UseVisualStyleBackColor = true;
            this.ekstractFeaturesButton.Click += new System.EventHandler(this.ExtractFeaturesButtonClick);
            // 
            // featureNumberLabel
            // 
            resources.ApplyResources(this.featureNumberLabel, "featureNumberLabel");
            this.featureNumberLabel.Name = "featureNumberLabel";
            // 
            // featureNumberComboBox
            // 
            this.featureNumberComboBox.FormattingEnabled = true;
            this.featureNumberComboBox.Items.AddRange(new object[] {
            resources.GetString("featureNumberComboBox.Items"),
            resources.GetString("featureNumberComboBox.Items1"),
            resources.GetString("featureNumberComboBox.Items2"),
            resources.GetString("featureNumberComboBox.Items3"),
            resources.GetString("featureNumberComboBox.Items4"),
            resources.GetString("featureNumberComboBox.Items5"),
            resources.GetString("featureNumberComboBox.Items6"),
            resources.GetString("featureNumberComboBox.Items7")});
            resources.ApplyResources(this.featureNumberComboBox, "featureNumberComboBox");
            this.featureNumberComboBox.Name = "featureNumberComboBox";
            this.featureNumberComboBox.SelectedIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.kParamTextBox);
            this.panel2.Controls.Add(this.executeTestButton);
            this.panel2.Controls.Add(this.selectClassifierComboBox);
            this.panel2.Controls.Add(this.trainButton);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // kParamTextBox
            // 
            resources.ApplyResources(this.kParamTextBox, "kParamTextBox");
            this.kParamTextBox.Name = "kParamTextBox";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // executeTestButton
            // 
            resources.ApplyResources(this.executeTestButton, "executeTestButton");
            this.executeTestButton.Name = "executeTestButton";
            this.executeTestButton.UseVisualStyleBackColor = true;
            this.executeTestButton.Click += new System.EventHandler(this.ExecuteTestButtonClick);
            // 
            // selectClassifierComboBox
            // 
            this.selectClassifierComboBox.FormattingEnabled = true;
            this.selectClassifierComboBox.Items.AddRange(new object[] {
            resources.GetString("selectClassifierComboBox.Items"),
            resources.GetString("selectClassifierComboBox.Items1"),
            resources.GetString("selectClassifierComboBox.Items2"),
            resources.GetString("selectClassifierComboBox.Items3")});
            resources.ApplyResources(this.selectClassifierComboBox, "selectClassifierComboBox");
            this.selectClassifierComboBox.Name = "selectClassifierComboBox";
            this.selectClassifierComboBox.SelectedIndexChanged += new System.EventHandler(this.selectClassifierComboBox_SelectedIndexChanged);
            this.selectClassifierComboBox.SelectedIndex = 0;
            // 
            // trainButton
            // 
            resources.ApplyResources(this.trainButton, "trainButton");
            this.trainButton.Name = "trainButton";
            this.trainButton.UseVisualStyleBackColor = true;
            this.trainButton.Click += new System.EventHandler(this.TrainButtonClick);
            // 
            // trainTestRatioTextBox
            // 
            resources.ApplyResources(this.trainTestRatioTextBox, "trainTestRatioTextBox");
            this.trainTestRatioTextBox.Name = "trainTestRatioTextBox";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.bootstrapBagsNumberTextBox);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.bootstrapPercentageTextBox);
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Name = "panel3";
            // 
            // bootstrapBagsNumberTextBox
            // 
            resources.ApplyResources(this.bootstrapBagsNumberTextBox, "bootstrapBagsNumberTextBox");
            this.bootstrapBagsNumberTextBox.Name = "bootstrapBagsNumberTextBox";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // bootstrapPercentageTextBox
            // 
            resources.ApplyResources(this.bootstrapPercentageTextBox, "bootstrapPercentageTextBox");
            this.bootstrapPercentageTextBox.Name = "bootstrapPercentageTextBox";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.crossvalidationNumOfPartsTextBox);
            this.panel4.Controls.Add(this.label4);
            resources.ApplyResources(this.panel4, "panel4");
            this.panel4.Name = "panel4";
            // 
            // crossvalidationNumOfPartsTextBox
            // 
            resources.ApplyResources(this.crossvalidationNumOfPartsTextBox, "crossvalidationNumOfPartsTextBox");
            this.crossvalidationNumOfPartsTextBox.Name = "crossvalidationNumOfPartsTextBox";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // radioButton1
            // 
            resources.ApplyResources(this.radioButton1, "radioButton1");
            this.radioButton1.Checked = true;
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.TabStop = true;
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            resources.ApplyResources(this.radioButton2, "radioButton2");
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            resources.ApplyResources(this.radioButton3, "radioButton3");
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label5);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Controls.Add(this.trainTestRatioTextBox);
            resources.ApplyResources(this.panel5, "panel5");
            this.panel5.Name = "panel5";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // classificationResultLabel
            // 
            resources.ApplyResources(this.classificationResultLabel, "classificationResultLabel");
            this.classificationResultLabel.Name = "classificationResultLabel";
            // 
            // OakStatisticalAnalisysisForm
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.classificationResultLabel);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip2);
            this.MainMenuStrip = this.menuStrip2;
            this.Name = "OakStatisticalAnalisysisForm";
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem readToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem readFromFileButton;
        private System.Windows.Forms.ToolStripMenuItem dsdToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dsdsToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem readDatabaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem readFromFile;
        private System.Windows.Forms.OpenFileDialog selectDatabaseFileDialog;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label featureNumberLabel;
        private System.Windows.Forms.ComboBox featureNumberComboBox;
        private System.Windows.Forms.Button ekstractFeaturesButton;
        private System.Windows.Forms.Label featureExtractionResultLabel;
        private System.Windows.Forms.Button extractFeaturesSFSButton;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button trainButton;
        private System.Windows.Forms.TextBox trainTestRatioTextBox;
        private System.Windows.Forms.ComboBox selectClassifierComboBox;
        private System.Windows.Forms.Button executeTestButton;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox bootstrapPercentageTextBox;
        private System.Windows.Forms.TextBox bootstrapBagsNumberTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox crossvalidationNumOfPartsTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox kParamTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label classificationResultLabel;
    }
}

