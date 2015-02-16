using System.Data.Entity.Validation;
using System.Linq;

namespace Dk.Schalck.LinkSink.Automation.Management.Extension
{
    public static class EntityExceptionExtensions
    {
        public static string EntityValidationErrorMessage(this DbEntityValidationException ex)
        {
            var s = ex.EntityValidationErrors.SelectMany(x => x.ValidationErrors.Select(y => y.ErrorMessage)).Aggregate((a, b) => a + "; " + b);
            return s;
        }

    }
}
