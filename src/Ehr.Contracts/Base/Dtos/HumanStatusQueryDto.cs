namespace Ehr.Contracts.Base.Dtos
{
    public class HumanStatusQueryDto
    {
        /// <summary>
        /// 值
        /// </summary>
        /// <value></value>
        public string Val { get; set; }

        /// <summary>
        /// 登录方式
        /// </summary>
        /// <value>1-HrCode 2-Phone 3-EMail</value>
        public string LoginType { get; set; }
    }
}