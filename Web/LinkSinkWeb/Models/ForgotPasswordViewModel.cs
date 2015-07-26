using System.ComponentModel.DataAnnotations;

namespace Dk.Schalck.LinkSink.Web.LinkSinkWeb.Models
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}