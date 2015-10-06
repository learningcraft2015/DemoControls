using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;


namespace PROJECT.Core.Models.ViewModels
{
    public class StudentViewModel
    {

          [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required]
        [DisplayName("Name")]
       
        public string Name { get; set; }

      
        [Required]
        [DisplayName("Age")]
        public int Age { get; set; }


        public int Result { get; set; }
    }
}
