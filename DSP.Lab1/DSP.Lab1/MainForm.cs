using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DSP.Lab1
{
    public partial class MainForm : Form
    {
        private const double N = 100000;
        private const int K = 20;

        private long _r;
        private long _a;
        private long _m;
        private List<double> _x;


        public MainForm()
        {
            InitializeComponent();
        }


        private void buttonStart_Click(object sender, EventArgs e)
        {
            ClearGraphs();

            _x = new List<double>();
            ParseParameters();

            LehmersAlghoritm(_x, _r, _a, _m, N);

            DrawHistohram(_x, N, K);

            ClculateDispersionMathematicalExpectationAndSigma(_x);
            UniformityCheckByIndirectFeatures(_x);
            CalculatePeriodLengthAndAperiodicLineSegmentLength(_x);
        }

        private void ParseParameters()
        {
            _r = Int64.Parse(textBoxR0.Text);
            _a = Int64.Parse(textBoxA.Text);
            _m = Int64.Parse(textBoxM.Text);
        }

        private static void LehmersAlghoritm(ICollection<double> x, long r, long a, long m, double n)
        {
            for (var i = 0; i < n; i++)
            {
                r = r * a % m;
                x.Add((double)r / m);
            }
        }

        private void DrawHistohram(IReadOnlyCollection<double> x, double n, int k)
        {
            var xMin = x.Min();
            var xMax = x.Max();
            var rVar = xMax - xMin;
            var delta = rVar / k;
            var popadCount = new double[k];
            var histX = new double[k];
            foreach (var elem in x)
            {
                popadCount[(int)((elem - xMin) / delta < 20 ? (elem - xMin) / delta : 19)]++;
            }
            for (var i = 0; i < k; i++)
            {
                histX[i] = xMin + (delta * i);
                histX[i] = Math.Round(histX[i], 4);
                popadCount[i] = popadCount[i] / n;
            }
            chartHist.Series[0].Points.DataBindXY(histX, popadCount);
        }

        private void ClculateDispersionMathematicalExpectationAndSigma(IReadOnlyCollection<double> x)
        {
            var sum = x.Sum();
            var matOzh = sum / x.Count;
            richTextBox.Text += @"M = " + matOzh + '\n';
            var dSum = x.Sum(t => Math.Pow(t - matOzh, 2));
            var disp = dSum / x.Count;
            richTextBox.Text += @"D = " + disp + '\n';
            richTextBox.Text += @"Sigma = " + Math.Sqrt(disp) + "\n\n";
        }

        private void UniformityCheckByIndirectFeatures(IReadOnlyList<double> x)
        {
            var innerCount = 0;
            for (var i = 0; i + 1 < x.Count; i += 2)
            {
                if (x[i] * x[i] + x[i + 1] * x[i + 1] < 1)
                {
                    innerCount++;
                }
            }
            richTextBox.Text += @"Pi / 4 = " + Math.PI / 4.0 + '\n';
            richTextBox.Text += @"2K / N = " + innerCount * 2.0 / x.Count + "\n\n";
        }

        private void CalculatePeriodLengthAndAperiodicLineSegmentLength(IReadOnlyList<double> x)
        {
            var xv = x.Last();
            var pos = new int[2];
            var isFirst = false;
            const double epsilon = double.Epsilon;
            for (var i = 0; i < x.Count; i++)
            {
                if (Math.Abs(x[i] - xv) < epsilon)
                {
                    if (isFirst)
                    {
                        pos[1] = i;

                        break;
                    }
                    isFirst = true;
                    pos[0] = i;
                }
            }
            var l = pos[1] - pos[0];
            var pos0 = 0;
            for (var i = 0; i + l < x.Count; i++)
            {
                if (Math.Abs(x[i] - x[i + l]) < epsilon)
                {
                    pos0 = i;

                    break;
                }
            }
            richTextBox.Text += @"Длина периода = " + l + '\n';
            richTextBox.Text += @"Длина участка апериодичности = " + (l + pos0) + '\n';
        }

        private void ClearGraphs()
        {
            //chartHist.Series.Clear();
            chartHist.ResetAutoValues();
            richTextBox.Text = String.Empty;
        }
    }
}