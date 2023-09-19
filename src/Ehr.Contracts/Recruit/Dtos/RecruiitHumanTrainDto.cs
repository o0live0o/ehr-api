using System;
using Ehr.Core.Aop.Attriutes;

namespace Ehr.Contracts.Recruit.Dtos
{
    public class RecruiitHumanTrainDto
    {

        /// <summary>
        /// 获取或设置开始日期
        /// </summary>
        [ExField("TrainStartDate")]
        public DateTime BEGINDATE
        {
            get;
            set;
        } = DateTime.Now.Date;


        /// <summary>
        /// 获取或设置培训内容
        /// </summary>
        [ExField("Description")]
        public string TRAINCONTENT
        {
            get;
            set;
        } = "";

        /// <summary>
        /// 获取或设置获得证书
        /// </summary>
        [ExField("Certificate")]
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
        /// 获取或设置结束日期
        /// </summary>
        [ExField("TrainEndDate")]
        public DateTime ENDDATE
        {
            get;
            set;
        } = DateTime.Now.Date;

        /// <summary>
        /// 获取或设置UPDATEDDATE
        /// </summary>
        public DateTime UPDATEDDATE
        {
            get;
            set;
        } = DateTime.Now;

        /// <summary>
        /// 获取或设置培训机构
        /// </summary>
        [ExField("OrgName")]
        public string TRAINORG
        {
            get;
            set;
        } = "";

        /// <summary>
        /// 获取或设置HRNAME
        /// </summary>
        public string HRNAME
        {
            get;
            set;
        }

    }
}
