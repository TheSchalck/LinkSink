using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dk.Schalck.LinkSink.Server.Entity.Context;

namespace Server.Test.Generators
{
    public abstract class BaseGenerator
    {
        private IDatabaseContextFactory _factory;

        public IDatabaseContextFactory ContextFactory
        {
            get
            {
                if (_factory == null)
                    _factory = new DatabaseContextFactory();
                return _factory;
            }
        }
    }
}
