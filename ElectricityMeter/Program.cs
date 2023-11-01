using ElectricityMeter;

Console.Title = "ZPA Smart Energy";

// New database for ZPA Smart energy
Database data = new Database();

// Created instance ZPA Smart energy
ZPASmartEnergy smartenergy = new ZPASmartEnergy("ZPA Smart energy", "Komenského 821\nStřední Předměstí\n541 01 Trutnov\r\n\r\n", data);

// Households where we install our product and where we watch their consumption
Household house1 = new Household("Maříkova 15/8", data);
Household house2 = new Household("Trefná 147/2", data);
smartenergy.Contract(house1);
smartenergy.Contract(house2);

// Householders get app for watching their consumption
MobileApp app1 = new MobileApp(house1.powerMeter, data);
MobileApp app2 = new MobileApp(house2.powerMeter, data);

// Tested functionality
Console.WriteLine("House on adress: {0}", house1.adressHome);
Console.WriteLine("Press any key to continue...");
Console.ReadKey();
Console.Clear();
house1.UseElectricity();

Console.WriteLine("House on adress: {0}", house2.adressHome);
Console.WriteLine("Press any key to continue...");
Console.ReadKey();
Console.Clear();
house2.UseElectricity();

Console.WriteLine(app1.MyConsumption());
Console.WriteLine("----------------");
Console.WriteLine(smartenergy.GetInformationFromDatabase());
Console.ReadKey();


