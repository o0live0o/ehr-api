using System;
using Ehr.Core.Aop.Attriutes;

namespace Ehr.Contracts.Recruit.Dtos
{
    public class RecruitHumanRelation
    {
        /// <summary>
        /// 获取或设置ANNUALINCOME
        /// </summary>
        public string ANNUALINCOME
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置UPDATEDNAME
        /// </summary>
        public string UPDATEDNAME
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置HRMOBIL
        /// </summary>
        public string HRMOBIL
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置CREATEDNAME
        /// </summary>
        public string CREATEDNAME
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置COMPANYNAME
        /// </summary>
        [ExField("CompanyName")]
        public string COMPANYNAME
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置ORGNAME
        /// </summary>
        public string ORGNAME
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
        /// 获取或设置是否雨润员工
        /// </summary>
        public int ISYURUNEMPLOYEE
        {
            get;
            set;
        } = 0;

        /// <summary>
        /// 获取或设置亲属关系
        /// </summary>
        [ExField("relation")]
        public string RELATION
        {
            get;
            set;
        }


        /// <summary>
        /// 获取或设置亲属姓名
        /// </summary>
        [ExField("Name")]
        public string FULLNAME
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
        /// 获取或设置HRNAME
        /// </summary>
        public string HRNAME
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置ID
        /// </summary>
        public int ID
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置CREATEDID
        /// </summary>
        public int CREATEDID
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置UPDATEDID
        /// </summary>
        public int UPDATEDID
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置JOBNAME
        /// </summary>
        [ExField("JobTitle")]
        public string JOBNAME
        {
            get;
            set;
        }


    }
}
