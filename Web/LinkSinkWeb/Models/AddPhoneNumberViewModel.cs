using System.ComponentModel.DataAnnotations;

namespace Dk.Schalck.LinkSink.Web.LinkSinkWeb.Models
{
    public class AddPhoneNumberViewModel
    {
        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string Number { get; set; }
    }
}