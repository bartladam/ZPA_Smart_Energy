using ElectricityMeter;

Console.Title = "ZPA Smart Energy";
Database data = new Database();
ZPASmartEnergy smartenergy = new ZPASmartEnergy("ZPA Smart energy", "Křižíkova", data);
Household house1 = new Household("Hřebenova", data);
Household house2 = new Household("Marečkova", data);
smartenergy.Contract(house1);
smartenergy.Contract(house2);

MobileApp app1 = new MobileApp(house1.powerMeter, data);
MobileApp app2 = new MobileApp(house2.powerMeter, data);

for (int i = 0; i < 4; i++)
{
    Console.WriteLine("Hello master");
    Console.WriteLine("(y) - use energy");
    if (Console.ReadLine().Equals("y"))
        house1.UseElectricity();
}

for (int i = 0; i < 2; i++)
{
    Console.WriteLine("Hello master");
    Console.WriteLine("(y) - use energy");
    if (Console.ReadLine().Equals("y"))
        house2.UseElectricity();
}
Console.WriteLine(app1.MyConsumption());
Console.WriteLine("----------------");
Console.WriteLine(smartenergy.GetInformationFromDatabase());

