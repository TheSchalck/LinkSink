using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dk.Schalck.LinkSink.Server.Entity.Context;

namespace Dk.Schalck.LinkSink.Server.Business
{
    public abstract class BaseManager
    {
        public IDatabaseContextFactory Factory { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Object"/> class.
        /// </summary>
        protected BaseManager(IDatabaseContextFactory factory)
        {
            Factory = factory;
        }
    }
}
