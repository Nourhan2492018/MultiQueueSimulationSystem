using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiQueueModels
{

    public class SimulationSystem
    {
        decimal waitingProbability = 0;
        Random randomNumber;
        public SimulationSystem()
        {
            //initialize instances 
            this.Servers = new List<Server>();
            this.InterarrivalDistribution = new List<TimeDistribution>();
            this.PerformanceMeasures = new PerformanceMeasures();
            this.SimulationTable = new List<SimulationCase>();
            this.randomNumber = new Random();
        }
        public int GetInterarrivalTime(int Random)
        {
            foreach (TimeDistribution timeDistribution in InterarrivalDistribution)
            {
                if (timeDistribution.MinRange <= Random)
                {
                    if (Random <= timeDistribution.MaxRange)
                    {
                        return timeDistribution.Time;
                    }

                }


            }
            return -1;
        }

        //check highst idel server 
        private int CheckHighestServerIdel(int time)
        {
            int i = 0;
            while (i < Servers.Count)
            {
                if (Servers[i].FinishTime <= time)
                    return i;
                i += 1;
            }
            return -1;
        }

        //changed
        private int CheckFristFinishedSever()
        {
            /*
             * check first server finish serveice to pass 
             * next customer to him
             */
            int timeFinishServer = 500000000;
            int ID = 0;
            int index = 0;
            while (index < Servers.Count)
            {
                if (timeFinishServer > Servers[index].FinishTime)
                {
                    timeFinishServer = Servers[index].FinishTime;
                    ID = index;
                }
                index++;
            }
            return ID;
        }
        // check highst priority server to be selected
        private int HighestPrioritySelectionserver(int time)
        {
            // check highest server is idel  
            int id = CheckHighestServerIdel(time);
            if (id != -1)
                return id;
            // if high server is busy --> then assign to first finish server
            return CheckFristFinishedSever();
        }

        //changed
        private int RandomSelectionServer(int time)
        {

            //collectidle servers
            List<int> idelservers = getListOfIdelServers(time);

            //generate random server using random method
            int idx = randomNumber.Next(0, idelservers.Count - 1);
            //return random server
            return idelservers[idx];
        }
        public List<int> getListOfIdelServers(int time)
        {
            List<int> idelservers = new List<int>();
            int finish = Servers[0].FinishTime;
            int i = 0;
            while (i < Servers.Count)
            {
                if (Servers[i].FinishTime <= time)
                    idelservers.Add(i);
                finish = Math.Min(finish, Servers[i].FinishTime);
                i += 1;
            }
            i = 0;
            //check if there is no idle server
            if (idelservers.Count == 0)
            {
                while (i < Servers.Count)
                {
                    if (Servers[i].FinishTime == finish)
                        idelservers.Add(i);
                    i += 1;
                }
            }
            return idelservers;
        }
        //changed
        private int LeastUtalizationSelectionSever(int time)
        {
            //collect idel servers
            List<int> idelserversList = getListOfIdelServers(time);
            int i = 0;
            //chech who the server works the least
            int id = idelserversList[0];
            int IDLeastServerWorking = Servers[idelserversList[0]].TotalWorkingTime;
            while (i < idelserversList.Count)
            {
                int idx = idelserversList[i];
                if (Servers[idx].TotalWorkingTime < IDLeastServerWorking)
                {
                    IDLeastServerWorking = Servers[idx].TotalWorkingTime;
                    id = idx;
                }
                i += 1;
            }
            return id;

        }
        //changed
        private int GetNextServingServer(int time)
        {
            if (SelectionMethod == Enums.SelectionMethod.HighestPriority)
            ////Highest priority the first idle server
            {

                return HighestPrioritySelectionserver(time); ;
            }
            else if (SelectionMethod == Enums.SelectionMethod.Random)
            ///random server collect idle server in list then chose randomly from the list
            {
                return RandomSelectionServer(time);
            }
            else //least utalization
            {
                return LeastUtalizationSelectionSever(time);
            }

        }
        // time = server finish time
        //check customer arrival time
        private bool ArrivalTimeCustomer(SimulationCase customer, int time)
        {
            if (customer.ArrivalTime >= time)
                return true;
            return false;

        }
        //check if assigned server to customer or it will wait in queue
        private bool AssignedServer(SimulationCase customter, int Time)
        {
            if (customter.AssignedServer == null)
                return true;
            return false;
        }
        // time is server finish time
        /*count waiting customers
         * in waiting queue*/

        private int NumberCustomersWaiting(int time)
        {
            int NumCustomerWaiting = 0;
            foreach (SimulationCase customer in SimulationTable)
            {
                /*
                 Arrival Time Customer > server finish time -->
                  then customer not waiting in Queue
                */
                if (ArrivalTimeCustomer(customer, time) != false) break;

                /*
                  Customer Not assigned To server --> 
                  then customer waiting in Queue
                */
                if (AssignedServer(customer, time) != false) NumCustomerWaiting++;
            }
            return NumCustomerWaiting;
        }
        /// <summary>
        /// //////
        /// gana 
        /// </summary>
        /// <returns></returns>
        /// 

        // get max waiting customers
        private void checkArrival(int i,int j ,int count){

            if (SimulationTable[i].StartTime >
                       SimulationTable[j].ArrivalTime)
                count++;
            j++;

        }
        private int GetMaxQueueWaitingCustomers()
        {
            //calc number of witing customers in queue
            int numberOfWaitingCustomers = 0;
            int simulationTableCount = SimulationTable.Count;
            int i = 0;
            while ( i < simulationTableCount)
            {
                int count = 0;
                int j = i + 1;
                while ( j < simulationTableCount)
                {
                    //check if curent customer began after new customer arrived
                    checkArrival(i, j,count);
                }
                numberOfWaitingCustomers = 
                    Math.Max(numberOfWaitingCustomers, count);
                i++;
            }

            return numberOfWaitingCustomers;
        }

        //calc performance measure
        private void BulidPerformaceMeasures(int MaxQueue, int TimeWaited, int CustomersWaited, int StoppingNumber)
        {

            decimal averageWaitingTime =
                 PerformanceMeasures.setValuePerformaceMeasure(MaxQueue, TimeWaited, CustomersWaited,
                 StoppingNumber);
            
        }

        //calc average waiting time
        public void AverageWaitingTime(decimal totaltimeforcustomerwaited, int customers_num)
        {
            PerformanceMeasures.CalcAverageWaitingTime(totaltimeforcustomerwaited,customers_num);
        }
        public void WaitingPropablity(decimal numofcustomerwaiting, int customer_num)
        {
            PerformanceMeasures.CalcWaitingPropablity( numofcustomerwaiting,customer_num);
        }

        private void SetSevers(int MaxFinish)
        {
            int i = 0;
            int count = Servers.Count;
            while (i< count)
            {
                setServer(i, MaxFinish);
                i++;
            }
        }
        /// <summary>
        /// /
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="MaxFinish"></param>
        private void setServer(int index, int MaxFinish)
        {
            Servers[index].setServer(index, MaxFinish);
        }
        private void StoppingNumberSimulation()
        {
            int LastCustomer = 0;
            int stopingNumber = this.StoppingNumber;
            int CustomerID = 1;
            while (CustomerID <= stopingNumber)
            {
                SimulationCase CurrentCustomer = new SimulationCase();
                CurrentCustomer.CustomerNumber = CustomerID;
                ///////////////////////////////////////
                if (CustomerID != 1)
                {
                    CurrentCustomer.RandomInterArrival = randomNumber.Next(1, 100);
                    CurrentCustomer.InterArrival = GetInterarrivalTime(CurrentCustomer.RandomInterArrival);
                }
                else
                {
                    CurrentCustomer.RandomInterArrival = 1;
                    CurrentCustomer.InterArrival = 0;
                }
                ///////////////////////////
                CurrentCustomer.ArrivalTime = LastCustomer + CurrentCustomer.InterArrival;
                LastCustomer = CurrentCustomer.ArrivalTime;
                CurrentCustomer.RandomService = randomNumber.Next(1, 100);
                SimulationTable.Add(CurrentCustomer);
                CustomerID++;
            }

        }
        private int TimeQueue(int i)
        {
            if (SimulationTable[i].TimeInQueue > 0)
                return 1;
            return 0;
        }
        private void BuildTableWithStopEndTimeCase()
        {
            List<SimulationCase> CustomerRemovingList = new List<SimulationCase>();
            int CustomersWaited = 0, TimeWaited = 0, MaxFinishTime = 0;
            int i = 0;
            while (i < SimulationTable.Count)
            {
                int idx = GetNextServingServer(SimulationTable[i].ArrivalTime);
                int start = Math.Max(Servers[idx].FinishTime, SimulationTable[i].ArrivalTime);
                int service = Servers[idx].GetServiceTime(SimulationTable[i].RandomService);
                int end = start + service;
                if (end <= StoppingNumber)
                {
                    SimulationTable[i].AssignedServer = Servers[idx];
                    SimulationTable[i].StartTime = Math.Max(SimulationTable[i].AssignedServer.FinishTime, SimulationTable[i].ArrivalTime);
                    SimulationTable[i].ServiceTime = SimulationTable[i].AssignedServer.GetServiceTime(SimulationTable[i].RandomService);
                    SimulationTable[i].EndTime = SimulationTable[i].StartTime + SimulationTable[i].ServiceTime;
                    SimulationTable[i].TimeInQueue = SimulationTable[i].StartTime - SimulationTable[i].ArrivalTime;
                    MaxFinishTime = Math.Max(SimulationTable[i].EndTime, MaxFinishTime);

                    Servers[idx].FinishTime = SimulationTable[i].EndTime;
                    Servers[idx].TotalWorkingTime += SimulationTable[i].ServiceTime;
                    Servers[idx].Served++;
                    Servers[idx].Ranges.Add(new KeyValuePair<int, int>(SimulationTable[i].StartTime, SimulationTable[i].EndTime));

                    if (TimeQueue(i)!=0)
                    {
                        TimeWaited += SimulationTable[i].TimeInQueue;
                        CustomersWaited++;
                    }

                }
                else
                    CustomerRemovingList.Add(SimulationTable[i]);
                i++;
            }
            int index = 0;
            while (index < CustomerRemovingList.Count)
            {
                SimulationTable.Remove(CustomerRemovingList[index]);
                index++;
            }
            SetSevers(MaxFinishTime);
            int MaxQueue = GetMaxQueueWaitingCustomers();
            BulidPerformaceMeasures(MaxQueue, TimeWaited, CustomersWaited,
                StoppingNumber);

        }
        private void BuildTableWithStopaNumberOfCustomers()
        {
            int MaxQueue = 0, CustomersWaited = 0, TimeWaited = 0, MaxFinish = 0;
            int index = 0;
            while ( index < SimulationTable.Count)
            {
                int idx = GetNextServingServer(SimulationTable[index].ArrivalTime);
                MaxQueue = Math.Max(MaxQueue, NumberCustomersWaiting(Servers[idx].FinishTime));
                //assign server
                SimulationTable[index].AssignedServer = Servers[idx];
                //assign start time
                SimulationTable[index].StartTime = Math.Max(SimulationTable[index].AssignedServer.FinishTime, SimulationTable[index].ArrivalTime);
                //assign service time
                SimulationTable[index].ServiceTime =
                    SimulationTable[index].AssignedServer.GetServiceTime(SimulationTable[index].RandomService);
               //assign end time
                SimulationTable[index].EndTime = SimulationTable[index].StartTime + SimulationTable[index].ServiceTime;
                SimulationTable[index].TimeInQueue = SimulationTable[index].StartTime - SimulationTable[index].ArrivalTime;

                MaxFinish = Math.Max(SimulationTable[index].EndTime, MaxFinish);

                Servers[idx].FinishTime = SimulationTable[index].EndTime;
                Servers[idx].TotalWorkingTime += SimulationTable[index].ServiceTime;
                Servers[idx].Served++;
                Servers[idx].Ranges
                    .Add(new KeyValuePair<int, int>(SimulationTable[index].StartTime, SimulationTable[index].EndTime));

                if (TimeQueue(index)!= 0)
                {
                    TimeWaited += SimulationTable[index].TimeInQueue;
                    CustomersWaited++;
                }
                index++;
            }
            
            BulidPerformaceMeasures(MaxQueue, TimeWaited, CustomersWaited, StoppingNumber);
            SetSevers(MaxFinish);
        }

       
        private void CheckStopSimulation()
        {
            if (StoppingCriteria == Enums.StoppingCriteria.NumberOfCustomers)
            {
                BuildTableWithStopaNumberOfCustomers();
            }
            else
            {
                BuildTableWithStopEndTimeCase();
            }
        }

       
        public void BulidTableSimulationRun()
        {

            StoppingNumberSimulation();
            CheckStopSimulation();
        }

       

        ///////////// INPUTS ///////////// 
        public int NumberOfServers { get; set; } //done
        public int StoppingNumber { get; set; } //done
        public List<Server> Servers { get; set; } //done
        public List<TimeDistribution> InterarrivalDistribution { get; set; } //done
        public Enums.StoppingCriteria StoppingCriteria { get; set; } //done
        public Enums.SelectionMethod SelectionMethod { get; set; } //done

        ///////////// OUTPUTS /////////////
        public List<SimulationCase> SimulationTable { get; set; }
        public PerformanceMeasures PerformanceMeasures { get; set; }
    }
}
