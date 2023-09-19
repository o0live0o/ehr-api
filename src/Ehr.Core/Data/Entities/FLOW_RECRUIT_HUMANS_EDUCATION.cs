using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ehr.Core.Data.Entities
{
    /// <summary>
    /// 教育经历
    /// </summary>
    [Table("FLOW_RECRUIT_HUMANS_EDUCATION")]
    public class FLOW_RECRUIT_HUMANS_EDUCATION : BaseEntity
    {

        /// <summary>
        /// 获取或设置CREATEDID
        /// </summary>
        public int CREATEDID
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
        /// 获取或设置BEGINDATE
        /// </summary>
        public DateTime BEGINDATE
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
        /// 获取或设置TRAINMODE
        /// </summary>
        public int TRAINMODE
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置MAJOR
        /// </summary>
        public string MAJOR
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
        /// 获取或设置CREATEDNAME
        /// </summary>
        public string CREATEDNAME
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置ENDDATE
        /// </summary>
        public DateTime ENDDATE
        {
            get;
            set;
        } = new DateTime(1970, 1, 1);

        /// <summary>
        /// 获取或设置UPDATEDNAME
        /// </summary>
        public string UPDATEDNAME
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置SCHOOLNAME
        /// </summary>
        public string SCHOOLNAME
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
        /// 获取或设置CREATEDDATE
        /// </summary>
        public DateTime CREATEDDATE
        {
            get;
            set;
        } = DateTime.Now;

        /// <summary>
        /// 获取或设置UPDATEDDATE
        /// </summary>
        public DateTime UPDATEDDATE
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置DEGREE
        /// </summary>
        public int DEGREE
        {
            get;
            set;
        }


    }
}
