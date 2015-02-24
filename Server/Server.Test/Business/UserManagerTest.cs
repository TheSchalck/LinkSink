using System;
using System.Linq;
using Dk.Schalck.LinkSink.Server.Business;
using Dk.Schalck.LinkSink.Server.Common.Exception;
using Dk.Schalck.LinkSink.Server.Entity;
using Dk.Schalck.LinkSink.Server.Entity.Context;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Server.Test.Generators;

namespace Server.Test.Business
{
    [TestClass]
    public class UserManagerTest : BaseTest
    {
        private UserGenerator _userGenerator;

        [TestInitialize]
        public void Initialize()
        {
            _userGenerator = new UserGenerator();
        }


        [TestCleanup]
        public void Cleanup()
        {
            base.CleanUsers();

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddUserNoUserName()
        {
            var pm = _userGenerator.GetUserManagerInstance();
            pm.AddUser("", "name","displayname", "email", DateTime.Now, "sts");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddUserNoName()
        {
            var pm = _userGenerator.GetUserManagerInstance();
            pm.AddUser("username", "", "displayname", "email", DateTime.Now, "sts");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddUserNoEmail()
        {
            var pm = _userGenerator.GetUserManagerInstance();
            pm.AddUser("username", "name", "displayname", "", DateTime.Now, "sts");
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddUserNoCreatedBy()
        {
            var pm = _userGenerator.GetUserManagerInstance();
            pm.AddUser("username", "name", "displayname", "email", DateTime.Now, "");
        }

        [TestMethod]
        public void AddUser()
        {
            var email = Guid.NewGuid().ToString();
            var pm = _userGenerator.GetUserManagerInstance();
            var user=  pm.AddUser(Guid.NewGuid().ToString(), "name", "displayname", email, DateTime.Now, "sts");

            var ctx = ContextFactory.GetContext();
            var p = ctx.Users.SingleOrDefault(x => x.Id == user.Id);
            Assert.IsNotNull(p);
            Assert.IsTrue(p.Email == user.Email);

        }

        [TestMethod]
        [ExpectedException(typeof(UserExistsException))]
        public void AddUserWithSameUserName()
        {
            var pm = _userGenerator.GetUserManagerInstance();
            var user = pm.AddUser(Guid.NewGuid().ToString(), "name", "displayname", "email", DateTime.Now, "sts");
            
            // throws...
            var user2 = pm.AddUser(Guid.NewGuid().ToString(), "name", "displayname", "email", DateTime.Now, "sts");
        }


        //[TestMethod]
        //public void GetProject()
        //{
        //    var project = _projectGenerator.AddUser(Guid.NewGuid().ToString(), "Description", "description", DateTime.Now, "sts");

        //    var pm = _projectGenerator.GetProjectManagerInstance();
        //    var p = pm.GetProject(project.Id);

        //    Assert.IsNotNull(p);
        //    Assert.IsTrue(p.Name == project.Name);
        //}

        //[TestMethod]
        //public void GetProjectDoesNotExist()
        //{
        //    var pm = _projectGenerator.GetProjectManagerInstance();
        //    var p = pm.GetProject(Guid.NewGuid());
        //    Assert.IsNull(p);
        //}


    }
}
