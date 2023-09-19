using Ehr.Core.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Ehr.Infrastructure.SqlServer
{
    public class EhrDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public EhrDbContext(DbContextOptions<EhrDbContext> options, IConfiguration configuration) : base(options)
        {
            this._configuration = configuration;
        }

        public virtual DbSet<BASE_PARAMETER_ENUMVALUE> BaseParameterEnumvalues { get; set; }
        public virtual DbSet<BASE_PARAMETER_HUMANJOBS> BaseParameterHumanJobs { get; set; }
        public virtual DbSet<BASE_PARAMETER_ORGJOBS> BaseParameterOrgJobs { get; set; }
        public virtual DbSet<FLOW_RECRUIT_HUMANS> FlowRecruitHumans { get; set; }
        public virtual DbSet<FLOW_RECRUIT_HUMANS_EDUCATION> FlowRecruitHumansEducation { get; set; }
        public virtual DbSet<FLOW_RECRUIT_HUMANS_TRAIN> FlowRecruitHumansTrain { get; set; }
        public virtual DbSet<FLOW_RECRUIT_HUMANS_JOBS> FlowRecruitHumansJobs { get; set; }
        public virtual DbSet<FLOW_RECRUIT_HUMANS_RELATION> FlowRecruitHumansRelation { get; set; }
        public virtual DbSet<BASE_THIRD_ENUMS> BaseThirdEnums { get; set; }
        public virtual DbSet<FLOW_RECRUIT_HUMANS_REWARD> FlowRecruitHumansReward { get; set; }
        public virtual DbSet<FLOW_RECRUIT_OFFER> FlowRecruitOffer { get; set; }
        public virtual DbSet<BASE_PARAMETER_HUMANS> BaseParameterHumans { get; set; }
        public virtual DbSet<FLOW_JOB_LEAVE_HEAD> FlowJobLeaveHead { get; set; }
        public virtual DbSet<BASE_SYSTEM_USERS> BaseSystemUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BASE_PARAMETER_ORGJOBS>().HasKey(a => new { a.ORGCODE, a.JOBCODE });
            modelBuilder.Entity<FLOW_RECRUIT_HUMANS_EDUCATION>().HasKey(a => new { a.HUMROWID, a.BEGINDATE, a.ENDDATE });
            modelBuilder.Entity<FLOW_RECRUIT_HUMANS_TRAIN>().HasKey(a => new { a.HUMROWID, a.BEGINDATE, a.ENDDATE });
            modelBuilder.Entity<FLOW_RECRUIT_HUMANS_JOBS>().HasKey(a => new { a.HUMROWID, a.BEGINDATE, a.ENDDATE });
            modelBuilder.Entity<FLOW_RECRUIT_HUMANS_RELATION>().HasKey(a => new { a.HUMROWID, a.FULLNAME });
            modelBuilder.Entity<BASE_PARAMETER_HUMANS>().HasKey(a => new { a.HRCODE });
            modelBuilder.Entity<FLOW_JOB_LEAVE_HEAD>().HasKey(a => new { a.APPDATE, a.HRCODE });
        }
    }
}