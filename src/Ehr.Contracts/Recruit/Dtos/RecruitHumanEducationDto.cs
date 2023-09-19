using System;
using Ehr.Core.Aop.Attriutes;

namespace Ehr.Contracts.Recruit.Dtos
{
    public class RecruitHumanEducationDto
    {


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
        /// 获取或设置培养方式
        /// </summary>
        [ExField("FormsOfLearning", "学习形式")]
        public int TRAINMODE
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置学习专业
        /// </summary>
        [ExField("MajorName")]
        public string MAJOR
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
        /// 获取或设置学校
        /// </summary>
        [ExField("SchoolName")]
        public string SCHOOLNAME
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

        /// <summary>
        /// 获取或设置取得学历
        /// </summary>
        [ExField("EducationLevel", "学历", 0)]
        public int DEGREE
        {
            get;
            set;
        }
        public int HUMROWID { get; set; }
        public string HRNAME { get; set; }
    }
}