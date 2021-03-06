﻿using System;
using System.Collections.Generic;

namespace Athlete.DAL.Model
{
    public partial class AthleteTestMasterModel
    {
        public long Id { get; set; }
        public long TestTypeId { get; set; }
        public DateTime TestDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public long CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public long? UpdatedBy { get; set; }
        public bool IsActive { get; set; }
    }
}
