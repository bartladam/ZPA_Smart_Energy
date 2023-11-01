using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricityMeter
{
    internal class PowerMeter : IPowerMeter
    {
        public int desgination { get; private set; }
        public float countConsumption { get; private set; }
        public bool status { get; private set; } = false;
        private Random randomDesgination { get; set; }
        public PowerMeter()
        {
            randomDesgination = new Random();
            this.desgination = randomDesgination.Next();
        }
        public void Consumption()
        {
            while (status)
            {
                countConsumption += 0.1f;
                Console.WriteLine("Actual consumption: {0} kWh",Math.Round(countConsumption, 2));
                Task.Delay(800).Wait();
            }
        }
        public void TurnOn(bool status)
        {
            this.status = status;
        }
        public (string, DateTime, float) Deduction()
        {
            return (string.Format("ZPA Smart Energy \nDesignation electricity meter: {0}", desgination), DateTime.Now, countConsumption);
        }
    }
}
