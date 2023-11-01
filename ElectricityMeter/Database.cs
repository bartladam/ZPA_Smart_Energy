using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace ElectricityMeter
{
    /// <summary>
    /// ZPA Smart energy database for saving measuring data
    /// </summary>
    internal class Database
    {
        /// <summary>
        /// We are saving measuring data from household
        /// </summary>
        private List<string> information { get; set; }
        public Database()
        {
            information = new List<string>();
        }
        /// <summary>
        /// Adding to database new measuring data
        /// </summary>
        /// <param name="text"></param>
        /// <param name="dt"></param>
        /// <param name="count"></param>
        public void AddInformation(string text, DateTime dt, float count)
        {
            information.Add(string.Format("{0}\n{1}\nTotal consumption: {2} kWh\n", text, dt.ToString(), Math.Round(count, 2).ToString()));
        }
        public List<string> GetInfo() => information;

        
           

    }
}
