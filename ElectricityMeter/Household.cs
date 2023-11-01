using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricityMeter
{
    /// <summary>
    /// Place where ZPA Smart energy install power meter
    /// </summary>
    internal class Household
    {
        /// <summary>
        /// ZPA Smart energy have to know, where they will install new power meter
        /// </summary>
        public string adressHome { get; private set; }
        /// <summary>
        /// Household have own power meter
        /// </summary>
        public IPowerMeter powerMeter { get; private set; }
        /// <summary>
        /// Power meter after switch off electrcity send actual consumption to database ZPA Smart energy 
        /// </summary>
        private Database database { get; set; }
        public Household(string adressHome, Database database)
        {
            this.adressHome = adressHome;
            this.database = database;
        }
        /// <summary>
        /// Owner household get installed new power meter from ZPA Smart energy
        /// </summary>
        /// <param name="powerMeter"></param>
        public void InstallPowerMeter(IPowerMeter powerMeter)
        {
            this.powerMeter = powerMeter;
        }
        /// <summary>
        /// Turn on / Turn off electrcity in household
        /// </summary>
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
