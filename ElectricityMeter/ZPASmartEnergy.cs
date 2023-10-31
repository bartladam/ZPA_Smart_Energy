using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricityMeter
{
    internal class ZPASmartEnergy
    {
        public string nameCompany { get; init; }
        public string adressCompany { get; init; }
        private Queue<IPowerMeter> powerMeters { get; set; }
        private Database database { get; set; }
        private List<Household> households { get; init; }
        public ZPASmartEnergy(string nameCompany, string adressCompany, Database database)
        {
            this.nameCompany = nameCompany;
            this.adressCompany = adressCompany;
            powerMeters = new Queue<IPowerMeter>();
            this.database = database;
            households = new List<Household>();
        }
        public void Contract(Household household, int numberPowerMeter)
        {
            households.Add(household);
            MakePowerMeter(numberPowerMeter);
        }
        private void MakePowerMeter(int number)
        {
            for (int i = 0; i < number; i++)
            {
                powerMeters.Enqueue(new PowerMeter());
            }
        }

    }
}
