namespace Ehr.Contracts.Base.Dtos
{
    public class HumanStatusResultDto
    {
        public bool AllowLogin { get; set; }

        public int Status { get; set; }

        public string Name { get;set;}

        public string Description { get; set; }
    }
}