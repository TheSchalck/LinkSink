using Dk.Schalck.LinkSink.Automation.Management.Database;
using Dk.Schalck.LinkSink.Server.Entity.Context;

namespace Dk.Schalck.LinkSink.Automation.Management.DataSeed
{
    public class BaseContextCmdlet : BaseDatabaseCmdlet
    {
        public BaseContextCmdlet(string connectionStringName) : base(connectionStringName)
        {
        }

        public LinkSinkDatabaseContext Context { get { return (LinkSinkDatabaseContext)_context; } }

        public BaseContextCmdlet()
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
