using System;
using Dk.Schalck.LinkSink.Server.Entity;


namespace Dk.Schalck.LinkSink.Server.Business.Interface
{
    public interface IUserManager
    {
        User AddUser(string username, string name, string displayName, string email, DateTime createDate, string createdBy);

        bool DeleteUser(User user);

        void UpdateUser(User user);
    }
}
