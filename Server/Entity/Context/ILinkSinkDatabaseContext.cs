using System;
using System.Data.Entity;

namespace Dk.Schalck.LinkSink.Server.Entity.Context
{
    public interface ILinkSinkDatabaseContext
    {
        IDbSet<User> Users { get ; } 
        IDbSet<ProjectRole> ProjectRoles { get; } 
        IDbSet<Project> Projects { get ; } 
        IDbSet<ProjectMember> ProjectMembers { get ; }
        IDbSet<ProjectMemberRole> ProjectMemberRoles { get ; }


        IDbSet<TEntity> Set<TEntity>() where TEntity : class;
        DbSet Set(Type entityType);
        int SaveChanges();
        Database Database { get; }

        TEntity Single<TEntity>(Func<TEntity, bool> predicate) where TEntity : class;
        TEntity Add<TEntity>(TEntity entity) where TEntity : class;

    }
}
