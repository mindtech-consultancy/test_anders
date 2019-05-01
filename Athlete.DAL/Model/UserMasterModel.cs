using System;
using System.Collections.Generic;

namespace Athlete.DAL.Model
{
    public partial class UserMasterModel
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public long UserTypeId { get; set; }
        public DateTime CreatedDate { get; set; }
        public long CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public long? UpdatedBy { get; set; }
        public bool IsActive { get; set; }
    }
}
