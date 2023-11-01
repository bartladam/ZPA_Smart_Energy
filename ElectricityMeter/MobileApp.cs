using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricityMeter
{
    internal class MobileApp
    {
        private IPowerMeter powerMeter { get; set; }
        private Database database { get; set; }
        public MobileApp(IPowerMeter powerMeter,Database database)
        {
            this.powerMeter = powerMeter;
            this.database = database;
        }
        public string MyConsumption()
        {
            string consumption = "Mobile app" + "\n";
            var selectData = from i in database.GetInfo()
                             where (i.Contains(powerMeter.desgination.ToString()))
                             select i;
            foreach (var item in selectData)
            {
                consumption += item + "\n";
            }
            return consumption;
        }
    }
}
