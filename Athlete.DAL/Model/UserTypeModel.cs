using System;
using System.Collections.Generic;

namespace Athlete.DAL.Model
{
    public partial class UserTypeModel
    {
        public long Id { get; set; }
        public string UserType { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public long CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public long? UpdatedBy { get; set; }
    }
}
