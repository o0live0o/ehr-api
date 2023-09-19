namespace Ehr.Application.DingDing.Dtos
{
    public class DingDingToken
    {
        public string errcode { get; set; }
        public string access_token { get; set; }
        public string errmsg { get; set; }
        public string expires_in { get; set; }
    }
}