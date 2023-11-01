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
        private Database database { get; set; }
        public Household(string adressHome, Database database)
        {
            this.adressHome = adressHome;
            this.database = database;
        }
        public void InstallPowerMeter(IPowerMeter powerMeter)
        {
            this.powerMeter = powerMeter;
        }
        public void UseElectricity()
        {
            Thread t1 = new Thread(powerMeter.Consumption);
            char e;
            Console.WriteLine("electricity turn on key: (s) as start ");
            Console.WriteLine("electricity turn off key: (e) as end ");
            do
            {
                e = Console.ReadKey().KeyChar;
                Console.WriteLine();
                if (e.Equals('s'))
                {
                    powerMeter.TurnOn(true);
                    t1.Start();
                }
                else if(e.Equals('e'))
                {
                    powerMeter.TurnOn(false);
                    Console.Clear();
                }

            } while (e == 's');
            (string, DateTime, float) measuring = powerMeter.Deduction();
            database.AddInformation(measuring.Item1, measuring.Item2, measuring.Item3);

        }
    }
}
