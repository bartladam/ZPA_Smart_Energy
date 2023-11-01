using ElectricityMeter;
using System.Linq.Expressions;

IPowerMeter powermeter = new PowerMeter();
Thread t1 = new Thread(powermeter.Consumption);
char e;
do
{
    e = Console.ReadKey().KeyChar;
    if (e.Equals('e'))
    {
        powermeter.TurnOn(true);
        t1.Start();
    }
    else
    {
        powermeter.TurnOn(false);
       
    }

} while (e == 'e');


Console.WriteLine(powermeter.Deduction()); 

