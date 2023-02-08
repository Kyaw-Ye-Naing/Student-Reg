using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace StudentRegistrationSys.Models.Data
{
    public partial class TblStudentInfo
    {
        public int Id { get; set; }
        public int? YearLevelId { get; set; }
        public int? SerialNo { get; set; }
        public int? AcademicYearId { get; set; }
        public string NameMyan { get; set; }
        public string Religion { get; set; }
        public string Nationality { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Nrc { get; set; }
        public string City { get; set; }
        public string Township { get; set; }
        public string Address { get; set; }
        public string FatherName { get; set; }
        public string FatherNrc { get; set; }
        public string FatherNativeTown { get; set; }
        public string FatherReligion { get; set; }
        public string FatherNationallity { get; set; }
        public DateTime? FatherDateOfBirth { get; set; }
        public string FatherAddress { get; set; }
        public string FatherPhoneNo { get; set; }
        public string MotherName { get; set; }
        public string MotherNrc { get; set; }
        public string MotherNativeTown { get; set; }
        public string MotherReligion { get; set; }
        public string MotherNationallity { get; set; }
        public DateTime? MotherDateOfBirth { get; set; }
        public string MotherAddress { get; set; }
        public string MotherPhoneNo { get; set; }
        public string MarticulatonRollNo { get; set; }
        public string MarticulationYear { get; set; }
        public string ProvideName { get; set; }
        public string ProvideAddress { get; set; }
        public string Relationship { get; set; }
        public string ProvidePhoneNo { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool Active { get; set; }
        public string Description { get; set; }
        public int? SectionId { get; set; }
        public string DegreeProgram { get; set; }
        public int? AccountId { get; set; }
        public int? SemesterId { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public bool IsRegister { get; set; }
        public bool IsCourseSelect { get; set; }
        public bool? IsSecondSelect { get; set; }
    }
}
