namespace DSP.Lab1
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxA = new System.Windows.Forms.TextBox();
            this.textBoxR0 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxM = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonStart = new System.Windows.Forms.Button();
            this.chartHist = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.richTextBox = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.chartHist)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(203, 450);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "a:";
            // 
            // textBoxA
            // 
            this.textBoxA.Location = new System.Drawing.Point(233, 452);
            this.textBoxA.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxA.Name = "textBoxA";
            this.textBoxA.Size = new System.Drawing.Size(148, 26);
            this.textBoxA.TabIndex = 1;
            this.textBoxA.Text = "2140000000";
            // 
            // textBoxR0
            // 
            this.textBoxR0.Location = new System.Drawing.Point(683, 455);
            this.textBoxR0.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxR0.Name = "textBoxR0";
            this.textBoxR0.Size = new System.Drawing.Size(148, 26);
            this.textBoxR0.TabIndex = 3;
            this.textBoxR0.Text = "49081";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(641, 455);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "R0:";
            // 
            // textBoxM
            // 
            this.textBoxM.Location = new System.Drawing.Point(449, 452);
            this.textBoxM.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxM.Name = "textBoxM";
            this.textBoxM.Size = new System.Drawing.Size(148, 26);
            this.textBoxM.TabIndex = 5;
            this.textBoxM.Text = "4294967295";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(415, 450);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "m:";
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(39, 443);
            this.buttonStart.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(112, 35);
            this.buttonStart.TabIndex = 6;
            this.buttonStart.Text = "Запустить";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // chartHist
            // 
            this.chartHist.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            chartArea4.BorderColor = System.Drawing.Color.GreenYellow;
            chartArea4.Name = "ChartArea1";
            this.chartHist.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.chartHist.Legends.Add(legend4);
            this.chartHist.Location = new System.Drawing.Point(13, 14);
            this.chartHist.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chartHist.Name = "chartHist";
            this.chartHist.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Данные";
            this.chartHist.Series.Add(series4);
            this.chartHist.Size = new System.Drawing.Size(1125, 419);
            this.chartHist.TabIndex = 7;
            this.chartHist.Text = "chartHist";
            // 
            // richTextBox
            // 
            this.richTextBox.Location = new System.Drawing.Point(13, 491);
            this.richTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.ReadOnly = true;
            this.richTextBox.Size = new System.Drawing.Size(1123, 195);
            this.richTextBox.TabIndex = 8;
            this.richTextBox.Text = "";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1151, 1050);
            this.Controls.Add(this.richTextBox);
            this.Controls.Add(this.chartHist);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.textBoxM);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxR0);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxA);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 800);
            this.Name = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.chartHist)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxA;
        private System.Windows.Forms.TextBox textBoxR0;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxM;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartHist;
        private System.Windows.Forms.RichTextBox richTextBox;
    }
}

