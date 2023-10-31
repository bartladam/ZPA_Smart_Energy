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

        public void Consumption()
        {
            do
            {
                countConsumption += 0.1f;
                Console.WriteLine(countConsumption);
            } while (Console.ReadKey().KeyChar != 'e');
        }

        public (string, DateTime, float) Deduction()
        {
            return (string.Format("ZPA Smart Energy \nDesignation electricity meter: {0}", desgination), DateTime.Now, countConsumption);
        }
    }
}
