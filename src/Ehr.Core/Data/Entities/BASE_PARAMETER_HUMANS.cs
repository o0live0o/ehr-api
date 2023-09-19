using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ehr.Core.Data.Entities
{
    [Table("BASE_PARAMETER_HUMANS")]
    public class BASE_PARAMETER_HUMANS : BaseEntity
    {

        /// <summary>
        /// 获取或设置1--招商人员
        /// </summary>
        public string HRTYPE
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置1--招商人员
        /// </summary>
        public string HRTYPENAME
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置入职日期
        /// </summary>
        public DateTime HIREDATE
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置岗位编码
        /// </summary>
        public string JOBCODE
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置岗位名称
        /// </summary>
        public string JOBNAME
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置是否付加班工资
        /// </summary>
        public int? OVERPAYFLAG
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
        /// 获取或设置HOMEADDRESS
        /// </summary>
        public string HOMEADDRESS
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置PAREANAME
        /// </summary>
        public string PAREANAME
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
        /// 获取或设置PREHRCODE
        /// </summary>
        public string PREHRCODE
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
        /// 获取或设置MAJOR
        /// </summary>
        public string MAJOR
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置IsPayAccumulationFund
        /// </summary>
        public int? IsPayAccumulationFund
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置HRFLAG
        /// </summary>
        public int? HRFLAG
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置SORGCODE
        /// </summary>
        public string SORGCODE
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
        }

        /// <summary>
        /// 获取或设置NATIONALITY
        /// </summary>
        public string NATIONALITY
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
        /// 获取或设置ISCOOPERATION
        /// </summary>
        public int? ISCOOPERATION
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
        /// 获取或设置NATION
        /// </summary>
        public string NATION
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
        /// 获取或设置SCHOOLNAME
        /// </summary>
        public string SCHOOLNAME
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置SCHOOLCODE
        /// </summary>
        public string SCHOOLCODE
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
        /// 获取或设置HRSTATUS
        /// </summary>
        public int HRSTATUS
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置ISRELATION
        /// </summary>
        public int? ISRELATION
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置COOPERATIONNAME
        /// </summary>
        public string COOPERATIONNAME
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
        /// 获取或设置BIRTHDAY
        /// </summary>
        public DateTime? BIRTHDAY
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置MARITALSTATUS
        /// </summary>
        public string MARITALSTATUS
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
        /// 获取或设置DEGREE
        /// </summary>
        public int? DEGREE
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
        /// 获取或设置HOUSEHOLDTYPE
        /// </summary>
        public string HOUSEHOLDTYPE
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置ISGuanPeiSheng
        /// </summary>
        public int? ISGuanPeiSheng
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
        /// 获取或设置FIREDATE
        /// </summary>
        public DateTime? FIREDATE
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置RELATIONTEL
        /// </summary>
        public string RELATIONTEL
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置TRIALENDDATE
        /// </summary>
        public DateTime? TRIALENDDATE
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
        }

        /// <summary>
        /// 获取或设置SAP_PERNR
        /// </summary>
        public string SAP_PERNR
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
        /// 获取或设置EmergencyContact
        /// </summary>
        public string EmergencyContact
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
        /// 获取或设置NATIONALITYNAME
        /// </summary>
        public string NATIONALITYNAME
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置RELATIONREMARK
        /// </summary>
        public string RELATIONREMARK
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置NATIVEPLACE
        /// </summary>
        public string NATIVEPLACE
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置IDTYPE
        /// </summary>
        public int? IDTYPE
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置EMERGENCYLINK
        /// </summary>
        public string EMERGENCYLINK
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置BANKTYPENAME
        /// </summary>
        public string BANKTYPENAME
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置RELATIONAME
        /// </summary>
        public string RELATIONAME
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置SORGNAME
        /// </summary>
        public string SORGNAME
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
        /// 获取或设置PREHRNAME
        /// </summary>
        public string PREHRNAME
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
        /// 获取或设置REGISTERADDRESS
        /// </summary>
        public string REGISTERADDRESS
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
        /// 获取或设置POLITICALSTATUS
        /// </summary>
        public string POLITICALSTATUS
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置ISSchoolAdmissions
        /// </summary>
        public int? ISSchoolAdmissions
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
        /// 获取或设置RELATIONJOB
        /// </summary>
        public string RELATIONJOB
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
        /// 获取或设置ISAUDIT
        /// </summary>
        public int? ISAUDIT
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
        /// 获取或设置PAREACODE
        /// </summary>
        public string PAREACODE
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置VERIFICATIONCODE
        /// </summary>
        public string VERIFICATIONCODE
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置MainHrCode
        /// </summary>
        public string MainHrCode
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置ISNONCOMPETITION
        /// </summary>
        public int? ISNONCOMPETITION
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置ISRESIDENT
        /// </summary>
        public int? ISRESIDENT
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
        /// 获取或设置GRADUATEDATE
        /// </summary>
        public DateTime? GRADUATEDATE
        {
            get;
            set;
        }
    }
}
