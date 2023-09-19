using System;
using Ehr.Core.Aop.Attriutes;

namespace Ehr.Contracts.Recruit.Dtos
{
    public class RecruitHumanRewardDto
    {

        /// <summary>
        /// 获取或设置开始时间
        /// </summary>
        [ExField("AwardTime")]
        public DateTime BEGINDATE
        {
            get;
            set;
        } = DateTime.Now.Date;


        /// <summary>
        /// 获取或设置HUMROWID
        /// </summary>
        public int HUMROWID
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置结束时间
        /// </summary>
        [ExField("AwardTime")]
        public DateTime ENDDATE
        {
            get;
            set;
        } = DateTime.Now.Date;

        /// <summary>
        /// 获取或设置工作业绩
        /// </summary>
        [ExField("AwardName")]
        public string REWARD
        {
            get;
            set;
        } = "";

        /// <summary>
        /// 获取或设置HRNAME
        /// </summary>
        public string HRNAME
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置UPDATEDDATE
        /// </summary>
        public DateTime UPDATEDDATE
        {
            get;
            set;
        } = DateTime.Now;

    }
}
