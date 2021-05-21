namespace MarineTovar_Assign6
{
    partial class LineGraph
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
            this.lineGraphPortalButton = new System.Windows.Forms.Button();
            this.line = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.line)).BeginInit();
            this.SuspendLayout();
            // 
            // lineGraphPortalButton
            // 
            this.lineGraphPortalButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lineGraphPortalButton.Location = new System.Drawing.Point(500, 174);
            this.lineGraphPortalButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lineGraphPortalButton.Name = "lineGraphPortalButton";
            this.lineGraphPortalButton.Size = new System.Drawing.Size(73, 24);
            this.lineGraphPortalButton.TabIndex = 1;
            this.lineGraphPortalButton.Text = "Portal";
            this.lineGraphPortalButton.UseVisualStyleBackColor = true;
            this.lineGraphPortalButton.Click += new System.EventHandler(this.lineGraphPortalButton_Click);
            // 
            // line
            // 
            this.line.BackColor = System.Drawing.Color.LightGray;
            chartArea1.AxisX.Maximum = 12D;
            chartArea1.AxisX.Minimum = 1D;
            chartArea1.AxisX.Title = "Month";
            chartArea1.AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisY.Maximum = 1000D;
            chartArea1.AxisY.Minimum = 0D;
            chartArea1.AxisY.Title = "Sales";
            chartArea1.AxisY.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.Name = "ChartArea1";
            this.line.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.line.Legends.Add(legend1);
            this.line.Location = new System.Drawing.Point(9, 39);
            this.line.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.line.Name = "line";
            this.line.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            this.line.Size = new System.Drawing.Size(461, 285);
            this.line.TabIndex = 2;
            this.line.Text = "Line Graph";
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title1.Name = "lineTitle";
            title1.Text = "Sale of Food Items Over a Year";
            this.line.Titles.Add(title1);
            // 
            // LineGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.line);
            this.Controls.Add(this.lineGraphPortalButton);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "LineGraph";
            this.Text = "Graph1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LineGraph_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.line)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button lineGraphPortalButton;
        private System.Windows.Forms.DataVisualization.Charting.Chart line;
    }
}