using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ehr.Core.Data.Entities
{
    /// <summary>
    /// 人员信息
    /// </summary>
    [Table("FLOW_RECRUIT_HUMANS")]
    public class FLOW_RECRUIT_HUMANS : BaseEntity
    {


        /// <summary>
        /// 获取或设置0-未婚1-已婚 2-离异3-丧偶
        /// </summary>
        public int MARITALSTATUS
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置1-农业2-非农
        /// </summary>
        public int HOUSEHOLDTYPE
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置HOBBY
        /// </summary>
        public string HOBBY
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
        /// 获取或设置HOMEADDRESS
        /// </summary>
        public string HOMEADDRESS
        {
            get;
            set;
        } = "";

        /// <summary>
        /// 获取或设置NATIVEPLACE
        /// </summary>
        public string NATIVEPLACE
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
        /// 获取或设置HRPYSHORT
        /// </summary>
        public string HRPYSHORT
        {
            get;
            set;
        } = "";

        /// <summary>
        /// 获取或设置EMERGENCYLINK
        /// </summary>
        public string EMERGENCYLINK
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
        } = 0;

        /// <summary>
        /// 获取或设置HEIGHT
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal HEIGHT
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置BANKNO
        /// </summary>
        public string BANKNO
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
        /// 获取或设置ORGCODE
        /// </summary>
        public string ORGCODE
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置FOREIGNLANGUAGE
        /// </summary>
        public string FOREIGNLANGUAGE
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
        } = "";

        /// <summary>
        /// 获取或设置JOBSOURCE
        /// </summary>
        public int JOBSOURCE
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置NATIONALITY
        /// </summary>
        public string NATIONALITY
        {
            get;
            set;
        } = "";

        /// <summary>
        /// 获取或设置CREATEDDATE
        /// </summary>
        public DateTime CREATEDDATE
        {
            get;
            set;
        } = DateTime.Now.Date;

        /// <summary>
        /// 获取或设置ROWID
        /// </summary>
        [Key]
        public int ROWID
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置REGISTERADDRESS
        /// </summary>
        public string REGISTERADDRESS
        {
            get;
            set;
        } = "";

        /// <summary>
        /// 获取或设置UPDATEDDATE
        /// </summary>
        public DateTime? UPDATEDDATE
        {
            get;
            set;
        } = DateTime.Now.Date;

        /// <summary>
        /// 获取或设置MAJOR
        /// </summary>
        public string MAJOR
        {
            get;
            set;
        } = "";

        /// <summary>
        /// 获取或设置POSTALCODE
        /// </summary>
        public string POSTALCODE
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置ISRESIDENT
        /// </summary>
        public int ISRESIDENT
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置HRSTATUS
        /// </summary>
        public int? HRSTATUS
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置SEXTYPE
        /// </summary>
        public string SEXTYPE
        {
            get;
            set;
        } = "";

        /// <summary>
        /// 获取或设置TOPTITLE
        /// </summary>
        public string TOPTITLE
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置SOCIALSECURITY
        /// </summary>
        public string SOCIALSECURITY
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置WEIGHT
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal WEIGHT
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
        /// 获取或设置BIRTHDAY
        /// </summary>
        public DateTime BIRTHDAY
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置CERTIFICATION
        /// </summary>
        public string CERTIFICATION
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置BANKTYPE
        /// </summary>
        public string BANKTYPE
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置PHOTO
        /// </summary>
        public string PHOTO
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

        /// <summary>
        /// 获取或设置UPDATEDID
        /// </summary>
        public int? UPDATEDID
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
        /// 获取或设置APPOINTMENTID
        /// </summary>
        public string APPOINTMENTID
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置GRADUATEDATE
        /// </summary>
        public DateTime GRADUATEDATE
        {
            get;
            set;
        } = new DateTime(1970, 1, 1).Date;

        /// <summary>
        /// 获取或设置HRMOBIL
        /// </summary>
        public string HRMOBIL
        {
            get;
            set;
        } = "";

        /// <summary>
        /// 获取或设置BANKTYPENAME
        /// </summary>
        public string BANKTYPENAME
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
        /// 获取或设置NATION
        /// </summary>
        public string NATION
        {
            get;
            set;
        } = "";

        /// <summary>
        /// 获取或设置GAINDATE
        /// </summary>
        public string GAINDATE
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置EMAILADDR
        /// </summary>
        public string EMAILADDR
        {
            get;
            set;
        } = "";

        /// <summary>
        /// 获取或设置POLITICALSTATUS
        /// </summary>
        public string POLITICALSTATUS
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置CPFACCOUNT
        /// </summary>
        public string CPFACCOUNT
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置NATIONALITYNAME
        /// </summary>
        public string NATIONALITYNAME
        {
            get;
            set;
        } = "";

        public string BS_JobId { get; set; }

        public string BS_PersionId { get; set; }
    }
}
