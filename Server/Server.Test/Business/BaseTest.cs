using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dk.Schalck.LinkSink.Server.Entity;
using Dk.Schalck.LinkSink.Server.Entity.Context;

namespace Server.Test.Business
{
    public abstract class BaseTest
    {
        private IDatabaseContextFactory _factory;

        public IDatabaseContextFactory ContextFactory
        {
            get
            {
                if (_factory == null)
                    _factory = new DatabaseContextFactory();
                return _factory;
            }
        }

        protected void CleanProjects()
        {
            var ctx = ContextFactory.GetContext();
            var list = ctx.Projects;
            foreach (var project in list)
            {
                list.Remove(project);
            }
            ctx.SaveChanges();
        }

        protected void CleanUsers()
        {
            var ctx = ContextFactory.GetContext();
            var list = ctx.Users;
            foreach (var user in list)
            {
                list.Remove(user);
            }
            ctx.SaveChanges();
        }

        protected void CleanProjectMembers()
        {
            var ctx = ContextFactory.GetContext();
            var list = ctx.ProjectMembers;
            foreach (var user in list)
            {
                list.Remove(user);
            }
            ctx.SaveChanges();
        }

        protected void CleanDatabase()
        {
            // Call the clean method in correct order

            CleanProjectMembers();
            CleanProjects();
            CleanUsers();
            ;
        }
    }
}
