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
        public void Contract(Household household)
        {
            households.Add(household);
            MakePowerMeter();
            household.InstallPowerMeter(powerMeters.Dequeue());
        }
        private void MakePowerMeter()
        {
            powerMeters.Enqueue(new PowerMeter());         
        }
        public string GetInformationFromDatabase()
        {
            string dataFromPowerMeters = "ZPA Smart energy database" + "\n";
            foreach (string item in database.GetInfo())
            {
                dataFromPowerMeters += item + "\n";
            }
            return dataFromPowerMeters;
        }

    }
}
