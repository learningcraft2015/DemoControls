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
   public class DBDropViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required]
        [DisplayName("Name")]

        public string Name { get; set; }
        [ScaffoldColumn(false)]
        public SelectList StudentsList { get; set; }


    }
}
