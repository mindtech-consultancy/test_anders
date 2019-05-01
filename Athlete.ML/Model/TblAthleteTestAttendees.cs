using System;
using System.Collections.Generic;

namespace Athlete.ML.Model
{
    public partial class TblAthleteTestAttendees
    {
        public long Id { get; set; }
        public long AthleteTestId { get; set; }
        public long UserId { get; set; }
        public string TestAttributeValue { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public long CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public long? UpdatedBy { get; set; }
    }
}
