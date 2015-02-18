using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dk.Schalck.LinkSink.Server.Entity
{
    public interface ILinkSinkDatabaseContext
    {
        IDbSet<User> Users { get ; } 
        IDbSet<ProjectRole> Roles { get; } 
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
