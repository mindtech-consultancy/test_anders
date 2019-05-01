using Athlete.DAL.Model;
using System;

namespace Athlete.DAL.ViewModel
{
    public class TestAttendeeViewModel : UserMasterModel
    {
        public long AthleteTestId { get; set; }
        public long UserId { get; set; }
        public string TestAttributeValue { get; set; }
        public string FitenessRating { get; set; }
    }
}
