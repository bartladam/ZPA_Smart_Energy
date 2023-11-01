using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace ElectricityMeter
{
    internal class Database
    {
        private List<string> information { get; set; }
        public Database()
        {
            information = new List<string>();
        }
        public void AddInformation(string text, DateTime dt, float count)
        {
            information.Add(string.Format("{0}\n{1}\nTotal consumption: {2} kWh\n", text, dt.ToString(), Math.Round(count, 2).ToString()));
        }
        public List<string> GetInfo() => information;

        
           

    }
}
