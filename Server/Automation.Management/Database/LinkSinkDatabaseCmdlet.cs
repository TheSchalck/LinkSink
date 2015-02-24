using Dk.Schalck.LinkSink.Server.Entity.Context;

namespace Dk.Schalck.LinkSink.Automation.Management.Database
{
    public class LinkSinkDatabaseCmdlet : BaseDatabaseCmdlet
    {
        public LinkSinkDatabaseContext Context { get { return (LinkSinkDatabaseContext)_context; } }

        public LinkSinkDatabaseCmdlet()
            : base("linkSinkDbConnection")
        {
            Server = ".";
            DatabaseName = "LinkSinkDb";
        }

        protected override void BeginProcessing()
        {
            base.BeginProcessing();
            _context = new LinkSinkDatabaseContext(GetDatabaseConnectionString());
        }
    }
}
