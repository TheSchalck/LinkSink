using System;
using System.Linq;
using Dk.Schalck.LinkSink.Server.Business.Interface;
using Dk.Schalck.LinkSink.Server.Common;
using Dk.Schalck.LinkSink.Server.Common.Exception;
using Dk.Schalck.LinkSink.Server.Entity;
using Dk.Schalck.LinkSink.Server.Entity.Context;

namespace Dk.Schalck.LinkSink.Server.Business
{
    public class UserManager : BaseManager, IUserManager
    {
        public UserManager(IDatabaseContextFactory factory) : base(factory)
        {
        }

        public User AddUser(string username, string name, string displayName, string email, DateTime createDate, string createdBy)
        {
            EnsureValidData(username, name, ref displayName, email, createdBy);

            // Check if user exists on email
            var existUser = GetUser(email);
            if (existUser != null)
                throw new UserExistsException(string.Format("User with email <{0}> already exists", email));

            Guid id = Guid.NewGuid();
            var user = new User
            {
                CreateDate = DateTime.Now,
                CreatedBy = createdBy,
                DisplayName = displayName,
                Email = email,
                Id = id,
                Name = name,
                PostStatus = Enumerations.RecordStatus.Active,
                UserName = username
            };
            var ctx = Factory.GetContext();
            ctx.Add(user);
            ctx.SaveChanges();
            return (user);
        }

        public bool DeleteUser(User user)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(User user)
        {
            throw new NotImplementedException();
        }

        public User GetUser(Guid id)
        {
            throw new NotImplementedException();
        }

        public User GetUser(string email)
        {
            var ctx = Factory.GetContext();
            var user = ctx.Users.SingleOrDefault(x => x.Email == email);
            return user;
        }

        private void EnsureValidData(string username, string name, ref string displayName, string email, string createdBy)
        {
            if (string.IsNullOrEmpty(username))
                throw new ArgumentException(username);
            
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException(name);
            
            if (string.IsNullOrEmpty(email))
                throw new ArgumentException(email);
            
            if (string.IsNullOrEmpty(displayName))
                displayName = username;
            
            if (string.IsNullOrEmpty(createdBy))
                throw new ArgumentException(createdBy);
            
        }

    }

}
