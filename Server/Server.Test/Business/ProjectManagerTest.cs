using System;
using Dk.Schalck.LinkSink.Server.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Server.Test.Business
{
    [TestClass]
    public class ProjectManagerTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddProjectNoName()
        {
            var ctx = new LinkSinkDatabaseContext();
        }


        [TestMethod]
        public void GetProject()
        {
        }

    }
}
