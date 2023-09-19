using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Ehr.Core.Data.Entities
{
    [Table("BASE_PARAMETER_HUMANJOBS")]
    [Keyless]
    public class BASE_PARAMETER_HUMANJOBS:BaseEntity
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
        /// 获取或设置JOBNAME
        /// </summary>
        public string JOBNAME
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
        /// 获取或设置JOBTYPENAME
        /// </summary>
        public string JOBTYPENAME
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置REMARK
        /// </summary>
        public string REMARK
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置ROWID
        /// </summary>
        public int ROWID
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
        /// 获取或设置PYSHORT
        /// </summary>
        public string PYSHORT
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
        /// 获取或设置JOBTYPE
        /// </summary>
        public int JOBTYPE
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置JOBCODE
        /// </summary>
        public string JOBCODE
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
        /// 获取或设置ISENABLE
        /// </summary>
        public int ISENABLE
        {
            get;
            set;
        }


    }
}
