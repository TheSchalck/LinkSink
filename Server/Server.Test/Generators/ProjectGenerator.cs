using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dk.Schalck.LinkSink.Server.Business;
using Dk.Schalck.LinkSink.Server.Entity;

namespace Server.Test.Generators
{
    public class ProjectGenerator
    {
        public ProjectManager GetProjectManagerInstance()
        {
            var ctx = new LinkSinkDatabaseContext();
            var pm = new ProjectManager(ctx);
            return pm;
        }

        public Project AddProject(string name, string displayname, string description, DateTime createDate, string createdBy)
        {
            var p = GetProjectManagerInstance();
            var result =  p.AddProject(name, displayname, description, createDate, createdBy);
            return result;
        }
    }
}
