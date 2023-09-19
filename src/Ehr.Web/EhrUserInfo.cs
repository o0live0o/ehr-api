using Ehr.Core.Base;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Ehr.Web
{
    public class EhrUserInfo : IEhrUserInfo
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public EhrUserInfo(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string UserId => _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);
    }
}
