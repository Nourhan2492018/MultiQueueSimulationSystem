using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MultiQueueModels;
using MultiQueueTesting;

namespace MultiQueueSimulation
{
    public partial class PerformMeasures : Form
    {
         SimulationSystem simulationsystem;
        public PerformMeasures(SimulationSystem simulationsystem)
        {
            InitializeComponent();
            this.simulationsystem = simulationsystem;
          
        }

        private void PerformMeasures_Load(object sender, EventArgs e)
        {
            
            textBox2.Text = simulationsystem.PerformanceMeasures.MaxQueueLength.ToString();
             
        // Calculate Average time measure
       
            textBox1.Text = simulationsystem.PerformanceMeasures.AverageWaitingTime.ToString();
        
        // Calculate Waiting probability measure

            textBox3.Text = simulationsystem.PerformanceMeasures.WaitingProbability.ToString();
        
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            DialogResult response = MessageBox.Show("Are you sure you want to exit?", "exit APP", MessageBoxButtons.YesNo);
            if (response == System.Windows.Forms.DialogResult.Yes)
            {
                DialogResult response1 = MessageBox.Show("Do you want to exit all forms?", "exit APP", MessageBoxButtons.YesNo);
                if (response1 == System.Windows.Forms.DialogResult.Yes)
                {
                    Application.Exit();

                }
                else
                {
                    this.Close();
                }
            }
        }
    }
}
