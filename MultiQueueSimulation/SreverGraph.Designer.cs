namespace MultiQueueSimulation
{
    partial class SreverGraph
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
            this.ResultsGraph = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ResultsGraph)).BeginInit();
            this.SuspendLayout();
            // 
            // ResultsGraph
            // 
            this.ResultsGraph.BorderlineColor = System.Drawing.Color.MediumTurquoise;
            chartArea1.Name = "Busy";
            this.ResultsGraph.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.ResultsGraph.Legends.Add(legend1);
            this.ResultsGraph.Location = new System.Drawing.Point(41, 12);
            this.ResultsGraph.Name = "ResultsGraph";
            this.ResultsGraph.Size = new System.Drawing.Size(918, 383);
            this.ResultsGraph.TabIndex = 2;
            this.ResultsGraph.Text = "chart1";
            this.ResultsGraph.Click += new System.EventHandler(this.GraphResults);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.DarkTurquoise;
            this.button2.Font = new System.Drawing.Font("Buxton Sketch", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.Red;
            this.button2.Location = new System.Drawing.Point(960, 461);
            this.button2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(49, 35);
            this.button2.TabIndex = 25;
            this.button2.Text = "EXIT";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.EXITButton3);
            // 
            // SreverGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1018, 505);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.ResultsGraph);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "SreverGraph";
            this.Text = "ServerResults";
            this.Load += new System.EventHandler(this.ServerResults);
            ((System.ComponentModel.ISupportInitialize)(this.ResultsGraph)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart ResultsGraph;
        private System.Windows.Forms.Button button2;
    }
}