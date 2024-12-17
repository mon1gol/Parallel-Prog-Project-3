using System;
using System.Windows.Forms;
using System.IO;
using Series = System.Windows.Forms.DataVisualization.Charting.Series;

namespace ProjectTwo.Chart
{
    public partial class Form1 : Form
    {
        private const string FILE_PATH = "D:\\Вузовский ад\\4 курс 1 семестр\\Параллельное программирование\\ProjectPartTwo.Core\\ProjectTwo\\ProjectTwo.Core\\bin\\Debug\\ThreadsInfo.txt";
        public Form1()
        {
            InitializeComponent();
            chart1.Titles.Add("BigJopaDirtHairyAndrushki");
            chart1.Series[0].Name = "MiniPiskaAndrushki";
            string[] lines = File.ReadAllLines(FILE_PATH);

            for (int i = 0; i < lines.Length; i++)
            {
                string[] str = lines[i].Split('\t');

                chart1.Series[0].Points.AddXY(Convert.ToInt64(str[0]), Convert.ToInt64(str[1]));
            }
        }
    }
}
