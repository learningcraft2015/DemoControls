using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PROJECT.Core.Models.ViewModels
{

    public class RegistrationViewModel : BaseViewModel
    {
        public RegistrationViewModel()
        {


        }

        [ScaffoldColumn(false)]
        public int RegistrationId { get; set; }

        [ScaffoldColumn(false)]
        public int UserId { get; set; }

        [ScaffoldColumn(false)]
        public int UserTypeId { get; set; }

        [Required(ErrorMessage = "Enter Your Name")]
        [RegularExpression(@"[a-zA-Z ]*$", ErrorMessage = "Use alphabets only please")]
        [StringLength(50)]
        [DisplayName("Name")]
        public string Name { get; set; }

        public string Address { get; set; }
        public int CountryId { get; set; }
        public string State { get; set; }
        [Required(ErrorMessage = "Enter your date of birth")]
        [DisplayName("Date of Birth")]

        //   [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }


        [Range(1, int.MaxValue, ErrorMessage = "Select gender")]
        [DisplayName("Gender")]
        public GenderEnum Gender { get; set; }

        [Required(ErrorMessage = "Enter City")]
        [DisplayName("City")]
        [StringLength(50)]
        public string City { get; set; }

        [Required(ErrorMessage = "Enter Mobile Number")]
        [DataAnnotationsExtensions.Numeric]
        [DisplayName("Mobile Number")]
        [StringLength(50)]
        public string MobileNumber { get; set; }

        [Required(ErrorMessage = "Enter E-mail address")]

        [DataAnnotationsExtensions.Email]
        [DisplayName("E-mail")]
        [StringLength(50)]
        public string UserEmail { get; set; }

        [Required(ErrorMessage = "Enter a password for your accout")]
        [DisplayName("Password")]
        [MinLength(3)]
        [StringLength(50)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [ScaffoldColumn(false)]
        public int Status { get; set; }



    }
    //public enum GenderEnum
    //{
    //    Male = 1,
    //    Female = 2
    //}
}









