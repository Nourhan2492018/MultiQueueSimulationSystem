
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiQueueModels
{
    /// <summary>
    /// /
    /// </summary>
    public class Server
    {
        public Server()
        {
            //TimeDistribution is Probability
            this.TimeDistribution = new List<TimeDistribution>();
            //
            this.Served = 0;
            //
            this.IdleProbability = 0;
            this.TotalIdleTime = 0;
            this.Utilization = 0;
            this.TotalWorkingTime = 0;
            this.AverageServiceTime = 0;
            this.FinishTime = 0;
            this.Ranges = new List<KeyValuePair<int, int>>();
        }
        public int CheckRange(TimeDistribution customer, int Random)
        {
            if (customer.MinRange <= Random && Random <= customer.MaxRange)
                return 1;
            return 0;
        }
        public int GetServiceTime(int Random)
        {
            //TimeDistribution is Probability
            // check which ServiceTime depandent on ranges
            // c is number of iterations
            int c = 0;
            TimeDistribution customer;
            while (c < TimeDistribution.Capacity)
            {
                customer = TimeDistribution[c];
                int check = CheckRange(customer, Random);
                if (check != 0)
                    return customer.Time;
                c = c + 1;
            }
            /*foreach (TimeDistribution customer in TimeDistribution) {
                int check = CheckRange(customer, Random);
                if (check !=0)
                    return customer.Time;
            }*/
            // if customer is first one 
            return 1;
        }
        /// <summary>
        /// / .............
        /// </summary>
        /// <param name="i"></param>
        /// <param name="MaxFinish"></param>
        public void setServer(int i, int MaxFinish)
        {
            TotalIdleTime = MaxFinish - TotalWorkingTime;
            IdleProbability = TotalIdleTime;
            IdleProbability /= MaxFinish;
            AverageServiceTime = TotalWorkingTime;
            AverageServiceTime /= Math.Max(Served, 1);
            Utilization = TotalWorkingTime;
            Utilization /= MaxFinish;
        }

        //       
        public int Served { get; set; }
        /// <summary>
        /// accum probality 
        /// for min range & max range
        /// </summary>
        public List<KeyValuePair<int, int>> Ranges;

        /// <summary>
        /// 
        /// </summary>
        public int ID { get; set; }
        public decimal IdleProbability { get; set; }
        public decimal AverageServiceTime { get; set; }
        public decimal Utilization { get; set; }
        public List<TimeDistribution> TimeDistribution;

        //optional if needed use them
        // when the server will be available
        public int FinishTime { get; set; }
        public int TotalWorkingTime { get; set; }
        public int TotalIdleTime { get; set; }

    }
}

