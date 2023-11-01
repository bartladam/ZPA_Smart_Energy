using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricityMeter
{
    internal class Household
    {
        public string adressHome { get; private set; }
        public IPowerMeter powerMeter { get; private set; }
        public Household(string adressHome)
        {
            this.adressHome = adressHome;
        }
        public void InstallPowerMeter(IPowerMeter powerMeter)
        {
            this.powerMeter = powerMeter;
        }
        public void UseElectricity()
        {
            Thread t1 = new Thread(powerMeter.Consumption);
            char e;
            do
            {
                e = Console.ReadKey().KeyChar;
                if (e.Equals('e'))
                {
                    powerMeter.TurnOn(true);
                    t1.Start();
                }
                else
                {
                    powerMeter.TurnOn(false);
                }

            } while (e == 'e');

        }
    }
}
