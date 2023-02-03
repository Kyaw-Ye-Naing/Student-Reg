using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace StudentRegistrationSys.Models.Data
{
    public partial class TblStudentAccount
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string AccountId { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Description { get; set; }
    }
}
