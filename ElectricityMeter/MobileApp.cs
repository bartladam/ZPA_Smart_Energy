using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricityMeter
{
    /// <summary>
    /// Mobile app shows customer his consumption
    /// </summary>
    internal class MobileApp
    {
        /// <summary>
        /// Mobile app have to know which power meter must watch
        /// </summary>
        private IPowerMeter powerMeter { get; set; }
        /// <summary>
        /// Mobile app looks to ZPA Smart energy database for data his power meter
        /// </summary>
        private Database database { get; set; }
        public MobileApp(IPowerMeter powerMeter,Database database)
        {
            this.powerMeter = powerMeter;
            this.database = database;
        }
        /// <summary>
        /// Mobile app watch client consumption
        /// </summary>
        /// <returns></returns>
        public string MyConsumption()
        {
            string consumption = "Mobile app" + "\n\n";
            var selectData = from i in database.GetInfo()
                             where (i.Contains(powerMeter.desigination.ToString()))
                             select i;
            foreach (var item in selectData)
            {
                consumption += item + "\n";
            }
            return consumption;
        }
    }
}
