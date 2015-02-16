using System;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.IO;
using System.Management.Automation;
using Dk.Schalck.LinkSink.Automation.Management.Extension;
using Dk.Schalck.LinkSink.Automation.Management.Infrastructure;

namespace Dk.Schalck.LinkSink.Automation.Management.Database
{
    public abstract class BaseDatabaseCmdlet : PSCmdlet
    {
        private readonly string _connectionStringName;
        protected DbContext _context;
        protected AppConfig _configScope;
        private const string DatabaseUserPassConnstr =
            @"data source={0};initial catalog={1};integrated security=False; User={2}; Password={3}; MultipleActiveResultSets=True;App=KuAppCmdlets";

        private const string DatabaseIntegratedConnstr =
            @"data source={0};initial catalog={1};integrated security=True;MultipleActiveResultSets=True;App=KuAppCmdlets";

        public BaseDatabaseCmdlet(string connectionStringName)
        {
            _connectionStringName = connectionStringName;
        }

        /// <summary>
        /// The server name
        /// </summary>
        [Parameter]
        public string Server { get; set; }

        /// <summary>
        /// The database name
        /// </summary>
        [Parameter]
        public string DatabaseName { get; set; }

        /// <summary>
        /// The user name
        /// </summary>
        [Parameter]
        public string UserName { get; set; }

        /// <summary>
        /// The password
        /// </summary>
        [Parameter]
        public string Password { get; set; }


        protected override void BeginProcessing()
        {
            _configScope = KuAppConfigScope();
            base.BeginProcessing();
        }

        protected override void EndProcessing()
        {
            if (_context != null)
            {
                _context.Database.Connection.Close();
                _context.Dispose();
                _context = null;
            }
            base.EndProcessing();
            _configScope.Dispose();
        }

        protected override void StopProcessing()
        {
            if (_context != null)
            {
                _context.Database.Connection.Close();
                _context.Dispose();
                _context = null;
            }
            base.StopProcessing();
            _configScope.Dispose();
        }

        /// <summary>
        /// Returns connection string from parameters
        /// </summary>
        protected string GetDatabaseConnectionString()
        {
            var conn = ConfigurationManager.ConnectionStrings[_connectionStringName];
            if (conn != null)
                return conn.ConnectionString;

            return UserName != null || Password != null
                       ? string.Format(DatabaseUserPassConnstr, Server, DatabaseName, UserName, Password)
                       : string.Format(DatabaseIntegratedConnstr, Server, DatabaseName);
        }

        public void WriteExceptionError(DbEntityValidationException ex, object targetObject = null)
        {
            if (targetObject == null) targetObject = MyInvocation.BoundParameters;
            WriteError(new ErrorRecord(new InvalidOperationException(ex.EntityValidationErrorMessage(), ex), this.GetType().Name, ErrorCategory.InvalidOperation, targetObject));
        }

        public void WriteExceptionError(Exception ex, object targetObject = null)
        {
            if (targetObject == null) targetObject = MyInvocation.BoundParameters;
            var evex = ex as DbEntityValidationException;
            if (evex != null) WriteExceptionError(evex, targetObject);
            else WriteError(new ErrorRecord(new InvalidOperationException(ex.GetBaseException().Message, ex), this.GetType().Name, ErrorCategory.InvalidOperation, targetObject));
        }

        private AppConfig KuAppConfigScope()
        {
            var assemblyName = GetType().Assembly.GetName().Name;
            var configLocation = Path.Combine(Path.GetDirectoryName(GetType().Assembly.Location), assemblyName + ".dll.config");
            return AppConfig.Change(configLocation);
        }
        
    }
}