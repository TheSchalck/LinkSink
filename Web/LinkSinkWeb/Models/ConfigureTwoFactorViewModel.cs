using System.Collections.Generic;

namespace Dk.Schalck.LinkSink.Web.LinkSinkWeb.Models
{
    public class ConfigureTwoFactorViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
    }
}