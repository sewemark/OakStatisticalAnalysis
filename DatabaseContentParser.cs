using OakStatisticalAnalysis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
namespace OakStatisticalAnalysis
{
    public interface IDatabaseContentParser
    {
        List<Sample> ParseContent();
    }

    public class DatabaseContentParser : IDatabaseContentParser
    {
        private string[] content;

        public DatabaseContentParser(string [] _content)
        {
            content = _content;
        }

        public List<Sample> ParseContent()
        {
            List<Sample> records = new List<Sample>(); 
            for(int i =0;i<content.Length;i++)
            {
                Sample sample = new Sample();
                var columns = content[i].Split(',');
                var textColumns = columns[0].Split(' ');

                for (int j = 1; j < columns.Length; j++)
                {
                    string value = columns[j];
                    sample.Features.Add(double.Parse(value, NumberStyles.AllowDecimalPoint | NumberStyles.AllowTrailingSign, CultureInfo.InvariantCulture));
                }
                sample.Class = textColumns.ElementAt(0);
                sample.Label = String.Join(String.Empty, textColumns.Skip(1));
                records.Add(sample);
            }

            return records;
        }
    }


    public class DatabaseContentParserOther : IDatabaseContentParser
    {
        private string[] content;

        public DatabaseContentParserOther(string[] _content)
        {
            content = _content;
        }

        public List<Sample> ParseContent()
        {
            List<Sample> records = new List<Sample>();
            double[][] rawData = new double[20][];
            rawData[0] = new double[] { 65.0, 220.0 };
            rawData[1] = new double[] { 73.0, 160.0 };
            rawData[2] = new double[] { 59.0, 110.0 };
            rawData[3] = new double[] { 61.0, 120.0 };
            rawData[4] = new double[] { 75.0, 150.0 };
            rawData[5] = new double[] { 67.0, 240.0 };
            rawData[6] = new double[] { 68.0, 230.0 };
            rawData[7] = new double[] { 70.0, 220.0 };
            rawData[8] = new double[] { 62.0, 130.0 };
            rawData[9] = new double[] { 66.0, 210.0 };
            rawData[10] = new double[] { 77.0, 190.0 };
            rawData[11] = new double[] { 75.0, 180.0 };
            rawData[12] = new double[] { 74.0, 170.0 };
            rawData[13] = new double[] { 70.0, 210.0 };
            rawData[14] = new double[] { 61.0, 110.0 };
            rawData[15] = new double[] { 58.0, 100.0 };
            rawData[16] = new double[] { 66.0, 230.0 };
            rawData[17] = new double[] { 59.0, 120.0 };
            rawData[18] = new double[] { 68.0, 210.0 };
            rawData[19] = new double[] { 61.0, 130.0 };

            for (int i = 0; i < rawData.Length; i++)
            {
                Sample sample = new Sample();
                sample.Features = rawData[i].ToList();
                sample.Class = "Acer";
                sample.Label = "abel";
                records.Add(sample);

            }

            return records;
        }
    }
}
