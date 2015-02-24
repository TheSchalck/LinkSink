using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dk.Schalck.LinkSink.Server.Entity;

namespace Server.Test.Business
{
    public class BaseTest
    {
        protected void CleanProjects()
        {
            var ctx = new LinkSinkDatabaseContext();
            var list = ctx.Projects;
            foreach (var project in list)
            {
                list.Remove(project);
            }
            ctx.SaveChanges();
        }

        protected void CleanDatabase()
        {
            // Call the clean method in correct order

            CleanProjects();
        }
    }
}
