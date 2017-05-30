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
        string[] databaseLines;
        public Form1()
        {
            InitializeComponent();
        }

        private void ReadFromFileButtonClick(object sender, EventArgs e)
        {
            GetDatabaseFilePath();
        }

        private void GetDatabaseFilePath()
        {
            DialogResult result = selectDatabaseFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string file = selectDatabaseFileDialog.FileName;
                try
                {
                     databaseLines = File.ReadAllLines(file);
                }
                catch (IOException ioException)
                {
                    MessageBox.Show(ioException.Message.ToString());
                }
            }
        }
        
    }
}
