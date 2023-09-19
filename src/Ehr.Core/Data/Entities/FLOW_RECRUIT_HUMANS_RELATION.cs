using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ehr.Core.Data.Entities
{
    [Table("FLOW_RECRUIT_HUMANS_RELATION")]

    public class FLOW_RECRUIT_HUMANS_RELATION : BaseEntity
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
        /// 获取或设置ISYURUNEMPLOYEE
        /// </summary>
        public int ISYURUNEMPLOYEE
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置RELATION
        /// </summary>
        public string RELATION
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置CREATEDDATE
        /// </summary>
        public DateTime CREATEDDATE
        {
            get;
            set;
        }  = DateTime.Now;

        /// <summary>
        /// 获取或设置FULLNAME
        /// </summary>
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
        }

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
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
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
        public string JOBNAME
        {
            get;
            set;
        }


    }
}
