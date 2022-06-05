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
    public partial class SreverGraph : Form
    {
        public SreverGraph(int i, SimulationSystem Program)
        {
            InitializeComponent();
            ResultsGraph.Series.Add("Server " + Program.Servers[i].ID.ToString());
            ResultsGraph.ChartAreas[0].AxisX.Minimum = 1;
            ResultsGraph.ChartAreas[0].AxisX.Maximum = Program.Servers[i].FinishTime;
            ResultsGraph.ChartAreas[0].AxisX.Interval = 1;
            ResultsGraph.ChartAreas[0].AxisY.Interval = 1;
            foreach (KeyValuePair<int, int> j in Program.Servers[i].Ranges)
            {
                int I = j.Key;
                while(I <= j.Value){
               
                    ResultsGraph.Series[0].Points.AddXY(I, 1);
                    I++;
                }
            }
        }

        private void GraphResults(object sender, EventArgs e)
        {

        }

        private void Graphs(object sender, EventArgs e)
        {

        }
        private void ServerResults(object sender, EventArgs e)
        {

        }
        private void EXITButton3(object sender, EventArgs e)
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
