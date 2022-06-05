using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using MultiQueueModels;
using System.ComponentModel;
using System.Data;
using MultiQueueTesting;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MultiQueueSimulation
{
    public partial class Form1 : Form
    {
       // variables
        SimulationSystem simulationsystem;
        public static string FilePath = "";    //passing to open InpoutText.cs to test//
        static decimal commulativeprobability;
        int Counter = 0;
        List<String> file = new List<string>();
       
        
        public Form1()
        {
            InitializeComponent();
            simulationsystem = new SimulationSystem();
        }
        // read data from the test case file
        private void ReadTeastCaseFile()
        {
            commulativeprobability = 0;
            for (int i = 13; true; i++)
            {
                if (file[i] == "")
                {
                    Counter = i + 2;
                    break;
                }
                string[] words = file[i].Split(',');
                simulationsystem.InterarrivalDistribution.Add(TimeDIS(words));
            }

            int Count = int.Parse(file[1]);
            simulationsystem.StoppingNumber = int.Parse(file[4]);
            if (int.Parse(file[7]) == 1)
            {
                simulationsystem.StoppingCriteria = Enums.StoppingCriteria.NumberOfCustomers;
            }
            else
            {
                simulationsystem.StoppingCriteria = Enums.StoppingCriteria.SimulationEndTime;
            }
            if (int.Parse(file[10]) == 1)
            {
                simulationsystem.SelectionMethod = Enums.SelectionMethod.HighestPriority;
            }
            else if (int.Parse(file[10]) == 2)
            {
                simulationsystem.SelectionMethod = Enums.SelectionMethod.Random;
            }
            else
            {
                simulationsystem.SelectionMethod = Enums.SelectionMethod.LeastUtilization;
            }
            simulationsystem.NumberOfServers = Count;
        }
        static public TimeDistribution TimeDIS(string[] Word)
        {

            TimeDistribution TDIST = new TimeDistribution();
            TDIST.Time = int.Parse(Word[0]);
            TDIST.Probability = decimal.Parse(Word[1]);
            TDIST.MinRange = decimal.ToInt32(commulativeprobability * 100 + 1);
            commulativeprobability += TDIST.Probability;
            TDIST.MaxRange = decimal.ToInt32(commulativeprobability * 100);
            TDIST.CummProbability = commulativeprobability;
            return TDIST;
        }
        // allow user to choose the test case file he want from his pc
        private void ChooseFilebutton(object sender, EventArgs e) // 1
        {

            String Path = null;
            DialogResult InpoutText = openFileDialog1.ShowDialog();
            if (InpoutText == DialogResult.OK) // Test InpoutText.
            {
                textBox1.Text = openFileDialog1.FileName;//

                Path = textBox1.Text;

                FilePath = Path;
            }
            Console.WriteLine(InpoutText); // <-- For debugging use.
            FileStream fs = new FileStream(Path, FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            while (sr.Peek() != -1)
            {
                file.Add(sr.ReadLine());
            }
            sr.Close();
            fs.Close();
        }
      
        // this button read the file first then open the table simulation form
        private void Simulationbutton(object sender, EventArgs e)
        {
            ReadTeastCaseFile();
            for (int i = 1; i <= simulationsystem.NumberOfServers; i++)
            {
                commulativeprobability = 0;
                Server Stmp = new Server();
                while (Counter != file.Count)
                {

                    if (file[Counter] == "")
                    {
                        Counter += 2;
                        break;
                    }
                    string[] wordss = file[Counter].Split(',');
                    Stmp.ID = i;
                    Stmp.TimeDistribution.Add(TimeDIS(wordss));
                    Counter++;
                }
                simulationsystem.Servers.Add(Stmp);
            }
            SimulationTable form = new SimulationTable(ref simulationsystem);
            form.Show();
            Form1 form1 = new Form1();
            form1.Close();
        }

        private void ClientGrid(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void label1_Click(object sender, EventArgs e)
        {

        }
        // exit button
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult response = MessageBox.Show("Are you sure you want to exit?", "exit APP", MessageBoxButtons.YesNo);
            if (response == System.Windows.Forms.DialogResult.Yes)
            {
                this.Close();
            }
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

      
        private void LoadForm(object sender, EventArgs e)
        {

        }
        private void Main_Load(object sender, EventArgs e)
        {
            ///
        }

       

      
    }
}
