using System;
using Ehr.Core.Aop.Attriutes;

namespace Ehr.Contracts.Recruit.Dtos
{
    public class RecruitHumanJobsDto
    {


        /// <summary>
        /// 获取或设置UPDATEDDATE
        /// </summary>
        public DateTime UPDATEDDATE
        {
            get;
            set;
        } = DateTime.Now;

        /// <summary>
        /// 获取或设置开始日期
        /// </summary>
        [ExField("StartDate")]
        public DateTime BEGINDATE
        {
            get;
            set;
        } = DateTime.Now.Date;

        /// <summary>
        /// 获取或设置工作部门
        /// </summary>
        [ExField("department")]
        public string ORGNAME
        {
            get;
            set;
        } = "";

        /// <summary>
        /// 获取或设置岗位职务
        /// </summary>
        [ExField("JobTitle")]
        public string JOBNAME
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置HUMROWID
        /// </summary>
        public int HUMROWID
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置结束日期
        /// </summary>
        [ExField("EndDate")]
        public DateTime ENDDATE
        {
            get;
            set;
        } = DateTime.Now.Date;

        /// <summary>
        /// 获取或设置工作单位
        /// </summary>
        [ExField("CompanyName")]
        public string COMPANYNAME
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置HRNAME
        /// </summary>
        public string HRNAME
        {
            get;
            set;
        }

    }
}
