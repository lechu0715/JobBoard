namespace JobBoard.Domain.Entities
{
    public class Company
    {
        public int Id { get; set; }
        public string ShortName { get; set; }
        public string FullName { get; set; }
        public string Website { get; set; }
        public int CompanySize { get; set; }
        public string Logo { get; set; }
        public ICollection<JobOffer> JobOffers { get; set; } = new List<JobOffer>();
    }
}
