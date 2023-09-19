using System;
using Microsoft.Extensions.Logging;

namespace Ehr.Core.Base
{
    public static class EhrTips
    {
        public const string SYSTEM_ERROR = "服务器繁忙,请稍后再试";
        public const string REJECT_ERROR = "回滚信息失败!";
        public const string SAVE_RESUME_ERROR = "保存人员简历失败";
        public const string REQ_PARAM_ERROR = "请求参数异常";
        public const string OFFER_EXCEPTION = "获取offer审批人信息异常!";
        public const string SYNC_OFFER_SUCC = "同步offer信息成功";
        public const string SYNC_RESUME_SUCC = "同步简历信息成功";
        public const string ILLEGAL_LOGIN_TYPE = "非法的登录类型!";
        public const string HUMAN_NOT_EXISTS = "用户不存在!";


        #region template
        public const string EMPTY_OFFER = "人员 [{0}] 没有offer信息!";
        public const string NOT_IN_BLACKLIST = "人员 [{0}] 没有入职记录!";
        public const string IN_BLACKLIST = "人员 [{0}] 有入职记录!";
        public const string LEAVE_REASON = "人员 [{0}] 离职原因: {1}!";
        public const string SYNC_ERROR = "同步信息异常:{0}";

        #endregion

    }
}