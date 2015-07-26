using System.ComponentModel.DataAnnotations;

namespace Dk.Schalck.LinkSink.Web.LinkSinkWeb.Models
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}