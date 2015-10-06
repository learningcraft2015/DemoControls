using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PROJECT.Core.Models.ViewModels
{
    public class GalleryViewModel : BaseViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Upload File")]
        [DataAnnotationsExtensions.FileExtensions("jpg|gif")]
        [Display(Name = "Jpg OR GIF Image")]
        // [ValidateFile]        
        public HttpPostedFileBase UpFile { get; set; }

        [ScaffoldColumn(false)]
        public string FileName { get; set; }// file upload
        [ScaffoldColumn(false)]
        [DisplayName("Title")]
        [Required]
        public string Title { get; set; }// file upload
        public string DeleteFileName { get; set; }

    }
}
