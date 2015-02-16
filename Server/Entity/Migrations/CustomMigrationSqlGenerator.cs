using System.Collections.Generic;
using System.Data.Entity.Migrations.Model;
using System.Data.Entity.SqlServer;

namespace Dk.Schalck.LinkSink.Server.Entity.Migrations
{
    public class CustomMigrationSqlGenerator  : SqlServerMigrationSqlGenerator
    {
   
        private readonly List<string> _tableList;

        public CustomMigrationSqlGenerator(List<string> tablesWithoutAutomaticClusteredPrimaryKey)
        {
            _tableList = tablesWithoutAutomaticClusteredPrimaryKey;
        }

        protected override void Generate(AddColumnOperation addColumnOperation)
        {
            base.Generate(addColumnOperation);
        }

        protected override void Generate(AddPrimaryKeyOperation addPrimaryKeyOperation)
        {
            if (_tableList.Contains(addPrimaryKeyOperation.Table))
                addPrimaryKeyOperation.IsClustered = false;
            else
                addPrimaryKeyOperation.IsClustered = true;

            base.Generate(addPrimaryKeyOperation);
        }

        protected override void Generate(CreateTableOperation createTableOperation)
        {
            if (_tableList.Contains(createTableOperation.Name))
                createTableOperation.PrimaryKey.IsClustered = false;
            else
                createTableOperation.PrimaryKey.IsClustered = true;

            base.Generate(createTableOperation);
        }
        protected override void Generate(MoveTableOperation moveTableOperation)
        {
            moveTableOperation.CreateTableOperation.PrimaryKey.IsClustered = false;
            if (_tableList.Contains(moveTableOperation.Name))
                moveTableOperation.CreateTableOperation.PrimaryKey.IsClustered = false;
            else
                moveTableOperation.CreateTableOperation.PrimaryKey.IsClustered = true;

            base.Generate(moveTableOperation);
        }

    }
}
