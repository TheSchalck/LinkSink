using System;
using Dk.Schalck.LinkSink.Server.Business;
using Dk.Schalck.LinkSink.Server.Business.Interface;
using Dk.Schalck.LinkSink.Server.Entity;
using Dk.Schalck.LinkSink.Server.Entity.Context;

namespace Server.Test.Generators
{
    public class UserGenerator : BaseGenerator
    {
        public IUserManager GetUserManagerInstance()
        {
            var mgr = new UserManager(ContextFactory);
            return mgr;
        }

        public User AddUser(string username, string name, string displayname, string email, DateTime createDate, string createdBy)
        {
            var p = GetUserManagerInstance();
            var result =  p.AddUser(username, name, displayname, email, createDate, createdBy);
            return result;
        }
    }
}
