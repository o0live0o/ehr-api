namespace Ehr.Contracts.Base
{
    public class TokenDto
    {
        public string AccessToken { get; set; }

        public string TokenType { get; set; } = "bearer";

        // public string RefreshToken { get; set; }

        /// <summary>
        /// 过期时间
        /// </summary>
        /// <value></value>
        public long Expire { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        /// <value></value>
        public long IssuedAt { get; set; }
    }
}