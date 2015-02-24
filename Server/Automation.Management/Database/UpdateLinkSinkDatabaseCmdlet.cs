using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Management.Automation;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using Dk.Schalck.LinkSink.Server.Entity;
using Dk.Schalck.LinkSink.Server.Entity.Context;
using Dk.Schalck.LinkSink.Server.Entity.Migrations;

namespace Dk.Schalck.LinkSink.Automation.Management.Database
{
    [Cmdlet(VerbsData.Update, "LinkSinkDatabase")]
    public class UpdateLinkSinkDatabaseCmdlet : LinkSinkDatabaseCmdlet
    {
        private const string ConfigKey = "linkSinkDbConnection";

        [Parameter]
        public SwitchParameter Force { get; set; }
        protected override void BeginProcessing()
        {
            base.BeginProcessing();
            // NOTE: Connection string for DbInitializer is read from AppConfig due to a limitation in EF code first. 
            if (Force)
            {
                var toLatestVersion =
                    new MigrateDatabaseToLatestVersion
                        <LinkSinkDatabaseContext, LinkSinkDatabaseMigrationConfiguration>(ConfigKey);
                System.Data.Entity.Database.SetInitializer(toLatestVersion);

            }
            else
            {
                var toLatestVersion =
                    new MigrateDatabaseToLatestVersion<LinkSinkDatabaseContext, LinkSinkDatabaseMigrationConfiguration>(ConfigKey);
                System.Data.Entity.Database.SetInitializer(toLatestVersion);
            }
        }
        protected override void ProcessRecord()
        {
            try
            {
                var force = Force.ToBool();
                Context.Database.Initialize(force);
            }
            catch (Exception e)
            {
                WriteError(new ErrorRecord(e, string.Empty, ErrorCategory.InvalidData, null));
            }

        }
    }
}
