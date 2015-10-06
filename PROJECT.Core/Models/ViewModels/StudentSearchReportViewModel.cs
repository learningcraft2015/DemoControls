using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJECT.Core.Models.ViewModels
{
    public class StudentSearchReportViewModel
    {

        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required]
        [DisplayName("Name")]

        public string Name { get; set; }


        [Required]
        [DisplayName("Age")]
        public int Age { get; set; }

        [Required]
        [DisplayName("Date Of Birth")]
        public DateTime DOB { get; set; }
        [Required]
        [DisplayName("Date Of From Date")]
        public DateTime StartDate { get; set; }

        public string strStartDate { get; set; }
        public string strEndDate { get; set; }

        [Required]
        [DisplayName("Date Of To Date")]
        public DateTime EndDate { get; set; }

        public GenderEnum Gender { get; set; }

        public int Result { get; set; }

        public List<StudentSearchReportViewModel> StudentViewModelList { get; set; }

    }




}
