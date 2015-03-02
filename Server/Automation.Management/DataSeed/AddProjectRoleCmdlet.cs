using System;
using System.Data.Entity.Validation;
using System.Linq;
using System.Management.Automation;
using System.Runtime.Remoting.Contexts;
using Dk.Schalck.LinkSink.Automation.Management.Extension;
using Dk.Schalck.LinkSink.Server.Common;
using Dk.Schalck.LinkSink.Server.Entity;

namespace Dk.Schalck.LinkSink.Automation.Management.DataSeed
{
    [Cmdlet(VerbsCommon.Add, "ProjectRole")]
    public class AddProjectRoleCmdlet : BaseContextCmdlet
    {

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public int Id { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public string DisplayName { get; set; }

        protected override void ProcessRecord()
        {
            try
            {
                var exists = Context.ProjectRoles.SingleOrDefault(projectRole => projectRole.Id == Id);
                if (exists != null)
                    return;

                var role = new ProjectRole
                {
                    Id = Id,
                    DisplayName = DisplayName,
                    Name = Name,
                    PostStatus = Enumerations.RecordStatus.Active,
                    CreatedBy = "PowerShell script",
                    CreateDate = DateTime.UtcNow

                };
                Context.Add(role);
                Context.SaveChanges();
                WriteObject(role);
            }
            catch (DbEntityValidationException ex)
            {
                WriteError(new ErrorRecord(new InvalidOperationException(ex.EntityValidationErrorMessage(), ex), "Add-ProjectRole", ErrorCategory.InvalidOperation, MyInvocation.BoundParameters));
            }
            catch (Exception ex)
            {
                WriteError(new ErrorRecord(ex.GetBaseException(), "Add-ProjectRole", ErrorCategory.InvalidOperation, MyInvocation.BoundParameters));
            }
        }
    }
}
