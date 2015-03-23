using System;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Dk.Schalck.LinkSink.Server.Entity.Context
{
    public class LinkSinkDatabaseContext : DbContext, ILinkSinkDatabaseContext
    {
        public virtual IDbSet<User> Users { get { return Set<User>(); } }
        public virtual IDbSet<ProjectRole> ProjectRoles { get { return Set<ProjectRole>(); } }
        public virtual IDbSet<Project> Projects { get { return Set<Project>(); } }
        public virtual IDbSet<ProjectMember> ProjectMembers { get { return Set<ProjectMember>(); } }
        public virtual IDbSet<ProjectMemberRole> ProjectMemberRoles { get { return Set<ProjectMemberRole>(); } }
        public virtual IDbSet<Link> Links { get; private set; }


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
            modelBuilder.Entity<Project>()
                .HasMany(x => x.ProjectMembers)
                .WithRequired(x => x.Project)
                .HasForeignKey(x => x.ProjectId);

            modelBuilder.Entity<ProjectMember>()
                .HasRequired(x => x.Project)
                .WithMany()
                .HasForeignKey(x => x.ProjectId);


            modelBuilder.Entity<ProjectMember>()
                .HasMany(x => x.ProjectMemberRoles)
                .WithRequired(x => x.ProjectMember)
                .HasForeignKey(x => x.ProjectMemberId);

            modelBuilder.Entity<ProjectMemberRole>()
                .HasRequired(x => x.ProjectMember)
                .WithMany()
                .HasForeignKey(x => x.ProjectMemberId);

            modelBuilder.Entity<ProjectRole>()
                .HasMany(x => x.ProjectMemberRoles)
                .WithRequired(x => x.ProjectRole)
                .HasForeignKey(x => x.ProjectRoleId);

            modelBuilder.Entity<ProjectMemberRole>()
                .HasRequired(x => x.ProjectRole)
                .WithMany()
                .HasForeignKey(x => x.ProjectRoleId);

            modelBuilder.Entity<Project>()
                .HasMany(x => x.Links)
                .WithRequired(x => x.Project)
                .HasForeignKey(x => x.ProjectId);

            modelBuilder.Entity<Link>()
                .HasRequired(x => x.Project)
                .WithMany()
                .HasForeignKey(x => x.ProjectId);

            modelBuilder.Entity<Link>()
                .HasRequired(x => x.CreatedByUser);

        }
    }
}
