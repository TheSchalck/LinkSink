using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Management.Automation;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using Dk.Schalck.LinkSink.Server.Entity;

namespace Dk.Schalck.LinkSink.Automation.Management.Database
{
    [Cmdlet(VerbsCommon.Remove, "LinkSinkDatabase", ConfirmImpact = ConfirmImpact.High)]
    public class RemoveLinkSinkDatabaseCmdlet : LinkSinkDatabaseCmdlet
    {
        [Parameter]
        public SwitchParameter Force { get; set; }
        protected override void ProcessRecord()
        {
            SqlConnection.ClearAllPools();
            if (!Context.Database.Exists()) WriteError(new ErrorRecord(new PSInvalidOperationException("Database does not exist"), "ERR", ErrorCategory.InvalidOperation, null));

            if (Force || ShouldContinue(string.Format("Confirm removal and DELETION of database \"{0}\" from server \"{1}\"", DatabaseName, Server), "Confirm removal of database."))
            {
                Context.Database.Delete();
            }
        }

    }
}
