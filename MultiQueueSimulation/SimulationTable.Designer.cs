namespace MultiQueueSimulation
{
    partial class SimulationTable
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
            this.Output = new System.Windows.Forms.DataGridView();
            this.CustomerNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RndArrival = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeBetween = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ArrivalTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RndService = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ServerID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ServiceBegin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ServiceTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ServiceEnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeInQueue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Simulate = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Output)).BeginInit();
            this.SuspendLayout();
            // 
            // Output
            // 
            this.Output.AllowUserToAddRows = false;
            this.Output.AllowUserToDeleteRows = false;
            this.Output.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Output.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Output.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CustomerNo,
            this.RndArrival,
            this.TimeBetween,
            this.ArrivalTime,
            this.RndService,
            this.ServerID,
            this.ServiceBegin,
            this.ServiceTime,
            this.ServiceEnd,
            this.TimeInQueue});
            this.Output.GridColor = System.Drawing.Color.Thistle;
            this.Output.Location = new System.Drawing.Point(12, 54);
            this.Output.Name = "Output";
            this.Output.ReadOnly = true;
            this.Output.Size = new System.Drawing.Size(782, 444);
            this.Output.TabIndex = 0;
            this.Output.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Output_CellContentClick);
            // 
            // CustomerNo
            // 
            this.CustomerNo.Frozen = true;
            this.CustomerNo.HeaderText = "CustomerNo";
            this.CustomerNo.Name = "CustomerNo";
            this.CustomerNo.ReadOnly = true;
            // 
            // RndArrival
            // 
            this.RndArrival.Frozen = true;
            this.RndArrival.HeaderText = "RndArrival";
            this.RndArrival.Name = "RndArrival";
            this.RndArrival.ReadOnly = true;
            // 
            // TimeBetween
            // 
            this.TimeBetween.Frozen = true;
            this.TimeBetween.HeaderText = "TimeBetween";
            this.TimeBetween.Name = "TimeBetween";
            this.TimeBetween.ReadOnly = true;
            // 
            // ArrivalTime
            // 
            this.ArrivalTime.Frozen = true;
            this.ArrivalTime.HeaderText = "ArrivalTime";
            this.ArrivalTime.Name = "ArrivalTime";
            this.ArrivalTime.ReadOnly = true;
            // 
            // RndService
            // 
            this.RndService.Frozen = true;
            this.RndService.HeaderText = "RndService";
            this.RndService.Name = "RndService";
            this.RndService.ReadOnly = true;
            // 
            // ServerID
            // 
            this.ServerID.Frozen = true;
            this.ServerID.HeaderText = "ServerID";
            this.ServerID.Name = "ServerID";
            this.ServerID.ReadOnly = true;
            // 
            // ServiceBegin
            // 
            this.ServiceBegin.Frozen = true;
            this.ServiceBegin.HeaderText = "ServiceBegin";
            this.ServiceBegin.Name = "ServiceBegin";
            this.ServiceBegin.ReadOnly = true;
            // 
            // ServiceTime
            // 
            this.ServiceTime.Frozen = true;
            this.ServiceTime.HeaderText = "ServiceTime";
            this.ServiceTime.Name = "ServiceTime";
            this.ServiceTime.ReadOnly = true;
            // 
            // ServiceEnd
            // 
            this.ServiceEnd.Frozen = true;
            this.ServiceEnd.HeaderText = "ServiceEnd";
            this.ServiceEnd.Name = "ServiceEnd";
            this.ServiceEnd.ReadOnly = true;
            // 
            // TimeInQueue
            // 
            this.TimeInQueue.HeaderText = "TimeInQueue";
            this.TimeInQueue.Name = "TimeInQueue";
            this.TimeInQueue.ReadOnly = true;
            // 
            // Simulate
            // 
            this.Simulate.BackColor = System.Drawing.Color.MediumTurquoise;
            this.Simulate.Font = new System.Drawing.Font("Bodoni MT", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Simulate.Location = new System.Drawing.Point(45, 509);
            this.Simulate.Name = "Simulate";
            this.Simulate.Size = new System.Drawing.Size(311, 54);
            this.Simulate.TabIndex = 7;
            this.Simulate.Text = "Simulate";
            this.Simulate.UseVisualStyleBackColor = false;
            this.Simulate.Click += new System.EventHandler(this.SImulationTableButton);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.DarkTurquoise;
            this.button2.Font = new System.Drawing.Font("Buxton Sketch", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.Red;
            this.button2.Location = new System.Drawing.Point(746, 528);
            this.button2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(49, 35);
            this.button2.TabIndex = 24;
            this.button2.Text = "EXIT";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Buxton Sketch", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(428, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(207, 27);
            this.label1.TabIndex = 25;
            this.label1.Text = "Simulation Table Form";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.MediumTurquoise;
            this.button1.Font = new System.Drawing.Font("Bodoni MT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(424, 509);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(216, 54);
            this.button1.TabIndex = 26;
            this.button1.Text = "Measures";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // SimulationTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(835, 576);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.Simulate);
            this.Controls.Add(this.Output);
            this.Name = "SimulationTable";
            this.Text = "Results";
            this.Load += new System.EventHandler(this.Results_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Output)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView Output;
        private System.Windows.Forms.Button Simulate;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn RndArrival;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeBetween;
        private System.Windows.Forms.DataGridViewTextBoxColumn ArrivalTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn RndService;
        private System.Windows.Forms.DataGridViewTextBoxColumn ServerID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ServiceBegin;
        private System.Windows.Forms.DataGridViewTextBoxColumn ServiceTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ServiceEnd;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeInQueue;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}