using System;

namespace Ehr.Application.Beisen.Recruit.Dtos
{
    public class BsOrganizationAddDto
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Abbreviation { get; set; }
        public string ParentOriginalId { get; set; }
        public string OriginalId { get; set; }
        public BsDepartmentleaderAddDto[] DepartmentLeaders { get; set; }
        public int OrderId { get; set; }
        public DateTime ModifiedTime { get; set; }
        public DateTime CreateTime { get; set; }
        public int ModifiedBy { get; set; }
        public int CreateBy { get; set; }
        public int Status { get; set; }
        public int IsDelete { get; set; }
    }
}