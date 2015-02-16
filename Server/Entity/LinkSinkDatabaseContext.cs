using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dk.Schalck.LinkSink.Server.Entity
{
    public class LinkSinkDatabaseContext : DbContext, ILinkSinkDatabaseContext
    {
        //public virtual IDbSet<Message> Messages { get { return Set<Message>(); } }
        //public virtual IDbSet<MessageSource> MessageSources { get { return Set<MessageSource>(); } }
        //public virtual IDbSet<ReceiverBase> Receivers { get { return Set<ReceiverBase>(); } }
        //public virtual IDbSet<MessageRead> MessageReads { get { return Set<MessageRead>(); } }
        public virtual IDbSet<User> Users { get { return Set<User>(); } }
        public virtual IDbSet<Role> Roles { get { return Set<Role>(); } }
        public virtual IDbSet<UserRole> UserRoles { get { return Set<UserRole>(); } }


        public LinkSinkDatabaseContext()
            : this("linkSinkDbConnection")
        { }
        public LinkSinkDatabaseContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        { }
        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        public TEntity Single<TEntity>(Func<TEntity, bool> predicate) where TEntity : class
        {
            return base.Set<TEntity>().Single(predicate);
        }

        public TEntity Add<TEntity>(TEntity entity) where TEntity : class
        {

            return base.Set<TEntity>().Add(entity);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<UserRole>()
                .HasRequired(x => x.Role)
                .WithMany()
                .HasForeignKey(x => x.RoleId);


            modelBuilder.Entity<UserRole>()
                .HasRequired(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.UserId);


            modelBuilder.Entity<Project>()
                .HasMany(x => x.ProjectAdministrators)
                .WithRequired(x => x.Project)
                .HasForeignKey(x => x.ProjectId);

            modelBuilder.Entity<ProjectAdministrator>()
                .HasRequired(x => x.Project)
                .WithMany()
                .HasForeignKey(x => x.ProjectId);


        }
    }
}
