using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dk.Schalck.LinkSink.Automation.Management.Database;
using Dk.Schalck.LinkSink.Server.Entity;

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
