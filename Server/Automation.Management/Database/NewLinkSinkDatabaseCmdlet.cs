using System.Data.Entity;
using System.Management.Automation;
using Dk.Schalck.LinkSink.Server.Entity.Context;
using Dk.Schalck.LinkSink.Server.Entity.Migrations;

namespace Dk.Schalck.LinkSink.Automation.Management.Database
{
    [Cmdlet(VerbsCommon.New, "LinkSinkDatabase")]
    public class NewLinkSinkDatabaseCmdlet : LinkSinkDatabaseCmdlet
    {
        protected override void BeginProcessing()
        {
            base.BeginProcessing();
            // NOTE: Connection string for DbInitializer is read from AppConfig due to a limitation in EF code first. 
            System.Data.Entity.Database.SetInitializer(new MigrateDatabaseToLatestVersion<LinkSinkDatabaseContext, LinkSinkDatabaseMigrationConfiguration>("linkSinkDbConnection"));
        }

        protected override void ProcessRecord()
        {
            if (Context.Database.Exists()) throw new PSInvalidOperationException("Database already exists");
            Context.Database.Initialize(false);
        }
    }
}
