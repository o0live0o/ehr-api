using System;
using Ehr.Core.Aop.Attriutes;

namespace Ehr.Contracts.Recruit.Dtos
{
    public class RecruitOfferDto
    {

        /// <summary>
        /// 获取或设置需求单位
        /// </summary>
        public string ORGNAME
        {
            get;
            set;
        }



        /// <summary>
        /// 获取或设置应聘人员
        /// </summary>
        [ExField("Name")]
        public string PERSONNAME
        {
            get;
            set;
        }


        /// <summary>
        /// 获取或设置职级
        /// </summary>
        public string POSITIONLEVELCODE
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置证件编码
        /// </summary>
        [ExField("IDNumber")]
        public string IDCARDNO
        {
            get;
            set;
        } = "";

        /// <summary>
        /// 获取或设置岗位
        /// </summary>
        [ExField("JobCode")]
        public string JOBCODE
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置应聘人联系方式
        /// </summary>
        [ExField("Phone")]
        public string PERSONTEL
        {
            get;
            set;
        }


        /// <summary>
        /// 获取或设置职级
        /// </summary>
        public string POSITIONLEVELNAME
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置证件类型
        /// </summary>
        //[ExField("IDType")]
        public int IDTYPE
        {
            get;
            set;
        } = 0;

        /// <summary>
        /// 获取或设置岗位
        /// </summary>
        [ExField("JobName")]
        public string JOBNAME
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置需求单位
        /// </summary>
        [ExField("Org")]
        public string ORGCODE
        {
            get;
            set;
        }

        [ExField("JobID")]
        public string BS_JOBID { get; set; }

        [ExField("PersonID")]
        public string BS_PERSIONID { get; set; }

        /// <summary>
        /// 获取或设置CREATEDID
        /// </summary>
        public int CREATEDID
        {
            get;
            set;
        }

        public string CREATEDNAME
        {
            get;
            set;
        } = "";

        public int UPDATEDID
        {
            get;
            set;
        }

        public string UPDATEDNAME
        {
            get;
            set;
        } = "";

        /// <summary>
        /// 试用期薪酬
        /// </summary>
        /// <value></value>
        [ExField("extSYHJ_602118_1668471719")]
        public string TRIALSALARY
        {
            get;
            set;
        }

        /// <summary>
        /// 转正薪酬
        /// </summary>
        /// <value></value>
        [ExField("extZZHJ_602118_399729479")]
        public string REGULARSALARY
        {
            get;
            set;
        }

        /// <summary>
        /// 到岗时间 
        /// </summary>
        /// <value></value>
        [ExField("extRZRQ_602118_68386292")]
        public string ARRIVALDATE
        {
            get;
            set;
        }
    }
}
