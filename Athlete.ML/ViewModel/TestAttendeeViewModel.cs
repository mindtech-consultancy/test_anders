using Athlete.ML.Model;
using System;

namespace Athlete.ML.ViewModel
{
    public class TestAttendeeViewModel : TblUserMaster
    {
        public long Id { get; set; }
        public long AthleteTestId { get; set; }
        public long UserId { get; set; }
        public string TestAttributeValue { get; set; }
        public string FitenessRating { get; set; }
    }
}
