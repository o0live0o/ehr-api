using System;

namespace Ehr.Application.Beisen.Recruit.Dtos
{
    public class OfferDto
    {
        public string PersonID { get; set; }
        public string JobID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string IDType { get; set; }
        public string IDNumber { get; set; }
        public string JobName { get; set; }
        public string NeedDepartment { get; set; }
        public string ApplyChannel { get; set; }
        public DateTime ApplyDate { get; set; }
        public bool IsComplete { get; set; }
        public int ApprovalState { get; set; }
        public object Attachment { get; set; }
        public string PersonCID { get; set; }
        public string JobCode { get; set; }
        public int OfferApprovalSender { get; set; }
        public string ID { get; set; }
        public Extendinfo[] ExtendInfos { get; set; }
        public int CreateBy { get; set; }
        public string CreatedTime { get; set; }
        public string EndApprovalTime { get; set; }
    }

    public class Extendinfo
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public string Text { get; set; }
        public string OtherCode { get; set; }
    }

}