using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PROJECT.Core.Model.ViewModel
{
    public class OptGroupViewModel
    {
        [ScaffoldColumn(false)]
        public int CountryId { get; set; }

        [Required]
        [DisplayName("Name")]

        public string CountryName { get; set; }

        [ScaffoldColumn(false)]
        public int StateId { get; set; }

        [Required]
        [DisplayName("State Name")]

        public string StateName { get; set; }
        [ScaffoldColumn(false)]
        public SelectList SelectCountryList { get; set; }
        [ScaffoldColumn(false)]
        public List<OptGroupViewModel> StateList { get; set; }
    }
}
