using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricityMeter
{
    internal class PowerMeter : IPowerMeter
    {
        public string desgination { get; private set; }
        public float countConsumption { get; private set; }
        public bool status { get; private set; } = false;
        public void Consumption()
        {
            while (status)
            {
                Task.Delay(500).Wait();
                countConsumption += 0.1f;
                Console.WriteLine(countConsumption);
            }
        }
        public void TurnOn(bool status)
        {
            if (status)
                this.status = status;
            else
                this.status = status;
        }
        public (string, DateTime, float) Deduction()
        {
            return (string.Format("ZPA Smart Energy \nDesignation electricity meter: {0}", desgination), DateTime.Now, countConsumption);
        }
    }
}
