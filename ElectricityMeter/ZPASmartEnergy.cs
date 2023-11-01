namespace ElectricityMeter
{
    /// <summary>
    /// Company focused on creating smart power meters
    /// </summary>
    internal class ZPASmartEnergy
    {
        /// <summary>
        /// Company name is imporatant for recognize this company from others
        /// </summary>
        public string nameCompany { get; init; }
        /// <summary>
        /// Client have to know where is residence of this company
        /// </summary>
        public string adressCompany { get; init; }
        /// <summary>
        /// Created power meters we saved here until when they are installed in household
        /// </summary>
        private Queue<IPowerMeter> powerMeters { get; set; }
        /// <summary>
        /// This database we are using for saving measuring data from power meter
        /// </summary>
        private Database database { get; set; }
        /// <summary>
        /// We are saving all households where we installed power meter
        /// </summary>
        private List<Household> households { get; init; }
        public ZPASmartEnergy(string nameCompany, string adressCompany, Database database)
        {
            this.nameCompany = nameCompany;
            this.adressCompany = adressCompany;
            powerMeters = new Queue<IPowerMeter>();
            this.database = database;
            households = new List<Household>();
        }
        /// <summary>
        /// Customer wants to new power meter to his household
        /// </summary>
        /// <param name="household"></param>
        public void Contract(Household household)
        {
            households.Add(household);
            MakePowerMeter();
            household.InstallPowerMeter(powerMeters.Dequeue());
        }
        /// <summary>
        /// New power meter. We do not offer old power meter
        /// </summary>
        private void MakePowerMeter()
        {
            powerMeters.Enqueue(new PowerMeter());         
        }
        /// <summary>
        /// All measuring data from each household where we installed power meter
        /// </summary>
        /// <returns></returns>
        public string GetInformationFromDatabase()
        {
            string dataFromPowerMeters = "ZPA Smart energy database" + "\n\n";
            foreach (string item in database.GetInfo())
            {
                dataFromPowerMeters += item + "\n";
            }
            return dataFromPowerMeters;
        }
        public override string ToString()
        {
            return adressCompany;
        }

    }
}
