using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricityMeter
{
    internal interface IPowerMeter
    {
        int desigination { get; }
        float countConsumption { get; }
        void Consumption();
        void TurnOn(bool status);
        (string, DateTime, float) Deduction();

    }
}
