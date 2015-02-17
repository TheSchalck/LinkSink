using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dk.Schalck.LinkSink.Server.Entity.Migrations
{
    public class LinkSinkDatabaseMigrationConfiguration : DbMigrationsConfiguration<LinkSinkDatabaseContext>
    {
        public LinkSinkDatabaseMigrationConfiguration()
        {
            SetVariables(false);
        }

        public LinkSinkDatabaseMigrationConfiguration(bool automaticMigrationDataLossAllowed)
        {
            SetVariables(automaticMigrationDataLossAllowed);
        }

        private void SetVariables(bool automaticMigrationDataLossAllowed)
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = automaticMigrationDataLossAllowed;
            var tables = new List<string>() { "dbo.Users", "dbo.ProjectRoles", "dbo.Projects", "dbo.ProjectMembers", "dbo.ProjectMemberRoles" };
            SetSqlGenerator("System.Data.SqlClient", new CustomMigrationSqlGenerator(tables));

        }


        protected override void Seed(LinkSinkDatabaseContext context)
        {
        }

    }
}
