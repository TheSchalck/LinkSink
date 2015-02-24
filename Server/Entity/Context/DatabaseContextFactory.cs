namespace Dk.Schalck.LinkSink.Server.Entity.Context
{
    public class DatabaseContextFactory : IDatabaseContextFactory
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Object"/> class.
        /// </summary>
        public DatabaseContextFactory()
        {
        }

        public  ILinkSinkDatabaseContext GetContext()
        {
            return new LinkSinkDatabaseContext();
        }
    }
}
