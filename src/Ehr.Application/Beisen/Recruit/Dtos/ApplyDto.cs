namespace Ehr.Application.Beisen.Recruit.Dtos
{

    public class ApplyDto
    {
        public int Code { get; set; }
        public object Message { get; set; }
        public bool IsTrue { get; set; }
        public Datum[] Data { get; set; }
    }

    public class Datum
    {
        public int PersonId { get; set; }
        public Applyinfo[] ApplyInfos { get; set; }
    }

    public class Applyinfo
    {
        public int RelId { get; set; }
        public int PersonId { get; set; }
        public int JobId { get; set; }
        public Phaseinfo PhaseInfo { get; set; }
        public int RecommenderId { get; set; }
        public object Recommender { get; set; }
        public Statusinfo StatusInfo { get; set; }
        public object ElinkUrl { get; set; }
        public string ResumeDownloadUrl { get; set; }
        public object InterviewStation { get; set; }
        public object ProcessReason { get; set; }
        public Mediuminfo MediumInfo { get; set; }
        public Lastmediuminfo LastMediumInfo { get; set; }
        public Belongmediuminfo BelongMediumInfo { get; set; }
        public object ApplyDocuments { get; set; }
        public Filed[] Fileds { get; set; }
    }

    public class Phaseinfo
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }

    public class Statusinfo
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }

    public class Mediuminfo
    {
        public int Id { get; set; }
        public object Code { get; set; }
        public object Name { get; set; }
    }

    public class Lastmediuminfo
    {
        public int Id { get; set; }
        public object Code { get; set; }
        public object Name { get; set; }
    }

    public class Belongmediuminfo
    {
        public int Id { get; set; }
        public object Code { get; set; }
        public object Name { get; set; }
    }

    public class Filed
    {
        public string PropertyName { get; set; }
        public object PropertyShortName { get; set; }
        public object Code { get; set; }
        public string Value { get; set; }
    }
}