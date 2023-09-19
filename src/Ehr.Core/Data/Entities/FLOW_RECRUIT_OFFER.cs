using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ehr.Core.Data.Entities
{
    [Table("FLOW_RECRUIT_OFFER")]
    public class FLOW_RECRUIT_OFFER : BaseEntity
    {

        /// <summary>
        /// 获取或设置ISARRIVAL
        /// </summary>
        public int ISARRIVAL
        {
            get;
            set;
        } = 0;

        /// <summary>
        /// 获取或设置CREATEDDATE
        /// </summary>
        public DateTime CREATEDDATE
        {
            get;
            set;
        } = DateTime.Now;

        /// <summary>
        /// 获取或设置ORGNAME
        /// </summary>
        public string ORGNAME
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置CONTRACTDATE
        /// </summary>
        public string CONTRACTDATE
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置PERSONNAME
        /// </summary>
        public string PERSONNAME
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
        /// 获取或设置BILLSTATE
        /// </summary>
        public int BILLSTATE
        {
            get;
            set;
        } = 1;

        /// <summary>
        /// 获取或设置POSITIONLEVELCODE
        /// </summary>
        public string POSITIONLEVELCODE
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置IDCARDNO
        /// </summary>
        public string IDCARDNO
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置COMPANYADDRESS
        /// </summary>
        public string COMPANYADDRESS
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
        /// 获取或设置COMPANYNAME
        /// </summary>
        public string COMPANYNAME
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置VIEWROWID
        /// </summary>
        [Key]
        public int VIEWROWID
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置CANCELREASON
        /// </summary>
        public string CANCELREASON
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置ARRIVALDATE
        /// </summary>
        public DateTime ARRIVALDATE
        {
            get;
            set;
        } = new DateTime(1970, 1, 1);

        /// <summary>
        /// 获取或设置UPDATEDID
        /// </summary>
        public int UPDATEDID
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
        /// 获取或设置PERSONTEL
        /// </summary>
        public string PERSONTEL
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置WRITTENDOC
        /// </summary>
        public string WRITTENDOC
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置CANCELDATE
        /// </summary>
        public DateTime? CANCELDATE
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
        /// 获取或设置IDTYPE
        /// </summary>
        public int IDTYPE
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
        /// 获取或设置OPTIONFLAG
        /// </summary>
        public int OPTIONFLAG
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置TRIALSALARY
        /// </summary>
        [Column(TypeName = "decimal(9,0)")]
        public decimal? TRIALSALARY
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置OFFERDATE
        /// </summary>
        public DateTime? OFFERDATE
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置REGULARSALARY
        /// </summary>
        [Column(TypeName = "decimal(9,0)")]
        public decimal? REGULARSALARY
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
        /// 获取或设置REQUESTNO
        /// </summary>
        public string REQUESTNO
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
        /// 获取或设置COMPANYTEL
        /// </summary>
        public string COMPANYTEL
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
        } = "";

        /// <summary>
        /// 获取或设置TRIALDATE
        /// </summary>
        public string TRIALDATE
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

        public string BS_JOBID { get; set; }

        public string BS_PERSIONID { get; set; }

    }
}
