
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiQueueModels
{
    /// <summary>
    /// //
    /// </summary>
    public class PerformanceMeasures
    {
        public PerformanceMeasures()
        {

        }
        public decimal AverageWaitingTime { get; set; }
        public int MaxQueueLength { get; set; }
        public decimal WaitingProbability { get; set; }
        public void CalcAverageWaitingTime(decimal totaltimeforcustomerwaited, int customers_num)
        {
            AverageWaitingTime = totaltimeforcustomerwaited / customers_num;
        }
        public void CalcWaitingPropablity(decimal numofcustomerwaiting, int customer_num)
        {
            WaitingProbability = numofcustomerwaiting / customer_num;
        }
        public decimal setValuePerformaceMeasure(int MaxQueue, int TimeWaited, int CustomersWaited, int StoppingNumber)
        {
            //max queue lenght
            //max queue lenght
            //max queue lenght
            MaxQueueLength = MaxQueue;
            //calc waiting time
            decimal averageWaitingTime = TimeWaited;
            //average time / number of customers of server
            AverageWaitingTime = averageWaitingTime;
            AverageWaitingTime /= StoppingNumber;
            //calc waiting number

            decimal waitingProbability = CustomersWaited;
            WaitingProbability = waitingProbability;
            //av
            WaitingProbability /= StoppingNumber;
            return averageWaitingTime;
        }
    }
}
