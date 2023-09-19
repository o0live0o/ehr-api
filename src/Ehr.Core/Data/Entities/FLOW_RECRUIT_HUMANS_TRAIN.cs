using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ehr.Core.Data.Entities
{
    [Table("FLOW_RECRUIT_HUMANS_TRAIN")]
    public class FLOW_RECRUIT_HUMANS_TRAIN: BaseEntity
    {


        /// <summary>
        /// 获取或设置CREATEDNAME
        /// </summary>
        public string CREATEDNAME
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
        /// 获取或设置UPDATEDNAME
        /// </summary>
        public string UPDATEDNAME
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置TRAINCONTENT
        /// </summary>
        public string TRAINCONTENT
        {
            get;
            set;
        } 

        /// <summary>
        /// 获取或设置CERTIFICATE
        /// </summary>
        public string CERTIFICATE
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
        /// 获取或设置CREATEDDATE
        /// </summary>
        public DateTime CREATEDDATE
        {
            get;
            set;
        } = DateTime.Now;

        /// <summary>
        /// 获取或设置ENDDATE
        /// </summary>
        public DateTime ENDDATE
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
        /// 获取或设置TRAINORG
        /// </summary>
        public string TRAINORG
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
        /// 获取或设置UPDATEDID
        /// </summary>
        public int UPDATEDID
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


    }
}
