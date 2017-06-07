namespace OakStatisticalAnalysis
{
    partial class Form1
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
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.readDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.readFromFile = new System.Windows.Forms.ToolStripMenuItem();
            this.selectDatabaseFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.featureNumberLabel = new System.Windows.Forms.Label();
            this.featureNumberComboBox = new System.Windows.Forms.ComboBox();
            this.ekstractFeaturesButton = new System.Windows.Forms.Button();
            this.featureExtractionResultLabel = new System.Windows.Forms.Label();
            this.menuStrip2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip2
            // 
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.readDatabaseToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(521, 24);
            this.menuStrip2.TabIndex = 0;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // readDatabaseToolStripMenuItem
            // 
            this.readDatabaseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.readFromFile});
            this.readDatabaseToolStripMenuItem.Name = "readDatabaseToolStripMenuItem";
            this.readDatabaseToolStripMenuItem.Size = new System.Drawing.Size(96, 20);
            this.readDatabaseToolStripMenuItem.Text = "Read Database";
            // 
            // readFromFile
            // 
            this.readFromFile.Name = "readFromFile";
            this.readFromFile.Size = new System.Drawing.Size(152, 22);
            this.readFromFile.Text = "From file";
            this.readFromFile.Click += new System.EventHandler(this.ReadFromFileButtonClick);
            // 
            // selectDatabaseFileDialog
            // 
            this.selectDatabaseFileDialog.FileName = "databaseFilePath";
            this.selectDatabaseFileDialog.Filter = "Text|*.txt;";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.featureExtractionResultLabel);
            this.panel1.Controls.Add(this.ekstractFeaturesButton);
            this.panel1.Controls.Add(this.featureNumberLabel);
            this.panel1.Controls.Add(this.featureNumberComboBox);
            this.panel1.Location = new System.Drawing.Point(12, 46);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(250, 149);
            this.panel1.TabIndex = 1;
            // 
            // featureNumberLabel
            // 
            this.featureNumberLabel.AutoSize = true;
            this.featureNumberLabel.Location = new System.Drawing.Point(3, 20);
            this.featureNumberLabel.Name = "featureNumberLabel";
            this.featureNumberLabel.Size = new System.Drawing.Size(82, 13);
            this.featureNumberLabel.TabIndex = 1;
            this.featureNumberLabel.Text = "Num of features";
            // 
            // featureNumberComboBox
            // 
            this.featureNumberComboBox.FormattingEnabled = true;
            this.featureNumberComboBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.featureNumberComboBox.Location = new System.Drawing.Point(126, 17);
            this.featureNumberComboBox.Name = "featureNumberComboBox";
            this.featureNumberComboBox.Size = new System.Drawing.Size(121, 21);
            this.featureNumberComboBox.TabIndex = 0;
            // 
            // ekstractFeaturesButton
            // 
            this.ekstractFeaturesButton.Location = new System.Drawing.Point(6, 51);
            this.ekstractFeaturesButton.Name = "ekstractFeaturesButton";
            this.ekstractFeaturesButton.Size = new System.Drawing.Size(75, 23);
            this.ekstractFeaturesButton.TabIndex = 2;
            this.ekstractFeaturesButton.Text = "Extract";
            this.ekstractFeaturesButton.UseVisualStyleBackColor = true;
            this.ekstractFeaturesButton.Click += new System.EventHandler(this.ExtractFeaturesButtonClick);
            // 
            // featureExtractionResultLabel
            // 
            this.featureExtractionResultLabel.AutoSize = true;
            this.featureExtractionResultLabel.Location = new System.Drawing.Point(6, 120);
            this.featureExtractionResultLabel.Name = "featureExtractionResultLabel";
            this.featureExtractionResultLabel.Size = new System.Drawing.Size(43, 13);
            this.featureExtractionResultLabel.TabIndex = 3;
            this.featureExtractionResultLabel.Text = "Result: ";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(521, 261);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip2);
            this.MainMenuStrip = this.menuStrip2;
            this.Name = "Form1";
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
    }
}

