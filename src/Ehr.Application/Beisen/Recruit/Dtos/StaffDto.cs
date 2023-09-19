using System;

namespace Ehr.Application.Beisen.Recruit.Dtos
{
    public class StaffDto
    {
        public int departmentId { get; set; }
        public string departmentName { get; set; }
        public string jobCode { get; set; }
        public int lineManagerId { get; set; }
        public string staffCode { get; set; }
        public int staffStatus { get; set; }
        public int isDelete { get; set; }
        public int userId { get; set; }
        public int tenantId { get; set; }
        public string email { get; set; }
        public int userType { get; set; }
        public int userStatus { get; set; }
        public int origin { get; set; }
        public string originalId { get; set; }
        public string name { get; set; }
        public string sex { get; set; }
        public string mobile { get; set; }
        public string workPhone { get; set; }
        public string qq { get; set; }
        public string bizTitleId { get; set; }
        public string weChat { get; set; }
        public DateTime modifiedTime { get; set; }
        public DateTime createTime { get; set; }
        public int modifiedBy { get; set; }
        public int createBy { get; set; }
        public int version { get; set; }
    }
}