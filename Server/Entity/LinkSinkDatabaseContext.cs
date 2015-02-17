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
        public virtual IDbSet<User> Users { get { return Set<User>(); } }
        public virtual IDbSet<ProjectRole> Roles { get { return Set<ProjectRole>(); } }
        public virtual IDbSet<Project> Projects { get { return Set<Project>(); } }
        public virtual IDbSet<ProjectMember> ProjectMembers { get { return Set<ProjectMember>(); } }
        public virtual IDbSet<ProjectMemberRole> ProjectMemberRoles { get { return Set<ProjectMemberRole>(); } }


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

            //modelBuilder.Entity<UserRole>()
            //    .HasRequired(x => x.Role)
            //    .WithMany()
            //    .HasForeignKey(x => x.RoleId);


            //modelBuilder.Entity<UserRole>()
            //    .HasRequired(x => x.User)
            //    .WithMany()
            //    .HasForeignKey(x => x.UserId);


            modelBuilder.Entity<Project>()
                .HasMany(x => x.ProjectMembers)
                .WithRequired(x => x.Project)
                .HasForeignKey(x => x.ProjectId);

            modelBuilder.Entity<ProjectMember>()
                .HasRequired(x => x.Project)
                .WithMany()
                .HasForeignKey(x => x.ProjectId);

            //modelBuilder.Entity<ProjectMemberRole>()
            //    .HasRequired(x => x.ProjectMember)
            //    .WithMany()
            //    .HasForeignKey(x => x.ProjectMemberId);

            //modelBuilder.Entity<ProjectMemberRole>()
            //    .HasRequired(x => x.ProjectRole)
            //    .WithMany()
            //    .HasForeignKey(x => x.ProjectRoleId);

        }
    }
}
