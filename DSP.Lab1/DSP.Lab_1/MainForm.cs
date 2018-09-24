using System;
using System.Collections.Generic;
using System.Data;
using OxyPlot;
using OxyPlot.Series;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Series = System.Windows.Forms.DataVisualization.Charting.Series;

namespace DSP.Lab_1
{
    public partial class MainForm : Form
    {
        private int _a = 10;
        private int _n = 511;
        private double _fi = Math.PI / 2;
        private int _f = 2;
        private int _N = 512;
        private int _k = 5;


        private readonly double[] _fiValues = { 0, Math.PI / 6, Math.PI / 4, Math.PI / 2, Math.PI };
        private readonly int[] _freqValues = { 5, 4, 2, 6, 3 };
        private readonly int[] _ampValues = { 2, 3, 6, 5, 1 };
        private readonly string[] _fiStrings = { "0", "π/6", "π/4", "π/2", "π" };
        private readonly double[] _polyValues = { 0, Math.PI / 4, Math.PI / 6, 2 * Math.PI, Math.PI };

        private Func<double, double> _harmonicFunc;
        private Func<double, double> _polyharmonicFunc;


        public MainForm()
        {
            InitializeComponent();
        }


        private PlotModel DrawAllFirst()
        {
            var harmonicModel = new PlotModel { Title = "Harmonic signal" };
            for (var i = 0; i < 5; i++)
            {
                _fi = _fiValues[i];
                _a = int.Parse(amplitudeTextBox.Text);
                _f = int.Parse(frequencyTextBox.Text);
                harmonicModel.Series.Add(new FunctionSeries(_harmonicFunc, 0, _n, 0.5, "fi" + (i + 1)));
            }

            return harmonicModel;
        }

        private PlotModel DrawAllSecond()
        {
            var harmonicModel = new PlotModel() { Title = "Harmonic signal" };
            for (var i = 0; i < 5; i++)
            {
                _f = _freqValues[i];
                _a = int.Parse(amplitudeTextBox2.Text);
                _fi = 3 * Math.PI / 4;
                harmonicModel.Series.Add(new FunctionSeries(_harmonicFunc, 0, _n, 0.5, "f" + (i + 1)));
            }

            return harmonicModel;
        }

        private PlotModel DrawAllThird()
        {
            var harmonicModel = new PlotModel() { Title = "Harmonic signal" };
            for (var i = 0; i < 5; i++)
            {
                _f = int.Parse(frequencyTextBox2.Text); 
                _a = _ampValues[i];
                _fi = 3 * Math.PI / 4;
                harmonicModel.Series.Add(new FunctionSeries(_harmonicFunc, 0, _n, 0.5, "A" + (i + 1)));
            }

            return harmonicModel;
        }

        private double Calc(double n)
        {
            return _a * Math.Sin(2 * Math.PI * _f * n / _N + _fi);
        }

        private double PolyCalc(double n)
        {
            var res = _a * Math.Sin(2 * Math.PI * 1 * n / _N + _polyValues[0]);
            for (var j = 2; j <= 5; j++)
            {
                res = res + _a * Math.Sin(2 * Math.PI * j * n / _N + _polyValues[j - 1]);
            }

            return res;
        }

        private double PolyCalc2(double n)
        {
            var res = _a * Math.Sin(2 * Math.PI * 1 * n / _N + _fi);
            for (var j = 1; j <= 5; j++)
            {
                res = res + _a * Math.Sin(2 * Math.PI * j * n / _N + _fi);
            }

            return res;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _harmonicFunc = Calc;
            _polyharmonicFunc = PolyCalc2;

            fiGridView.DataSource = GenerateTable(_fiStrings, "fi");
            fiGridView.AllowUserToAddRows = false;

            frequenciesGridView.DataSource = GenerateTable(_freqValues, "f");
            frequenciesGridView.AllowUserToAddRows = false;

            amplitudeGridView.DataSource = GenerateTable(_ampValues, "A");
            amplitudeGridView.AllowUserToAddRows = false;
            plotView1.Model = DrawAllFirst();
            plotView2.Model = DrawAllSecond();
            plotView3.Model = DrawAllThird();
            plotView4.Model = DrawPolyFirst();
            DrawPolySecond();
        }

        private void DrawPolySecond()
        {
            double A = 10;
            var N = int.Parse(poly2NtextBox.Text);
            var n = int.Parse(poly2nbox.Text);
            //var n = 512;
            var fi = 0;
            
            double f = 10;
            var k = 5;
            double res = 0;
            if (chart1.ChartAreas.Count == 1)  
            chart1.ChartAreas.Add(new ChartArea("Math"));

            var series = new Series("Polyharmonic signal")
            {
                ChartType = SeriesChartType.Line,
                ChartArea = "Math"
            };

            for (var i = 1; i < N*2; i++)
            {
                var a = A * (i % N) * 0.001;
                var freq = f * (i % N) * 0.001;
                var fiVar = fi * (i % N) * 0.001;
                for (var j = 1;  j <= k;  j++)
                {
                    res = res + a * Math.Sin((2 * Math.PI * freq * i / N) + fiVar);
                }

                series.Points.AddXY(i, res);
                res = 0;
            }

            if (chart1.Series.Count == 0)
            {
                chart1.Series.Add(series);
            }
            else
            {
                chart1.Series[0] = series;
            }
                
        }

        private static DataTable GenerateTable<T>(IReadOnlyList<T> values, string colName)
        {
            var dt = new DataTable();

            var r = dt.NewRow();
            for (var i = 1; i <= 5; i++)
            {
                dt.Columns.Add(colName + i);
                r[colName + i] = values[i - 1];
            }
            dt.Rows.Add(r);

            return dt;
        }

        private void drawAllButton_Click(object sender, EventArgs e)
        {
            plotView1.Model = DrawAllFirst();
        }

        private void fiGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            plotView1.Model = DrawSingle(_fiValues[e.ColumnIndex], int.Parse(amplitudeTextBox.Text), int.Parse(frequencyTextBox.Text), int.Parse(nBox1.Text), int.Parse(NtextBox1.Text), e.ColumnIndex + 1);
        }

        private PlotModel DrawSingle(double fi, int a, int f, int n, int N, int colNum)
        {
            _fi = fi;
            _a = a;
            _f = f;
            _n = n;
            _N = N;
            var harmonicModel = new PlotModel() { Title = "Harmonic signal" };
            harmonicModel.Series.Add(new FunctionSeries(_harmonicFunc, 0, _n, 0.5, "fi" + colNum));

            return harmonicModel;
        }

        private void DrawAll2button_Click(object sender, EventArgs e)
        {
            plotView2.Model = DrawAllSecond();
        }

        private void frequenciesGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            plotView2.Model = DrawSingle(3 * Math.PI / 4, int.Parse(amplitudeTextBox2.Text), _freqValues[e.ColumnIndex], int.Parse(nBox2.Text), int.Parse(NtextBox2.Text), e.ColumnIndex + 1);
        }

        private void amplitudeGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            plotView3.Model = DrawSingle(3 * Math.PI / 4, _ampValues[e.ColumnIndex], int.Parse(frequencyTextBox2.Text),
                int.Parse(nBox3.Text), int.Parse(NtextBox3.Text), e.ColumnIndex + 1);
        }

        private void DrawAll3button_Click(object sender, EventArgs e)
        {
            plotView3.Model = DrawAllThird();
        }

        private PlotModel DrawPolyFirst()
        {
            var polyharmonicModel = new PlotModel() {Title = "Polyharmonic signal"};
            _a = 9;
            _N = int.Parse(poly1NtextBox.Text);
            _n = int.Parse(poly1nbox.Text);
            polyharmonicModel.Series.Add(new FunctionSeries(_polyharmonicFunc, 0, _n, 0.5));

            return polyharmonicModel;
        }

        private void polyharmonicTabPage_Click(object sender, EventArgs e)
        {

        }

        private void poly1rebuild_Click(object sender, EventArgs e)
        {
            plotView4.Model = DrawPolyFirst();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DrawPolySecond();
        }
    }
}