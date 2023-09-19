using System;
using System.IO;
using Ehr.Application.Beisen.Recruit.Dtos;
using Ehr.Core.ExtendMethods;
using Newtonsoft.Json;
using Xunit;

namespace Ehr.Test
{
    public class FieldTest
    {
        [Fact]
        public void TestDictinoary()
        {
            var s = File.ReadAllText("D://test01.txt");
            ApplicantDto app = JsonConvert.DeserializeObject<ApplicantDto>(s);

        }

        [Fact]
        public void RegexTest()
        {
            var s = "测试-车磊(chelei@yurun.com)";
            var ret = s.Match(@"\((.*)\)", 1);
            Assert.Equal("chelei@yurun.com", ret);
        }

        private void ForeachApplicant(ApplicantDto app)
        {

        }

    }
}