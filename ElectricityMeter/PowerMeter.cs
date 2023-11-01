using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricityMeter
{
    /// <summary>
    /// Power meter to household
    /// </summary>
    internal class PowerMeter : IPowerMeter
    {
        /// <summary>
        /// Mobile app finds data in database via designation
        /// </summary>
        public int desigination { get; private set; }
        /// <summary>
        /// Current consumption in household
        /// </summary>
        public float countConsumption { get; private set; }
        /// <summary>
        /// True = Consumption electricity in household (lights, appliances etc.) False = Consumption none
        /// </summary>
        public bool status { get; private set; } = false;
        /// <summary>
        /// Each new power meter get designation
        /// </summary>
        private Random randomDesigination { get; set; }
        public PowerMeter()
        {
            randomDesigination = new Random();
            this.desigination = randomDesigination.Next();
        }
        /// <summary>
        /// Lights, appliances etc. use electricity for operation. Power meter is measuring current consumption
        /// </summary>
        public void Consumption()
        {
            while (status)
            {
                countConsumption += 0.1f;
                Console.WriteLine("Actual consumption: {0} kWh",Math.Round(countConsumption, 2));
                Task.Delay(800).Wait();
            }
        }
        /// <summary>
        /// Turn on / Turn off electricity in household
        /// </summary>
        /// <param name="status"></param>
        public void TurnOn(bool status)
        {
            this.status = status;
        }
        /// <summary>
        /// Current consumption
        /// </summary>
        /// <returns></returns>
        public (string, DateTime, float) Deduction()
        {
            return (string.Format("ZPA Smart Energy \nDesignation electricity meter: {0}", desigination), DateTime.Now, countConsumption);
        }
    }
}
