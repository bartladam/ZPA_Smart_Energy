using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricityMeter
{
    internal interface IPowerMeter
    {
        string desgination { get; }
        float countConsumption { get; }
        void Consumption();
        (string, DateTime, float) Deduction();

    }
}
