using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;

namespace SaclaApplication.Models
{
    public class Paper
    {
        [Key]
        [BindNever]
        [DisplayName("Id")]
        public int PaperId { get; set; }

        [DisplayName("Title")]
        [Required(ErrorMessage ="The Title field is required.")]
        public string PaperTitle { get; set; }

        [DisplayName("Abstract")]
        [Required(ErrorMessage = "The Abstract field is required.")]
        public string PaperAbstract { get; set; }

        [DisplayName("Author")]
        public string PaperAuthor { get; set; }

        [DisplayName("Submission date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public System.DateTime PaperDateSubmitted { get; set; }

        [DisplayName("Topic")]
        [Required(ErrorMessage = "The value is invalid.")]
        public string TopicId { get; set; }


    }
}