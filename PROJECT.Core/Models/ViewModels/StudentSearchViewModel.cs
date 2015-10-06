using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJECT.Core.Models.ViewModels
{
    public class StudentSearchViewModel
    {

        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required]
        [DisplayName("Name")]

        public string Name { get; set; }


        public string Keyword { get; set; }


        [Required]
        [DisplayName("Age")]
        public int Age { get; set; }

        [Required]
        [DisplayName("Date Of Birth")]
        public DateTime DOB { get; set; }

        public GenderEnum Gender { get; set; }

        public int Result { get; set; }

        public List<StudentSearchViewModel> StudentViewModelList { get; set; }

    }




}
