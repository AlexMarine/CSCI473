namespace MarineTovar_Assign6
{
    partial class Portal
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
            this.lineGraphButton = new System.Windows.Forms.Button();
            this.barChartButton = new System.Windows.Forms.Button();
            this.pieChartButton = new System.Windows.Forms.Button();
            this.histogramButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lineGraphButton
            // 
            this.lineGraphButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lineGraphButton.Location = new System.Drawing.Point(160, 192);
            this.lineGraphButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lineGraphButton.Name = "lineGraphButton";
            this.lineGraphButton.Size = new System.Drawing.Size(98, 28);
            this.lineGraphButton.TabIndex = 0;
            this.lineGraphButton.Text = "Line Graph";
            this.lineGraphButton.UseVisualStyleBackColor = true;
            this.lineGraphButton.Click += new System.EventHandler(this.lineGraphButton_Click);
            // 
            // barChartButton
            // 
            this.barChartButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barChartButton.Location = new System.Drawing.Point(262, 192);
            this.barChartButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.barChartButton.Name = "barChartButton";
            this.barChartButton.Size = new System.Drawing.Size(98, 28);
            this.barChartButton.TabIndex = 1;
            this.barChartButton.Text = "Bar Chart";
            this.barChartButton.UseVisualStyleBackColor = true;
            this.barChartButton.Click += new System.EventHandler(this.barChartButton_Click);
            // 
            // pieChartButton
            // 
            this.pieChartButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pieChartButton.Location = new System.Drawing.Point(364, 192);
            this.pieChartButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pieChartButton.Name = "pieChartButton";
            this.pieChartButton.Size = new System.Drawing.Size(98, 28);
            this.pieChartButton.TabIndex = 2;
            this.pieChartButton.Text = "Pie Chart";
            this.pieChartButton.UseVisualStyleBackColor = true;
            this.pieChartButton.Click += new System.EventHandler(this.pieChartButton_Click);
            // 
            // histogramButton
            // 
            this.histogramButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.histogramButton.Location = new System.Drawing.Point(466, 192);
            this.histogramButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.histogramButton.Name = "histogramButton";
            this.histogramButton.Size = new System.Drawing.Size(104, 28);
            this.histogramButton.TabIndex = 3;
            this.histogramButton.Text = "Radar Chart";
            this.histogramButton.UseVisualStyleBackColor = true;
            this.histogramButton.Click += new System.EventHandler(this.radarButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitButton.Location = new System.Drawing.Point(328, 224);
            this.exitButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(64, 24);
            this.exitButton.TabIndex = 4;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // Portal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(727, 424);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.histogramButton);
            this.Controls.Add(this.pieChartButton);
            this.Controls.Add(this.barChartButton);
            this.Controls.Add(this.lineGraphButton);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Portal";
            this.Text = "Portal";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Portal_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button lineGraphButton;
        private System.Windows.Forms.Button barChartButton;
        private System.Windows.Forms.Button pieChartButton;
        private System.Windows.Forms.Button histogramButton;
        private System.Windows.Forms.Button exitButton;
    }
}

