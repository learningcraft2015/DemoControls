using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJECT.Core.Models.ViewModels
{
    public class EnumDropViewModel
    {
        [DisplayName("Gender")]
        public GenderEnum Gender { get; set; }
    }

}
