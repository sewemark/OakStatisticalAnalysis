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
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip2
            // 
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.readDatabaseToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(284, 24);
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
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.menuStrip2);
            this.MainMenuStrip = this.menuStrip2;
            this.Name = "Form1";
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
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
    }
}

