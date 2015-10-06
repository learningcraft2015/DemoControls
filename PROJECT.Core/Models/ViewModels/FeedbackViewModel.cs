using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJECT.Core.Model.ViewModel
{
    public class FeedbackViewModel
    {
        [DataAnnotationsExtensions.Email]
        [DisplayName("To Email Address")]
        public string strToEmail { get; set; }

        [DisplayName("UserName Address")]
        public string strUserName { get; set; }

        [DisplayName("Subject")]
        public string Subject { get; set; }
        [DisplayName("Body")]
        [DataType(DataType.MultilineText)]
        public string Body { get; set; }

    }
}
