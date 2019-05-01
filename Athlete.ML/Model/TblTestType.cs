﻿using System;
using System.Collections.Generic;

namespace Athlete.ML.Model
{
    public partial class TblTestType
    {
        public long Id { get; set; }
        public string TestType { get; set; }
        public string TestAttribute { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public long CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public long? UpdatedBy { get; set; }
    }
}
