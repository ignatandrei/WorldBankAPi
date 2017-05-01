namespace WorldBank.Models
{
    public class Country
    {
        public string id { get; set; }
        public string iso2Code { get; set; }
        public string name { get; set; }
        public Region region { get; set; }
        public Adminregion adminregion { get; set; }
        public IncomeLevel incomeLevel { get; set; }
        public LendingType lendingType { get; set; }
        public string capitalCity { get; set; }
        public string longitude { get; set; }
        public string latitude { get; set; }
    }
}
