using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Ehr.Core.Data.Entities
{
    [Table("BASE_PARAMETER_ORGJOBS")]
    public class BASE_PARAMETER_ORGJOBS:BaseEntity
    {

        /// <summary>
        /// 获取或设置编制数量
        /// </summary>
        public int? ORGHRQTYSTD
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置招聘周期
        /// </summary>
        public int? ARRIVALDAYS
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置难度系数
        /// </summary>
        [Column(TypeName = "decimal(5,2)")]
        public decimal? DIFFICULTYVALUE
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置UPDATEDDATE
        /// </summary>
        public DateTime? UPDATEDDATE
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置INTERVIEWER3RD
        /// </summary>
        public string INTERVIEWER3RD
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
        /// 获取或设置HRCODE
        /// </summary>
        public string HRCODE
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置POSITIONLEVELCODE
        /// </summary>
        public string POSITIONLEVELCODE
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置UPDATEDID
        /// </summary>
        public int? UPDATEDID
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置POSITIONLEVELNAME
        /// </summary>
        public string POSITIONLEVELNAME
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
        /// 获取或设置CREATEDID
        /// </summary>
        public int? CREATEDID
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置RECRUITLEADTIME
        /// </summary>
        public int? RECRUITLEADTIME
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
        /// 获取或设置CREATEDNAME
        /// </summary>
        public string CREATEDNAME
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置INTERVIEWER1ST
        /// </summary>
        public string INTERVIEWER1ST
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
        /// 获取或设置UPDATEDNAME
        /// </summary>
        public string UPDATEDNAME
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

        /// <summary>
        /// 获取或设置ORGCODE
        /// </summary>
        public string ORGCODE
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
        /// 获取或设置CREATEDDATE
        /// </summary>
        public DateTime? CREATEDDATE
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置INTERVIEWER2ND
        /// </summary>
        public string INTERVIEWER2ND
        {
            get;
            set;
        }

        public string OB_JOB_ID
        {
            get;
            set;
        }

    }
}
