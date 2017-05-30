using OakStatisticalAnalysis.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OakStatisticalAnalysis
{
    public partial class Form1 : Form
    {
        string[] databaseContent;
        DatabaseContentParser dbContentParser;

        public Form1()
        {
            InitializeComponent();
        }

        private void ReadFromFileButtonClick(object sender, EventArgs e)
        {
            GetDatabaseFilePath();
            dbContentParser = new DatabaseContentParser(databaseContent);
            List<Sample> dbContent = dbContentParser.ParseContent();
        }

        private void GetDatabaseFilePath()
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
