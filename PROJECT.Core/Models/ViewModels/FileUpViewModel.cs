using PROJECT.Core.Model.ViewModel;
using PROJECT.Core.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PROJECT.Core.Model.ViewModel
{
    public class FileUpViewModel : BaseViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Upload File")]
        [DataAnnotationsExtensions.FileExtensions("pdf|doc|txt")]
        [Display(Name = "PDf OR TXT Note")]
        // [ValidateFile]        
        public HttpPostedFileBase UpFile { get; set; }

        [ScaffoldColumn(false)]
        public string FileName { get; set; }// file upload
    }
}
