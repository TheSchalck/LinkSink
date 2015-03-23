using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Server.Test.Generators;

namespace Server.Test.Business
{
    [TestClass]
    public class LinkManagerTest : BaseTest
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

    }
}
