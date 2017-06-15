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
            this.trainTestRatioTextBox = new System.Windows.Forms.TextBox();
            this.trainButton = new System.Windows.Forms.Button();
            this.selectClassifierComboBox = new System.Windows.Forms.ComboBox();
            this.executeTestButton = new System.Windows.Forms.Button();
            this.menuStrip2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip2
            // 
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
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.executeTestButton);
            this.panel2.Controls.Add(this.selectClassifierComboBox);
            this.panel2.Controls.Add(this.trainButton);
            this.panel2.Controls.Add(this.trainTestRatioTextBox);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // trainTestRatioTextBox
            // 
            resources.ApplyResources(this.trainTestRatioTextBox, "trainTestRatioTextBox");
            this.trainTestRatioTextBox.Name = "trainTestRatioTextBox";
            // 
            // trainButton
            // 
            resources.ApplyResources(this.trainButton, "trainButton");
            this.trainButton.Name = "trainButton";
            this.trainButton.UseVisualStyleBackColor = true;
            this.trainButton.Click += new System.EventHandler(this.TrainButtonClick);
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
            // 
            // executeTestButton
            // 
            resources.ApplyResources(this.executeTestButton, "executeTestButton");
            this.executeTestButton.Name = "executeTestButton";
            this.executeTestButton.UseVisualStyleBackColor = true;
            this.executeTestButton.Click += new System.EventHandler(this.ExecuteTestButtonClick);
            // 
            // OakStatisticalAnalisysisForm
            // 
            resources.ApplyResources(this, "$this");
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
    }
}

