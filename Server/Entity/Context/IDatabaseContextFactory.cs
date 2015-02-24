using System.Dynamic;

namespace Dk.Schalck.LinkSink.Server.Entity.Context
{
    public interface IDatabaseContextFactory
    {
        ILinkSinkDatabaseContext GetContext();
    }
}
