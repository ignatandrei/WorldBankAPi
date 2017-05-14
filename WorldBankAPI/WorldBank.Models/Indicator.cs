namespace WorldBank.Models
{
    public class Indicator
    {
        public string id { get; set; }
        public string name { get; set; }
        public Source source { get; set; }
        public string sourceNote { get; set; }
        public string sourceOrganization { get; set; }
        public Topic[] topics { get; set; }
    }

}
