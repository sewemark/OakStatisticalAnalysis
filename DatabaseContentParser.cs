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
                    sample.Features.Add(decimal.Parse(value, NumberStyles.AllowDecimalPoint | NumberStyles.AllowTrailingSign, CultureInfo.InvariantCulture));
                }
                sample.Class = textColumns.ElementAt(0);
                sample.Label = String.Join(String.Empty, textColumns.Skip(1));
                records.Add(sample);
            }

            return records;
        }
    }
}
