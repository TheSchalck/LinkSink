using System;
using Dk.Schalck.LinkSink.Server.Entity;


namespace Dk.Schalck.LinkSink.Server.Business.Interface
{
    public interface IUserManager
    {
        User AddUser(string username, string name, string description, string email, DateTime createDate, string createdBy);

        void DeleteUser(User user);

        void UpdateUser(User user);

        User GetUser(Guid id);

        User GetUser(string email);

        bool ExistsUser(string email);
        bool ExistsUser(Guid userId);

    }
}
