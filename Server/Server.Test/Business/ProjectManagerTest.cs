using System;
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

        [TestInitialize]
        public void Initialize()
        {
            _projectGenerator = new ProjectGenerator();
        }


        [TestCleanup]
        public void Cleanup()
        {
            base.CleanProjects();

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


    }
}
