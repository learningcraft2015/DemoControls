using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PROJECT.Core.Model.ViewModel
{
    public class DatePickerViewModel
    {
        [DisplayName("Date Of Birth")]
        public DateTime DOB { get; set; }

        [DisplayName("Time Of Birth")]
        public DateTime TOB { get; set; }

    }
}
