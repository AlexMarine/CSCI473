namespace MarineTovar_Assign6
{
    partial class BarChart
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.barChartPortalButton = new System.Windows.Forms.Button();
            this.Bar1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.Bar1)).BeginInit();
            this.SuspendLayout();
            // 
            // barChartPortalButton
            // 
            this.barChartPortalButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barChartPortalButton.Location = new System.Drawing.Point(316, 407);
            this.barChartPortalButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.barChartPortalButton.Name = "barChartPortalButton";
            this.barChartPortalButton.Size = new System.Drawing.Size(85, 30);
            this.barChartPortalButton.TabIndex = 5;
            this.barChartPortalButton.Text = "Portal";
            this.barChartPortalButton.UseVisualStyleBackColor = true;
            this.barChartPortalButton.Click += new System.EventHandler(this.barChartPortalButton_Click);
            // 
            // Bar1
            // 
            chartArea1.AxisX.Interval = 1D;
            chartArea1.AxisX.Title = "Numbers";
            chartArea1.AxisX2.Interval = 10D;
            chartArea1.AxisY.Interval = 10D;
            chartArea1.AxisY.Maximum = 100D;
            chartArea1.AxisY.Title = "% Meaning";
            chartArea1.Name = "ChartArea1";
            this.Bar1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.Bar1.Legends.Add(legend1);
            this.Bar1.Location = new System.Drawing.Point(101, 15);
            this.Bar1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Bar1.Name = "Bar1";
            this.Bar1.Size = new System.Drawing.Size(569, 369);
            this.Bar1.TabIndex = 7;
            this.Bar1.Text = "chart1";
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title1.Name = "Title1";
            title1.Text = "Numbers vs % Relativity to the Meaning of life";
            this.Bar1.Titles.Add(title1);
            // 
            // BarChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Bar1);
            this.Controls.Add(this.barChartPortalButton);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "BarChart";
            this.Text = "Graph2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BarChart_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.Bar1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button barChartPortalButton;
        private System.Windows.Forms.DataVisualization.Charting.Chart Bar1;
    }
}