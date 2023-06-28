using JobBoard.Domain.Enums;

namespace JobBoard.Domain.Entities
{
    public class Contract
    {
        public int Id { get; set; }
        public ContractType ContractType { get; set; }
        public decimal? MinSalary { get; set; }
        public decimal? MaxSalary { get; set; }
        public Currency Currency { get; set; }
    }
}
