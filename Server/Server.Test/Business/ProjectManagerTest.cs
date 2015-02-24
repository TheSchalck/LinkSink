using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Dk.Schalck.LinkSink.Server.Business;
using Dk.Schalck.LinkSink.Server.Entity;
using Dk.Schalck.LinkSink.Server.Entity.Context;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Server.Test.Generators;

namespace Server.Test.Business
{
    [TestClass]
    public class ProjectManagerTest : BaseTest
    {
        private ProjectGenerator _projectGenerator;
        private UserGenerator _userGenerator;

        [TestInitialize]
        public void Initialize()
        {
            _projectGenerator = new ProjectGenerator();
            _userGenerator = new UserGenerator();
        }


        [TestCleanup]
        public void Cleanup()
        {
            base.CleanDatabase();

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddProjectNoName()
        {
            var pm = _projectGenerator.GetProjectManagerInstance();
            pm.AddProject("", "displayname", "description", DateTime.Now, "sts");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddProjectNoDisplayName()
        {
            var pm = _projectGenerator.GetProjectManagerInstance();
            pm.AddProject("name", "", "description", DateTime.Now, "sts");
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddProjectNoCreatedBy()
        {
            var pm = _projectGenerator.GetProjectManagerInstance();
            pm.AddProject("name", "Description", "description", DateTime.Now, "");
        }

        [TestMethod]
        public void AddProject()
        {
            var pm = _projectGenerator.GetProjectManagerInstance();
            var project = pm.AddProject(Guid.NewGuid().ToString(), "Description", "description", DateTime.Now, "sts");

            var ctx = ContextFactory.GetContext();
            var p = ctx.Projects.SingleOrDefault(x => x.Id == project.Id);
            Assert.IsNotNull(p);
            Assert.IsTrue(p.Name == project.Name);

        }


        [TestMethod]
        public void GetProject()
        {
            var project = _projectGenerator.AddProject(Guid.NewGuid().ToString(), "Description", "description", DateTime.Now, "sts");

            var pm = _projectGenerator.GetProjectManagerInstance();
            var p = pm.GetProject(project.Id);

            Assert.IsNotNull(p);
            Assert.IsTrue(p.Name == project.Name);
        }

        [TestMethod]
        public void GetProjectDoesNotExist()
        {
            var pm = _projectGenerator.GetProjectManagerInstance();
            var p = pm.GetProject(Guid.NewGuid());
            Assert.IsNull(p);
        }

        [TestMethod]
        public void AddProjectMember()
        {
            var user = _userGenerator.AddUser();
            var project = _projectGenerator.AddProject();

            var pm = _projectGenerator.GetProjectManagerInstance();
            var result = pm.AddProjectMember(project, user, DateTime.Now, "sts");
            Assert.IsNotNull(result);

            var ctx = ContextFactory.GetContext();
            var fetched = ctx.ProjectMembers.Include(x=>x.User).Include(x=>x.Project).SingleOrDefault(x => x.Id == result.Id);
            Assert.IsTrue(fetched.UserId == user.Id);
            Assert.IsTrue(fetched.User.Id == user.Id);
            Assert.IsTrue(fetched.ProjectId == project.Id);
            Assert.IsTrue(fetched.Project.Id == project.Id);
        }

        [TestMethod]
        public void AddProjectMembers()
        {
            var user1 = _userGenerator.AddUser();
            var user2 = _userGenerator.AddUser();
            var project = _projectGenerator.AddProject();

            var list = new List<User> {user1, user2};

            var pm = _projectGenerator.GetProjectManagerInstance();
            var result = pm.AddProjectMembers(project, list, DateTime.Now, "sts");
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count == 2);

            var ctx = ContextFactory.GetContext();
            var fetched = ctx.ProjectMembers.Include(x => x.User).Include(x => x.Project).Where(x => x.ProjectId == project.Id).ToList();
            Assert.IsTrue(fetched.Count == 2);
            Assert.IsTrue(fetched.Any(x=>x.UserId == user1.Id));
            Assert.IsTrue(fetched.Any(x=>x.UserId == user2.Id));
        }


        [TestMethod]
        public void RemoveProjectMember()
        {
            var user = _userGenerator.AddUser();
            var project = _projectGenerator.AddProject();
            var projectMember = _projectGenerator.AddProjectMember(project, user);

            var ctx = ContextFactory.GetContext();
            var fetched = ctx.ProjectMembers.Include(x => x.User).Include(x => x.Project).Where(x => x.ProjectId == project.Id).ToList();
            Assert.IsTrue(fetched.Count == 1);
            Assert.IsTrue(fetched.Any(x => x.UserId == user.Id));
            Assert.IsTrue(fetched.Any(x => x.Id== projectMember.Id));

            var pm = _projectGenerator.GetProjectManagerInstance();
            pm.RemoveProjectMember(project, user);

            var ctx2 = ContextFactory.GetContext();
            var fetched2 = ctx2.ProjectMembers.Include(x => x.User).Include(x => x.Project).Where(x => x.ProjectId == project.Id).ToList();
            Assert.IsTrue(fetched2.Count == 0);
        }

    }
}
