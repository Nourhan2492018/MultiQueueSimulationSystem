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
    public partial class SimulationTable : Form
    {
        SimulationSystem simulationsystem;
        public SimulationTable(ref SimulationSystem Program)
        {
            InitializeComponent();
            this.simulationsystem = Program;
        }

        private void FillTable() {
            Output.Rows.Add(simulationsystem.SimulationTable.Count);
            int i=0;
          while(i < simulationsystem.SimulationTable.Count){
                Output.Rows[i].Cells[0].Value = simulationsystem.SimulationTable[i].CustomerNumber.ToString();
                Output.Rows[i].Cells[1].Value = simulationsystem.SimulationTable[i].RandomInterArrival.ToString();
                Output.Rows[i].Cells[2].Value = simulationsystem.SimulationTable[i].InterArrival.ToString();
                Output.Rows[i].Cells[3].Value = simulationsystem.SimulationTable[i].ArrivalTime.ToString();
                Output.Rows[i].Cells[4].Value = simulationsystem.SimulationTable[i].RandomService.ToString();
                Output.Rows[i].Cells[5].Value = simulationsystem.SimulationTable[i].AssignedServer.ID.ToString();
                Output.Rows[i].Cells[6].Value = simulationsystem.SimulationTable[i].StartTime.ToString();
                Output.Rows[i].Cells[7].Value = simulationsystem.SimulationTable[i].ServiceTime.ToString();
                Output.Rows[i].Cells[8].Value = simulationsystem.SimulationTable[i].EndTime.ToString();
                Output.Rows[i].Cells[9].Value = simulationsystem.SimulationTable[i].TimeInQueue.ToString();
                i++;
                  }
        }
        private void View()
        {
            FillTable();
            for (int i = 0; i < simulationsystem.Servers.Count; i++)
            {
                SreverGraph form = new SreverGraph(i, simulationsystem);
                form.Show();
            }
        }

        //method to check the path related to which test case from the 3 test cases
        private String CheckForTestCase() {
            String InputPath = "";
            simulationsystem.BulidTableSimulationRun();
            View();
           
            String check = Form1.FilePath;
            if (Form1.FilePath.Contains(Constants.FileNames.TestCase1)) {
                InputPath = Constants.FileNames.TestCase1; 
            }
            else if (Form1.FilePath.Contains(Constants.FileNames.TestCase2)) {
                InputPath = Constants.FileNames.TestCase2; 
            }
            else if (Form1.FilePath.Contains(Constants.FileNames.TestCase3)) { 
                InputPath = Constants.FileNames.TestCase3; 
            }
            return InputPath;
        }
        // fill and simulate table 
        private void SImulationTableButton(object sender, EventArgs e)
        {
            String TestCasepath = "";
            TestCasepath = CheckForTestCase();


            string testingResult = TestingManager.Test(simulationsystem, TestCasepath);
            MessageBox.Show(testingResult);

        }

       // Calculate maximum queue length measure
       /* private void MaxQueueLengthButton(object sender, EventArgs e)
        {
            textBox2.Text = simulationsystem.PerformanceMeasures.MaxQueueLength.ToString();
        }
        // Calculate Average time measure
        private void AverageTimeButton(object sender, EventArgs e)
        {
            textBox1.Text = simulationsystem.PerformanceMeasures.AverageWaitingTime.ToString();
        }

        // Calculate Waiting probability measure

        private void WaitingProbabilityButton(object sender, EventArgs e)
        {
            textBox3.Text = simulationsystem.PerformanceMeasures.WaitingProbability.ToString();
        }*/
        private void Output_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ///
        }
        private void Results_Load(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {

        }

        private void Button1_AutoSizeChanged(object sender, EventArgs e)
        {

        }

        private void Button1_TextChanged(object sender, EventArgs e)
        {

        }

        private void TableResult_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        { 
            // DialogResult response = MessageBox.Show("Are you sure you wamt to exit?", "exit APP", MessageBoxButtons.YesNo);
            DialogResult response = MessageBox.Show("Are you sure you want to exit?", "exit APP", MessageBoxButtons.YesNo);
            if (response == System.Windows.Forms.DialogResult.Yes)
            {
                DialogResult response1 = MessageBox.Show("Do you want to exit all forms?", "exit APP", MessageBoxButtons.YesNo);
                if (response1 == System.Windows.Forms.DialogResult.Yes)
                {
                    Application.Exit();
                              
                }
                else {
                    this.Close(); 
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            PerformMeasures measureForm = new PerformMeasures(this.simulationsystem);
            measureForm.Show();
            this.Hide();
        }
    }
}
