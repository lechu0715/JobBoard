using JobBoard.Domain.Enums;

namespace JobBoard.Domain.Entities
{
    public class JobOffer
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public string PositionName { get; set; }
        public Seniority Seniority { get; set; }
        public Stack Stack { get; set; }
        public string Description { get; set; }
        public bool IsFullRemote { get; set; }
        public decimal MinimumRequiredExperience { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public bool OnlineInterviewAvailable { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ICollection<Skill> MainSkills { get; set; } = new List<Skill>();
        public ICollection<Skill> SecondarySkills { get; set; } = new List<Skill>();
        public ICollection<Contract> Contracts { get; set; } = new List<Contract>();
        public ICollection<Address> Addresses { get; set; } = new List<Address>();
    }
}
