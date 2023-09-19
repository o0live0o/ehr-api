namespace Ehr.Application.Beisen.Recruit
{
    public class Applicant
    {
        private string _applicantId { get; set; }

        private int _applicantName { get; set; }

        public Applicant(string applicantId)
        {
            this._applicantId = applicantId;
        }

        public void SyncOffer()
        {

        }

        public void SyncResume()
        {

        }
    }
}