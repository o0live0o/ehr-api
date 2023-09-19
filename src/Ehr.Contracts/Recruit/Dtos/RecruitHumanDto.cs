using System;
using Ehr.Core.Aop.Attriutes;

namespace Ehr.Contracts.Recruit.Dtos
{
    public class RecruitHumanDto
    {

        /// <summary>
        /// 获取或设置 婚姻状况 1-未婚0-已婚 2-离异3-丧偶
        /// </summary>
        [ExField("WedState", "婚姻状况", @default: 1)]
        public int MARITALSTATUS
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置户口性质1-农业2-非农
        /// </summary>
        [ExField("")]
        public int HOUSEHOLDTYPE
        {
            get;
            set;
        }


        /// <summary>
        /// 获取或设置家庭地址
        /// </summary>
        [ExField("ResidenceState")]
        public string HOMEADDRESS
        {
            get;
            set;
        } = "";

        /// <summary>
        /// 获取或设置籍贯
        /// </summary>
        [ExField("NativePlace")]
        public string NATIVEPLACE
        {
            get;
            set;
        } = "";

        /// <summary>
        /// 获取或设置学校
        /// </summary>
        [ExField("R_LastSchool")]
        public string SCHOOLNAME
        {
            get;
            set;
        } = "";



        /// <summary>
        /// 获取或设置紧急联系
        /// </summary>
        [ExField("EmergencyPhone")]
        public string EMERGENCYLINK
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置IDTYPE
        /// </summary>
        [ExField("CertificateType", "证件类型")]
        public int IDTYPE
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置身高
        /// </summary>
        [ExField("R_Height")]
        public decimal HEIGHT
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置证件证号
        /// </summary>
        [ExField("CertificateNumber")]
        public string IDCARDNO
        {
            get;
            set;
        } = "";

        /// <summary>
        /// 获取或设置应聘网站
        /// </summary>
        [ExField("R_AllSources")]
        public int JOBSOURCE
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置NATIONALITY
        /// </summary>
        [ExField("Nationality")]
        public string NATIONALITY
        {
            get;
            set;
        } = "";


        /// <summary>
        /// 获取或设置户口所在地
        /// </summary>
        [ExField("RPR")]
        public string REGISTERADDRESS
        {
            get;
            set;
        } = "";

        /// <summary>
        /// 获取或设置专业
        /// </summary>
        [ExField("R_LastDiscipline")]
        public string MAJOR
        {
            get;
            set;
        } = "";


        /// <summary>
        /// 获取或设置是否居民
        /// </summary>
        [ExField("")]
        public int ISRESIDENT
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置人员状态
        /// </summary>
        [ExField("")]
        public int HRSTATUS
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置性别
        /// </summary>
        [ExField("gender")]
        public string SEXTYPE
        {
            get;
            set;
        } = "";


        // /// <summary>
        // /// 获取或设置体重
        // /// </summary>
        // [ExField("Weight")]
        // public decimal WEIGHT
        // {
        //     get;
        //     set;
        // }

        /// <summary>
        /// 获取或设置出生年月
        /// </summary>
        [ExField("Birthday")]
        public DateTime BIRTHDAY
        {
            get;
            set;
        } = new DateTime(1970, 1, 1).Date;


        /// <summary>
        /// 获取或设置最高学历
        /// </summary>
        [ExField("EducationLevel", "学历")]
        public int DEGREE
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置人员名称
        /// </summary>
        [ExField("Name")]
        public string HRNAME
        {
            get;
            set;
        }

        [ExField("GraduationDate")]
        public DateTime GRADUATEDATE
        {
            get;
            set;
        } = new DateTime(1970, 1, 1);


        /// <summary>
        /// 获取或设置联系电话
        /// </summary>
        [ExField("Mobile")]
        public string HRMOBIL
        {
            get;
            set;
        } = "";



        /// <summary>
        /// 获取或设置民族
        /// </summary>
        [ExField("Nation")]
        public string NATION
        {
            get;
            set;
        } = "";


        /// <summary>
        /// 获取或设置邮箱地址
        /// </summary>
        [ExField("email")]
        public string EMAILADDR
        {
            get;
            set;
        } = "";

        // /// <summary>
        // /// 获取或设置政治面貌
        // /// </summary>
        // [ExField("polity", "政治面貌")]
        // public string POLITICALSTATUS
        // {
        //     get;
        //     set;
        // }


        public string BS_JobId { get; set; }

        [ExField("personId")]
        public string BS_PersionId { get; set; }

    }
}
