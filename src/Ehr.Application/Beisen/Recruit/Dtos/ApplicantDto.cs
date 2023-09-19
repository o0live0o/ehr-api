using System.Collections.Generic;

namespace Ehr.Application.Beisen.Recruit.Dtos
{
    public class ApplicantDto
    {
        /// <summary>
        /// 个人信息  List<StringValueContainer>
        /// </summary>
        /// <value></value>
        public List<PropertyDto> ApplicantProfile { get; set; }
        /// <summary>
        /// 附加信息
        /// </summary>
        /// <value></value>
        public List<List<PropertyDto>> ResumeForAdditionalInfoList { get; set; }
        /// <summary>
        /// 通讯住址
        /// </summary>
        /// <value></value>
        public List<List<PropertyDto>> ResumeForAddressInfoList { get; set; }
        /// <summary>
        /// 附件
        /// </summary>
        /// <value></value>
        public List<List<PropertyDto>> ResumeForAttachmentsList { get; set; }
        /// <summary>
        /// 获奖经历
        /// </summary>
        /// <value></value>
        public List<List<PropertyDto>> ResumeForAwardsWonList { get; set; }
        /// <summary>
        /// 证书（原技能/职业证书）
        /// </summary>
        /// <value></value>
        public List<List<PropertyDto>> ResumeForCertificateList { get; set; }
        /// <summary>
        /// 教育背景
        /// </summary>
        /// <value></value>
        public List<List<PropertyDto>> ResumeForEducationList { get; set; }
        /// <summary>
        /// 工作经历
        /// </summary>
        /// <value></value>
        public List<List<PropertyDto>> ResumeForExperienceList { get; set; }
        /// <summary>
        /// 家庭成员
        /// </summary>
        /// <value></value>
        public List<List<PropertyDto>> ResumeForFamilyList { get; set; }
        /// <summary>
        /// 实习经验
        /// </summary>
        /// <value></value>
        public List<List<PropertyDto>> ResumeForInternshipList { get; set; }
        /// <summary>
        /// 语言
        /// </summary>
        /// <value></value>
        public List<List<PropertyDto>> ResumeForLangList { get; set; }
        /// <summary>
        /// 求职意向
        /// </summary>
        /// <value></value>
        public List<List<PropertyDto>> ResumeForObjectiveList { get; set; }
        /// <summary>
        /// 工资卡信息
        /// </summary>
        /// <value></value>
        public List<List<PropertyDto>> ResumeForPayCardInfoList { get; set; }
        /// <summary>
        /// 项目经理
        /// </summary>
        /// <value></value>
        public List<List<PropertyDto>> ResumeForProjectList { get; set; }
        /// <summary>
        /// 论文专著
        /// </summary>
        /// <value></value>
        public List<List<PropertyDto>> ResumeForPublishedList { get; set; }
        /// <summary>
        /// 附加问题
        /// </summary>
        /// <value></value>
        public List<List<PropertyDto>> ResumeForQuestionList { get; set; }
        /// <summary>
        /// 在校职务
        /// </summary>
        /// <value></value>
        public List<List<PropertyDto>> ResumeForSchoolOfficeList { get; set; }
        /// <summary>
        /// 在校实践
        /// </summary>
        /// <value></value>
        public List<List<PropertyDto>> ResumeForSchoolPracticeList { get; set; }
        /// <summary>
        /// 技能
        /// </summary>
        /// <value></value>
        public List<List<PropertyDto>> ResumeForSkillList { get; set; }
        /// <summary>
        /// 团队管理
        /// </summary>
        /// <value></value>
        public List<List<PropertyDto>> ResumeForTeamManagerList { get; set; }
        /// <summary>
        /// 培训经验
        /// </summary>
        /// <value></value>
        public List<List<PropertyDto>> ResumeForTrainList { get; set; }
        /// <summary>
        /// 亲属声明
        /// </summary>
        /// <value></value>
        public List<List<PropertyDto>> ResumeForRelativesDeclarationList { get; set; }
        public string ElinkUrl { get; set; }
    }
}