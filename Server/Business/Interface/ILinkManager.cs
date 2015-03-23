using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dk.Schalck.LinkSink.Server.Entity;

namespace Dk.Schalck.LinkSink.Server.Business.Interface
{
    public interface ILinkManager
    {
    
        Link AddLink(Guid userId, string description, Guid projectId, string title, string uri);

        Link UpdateLink(Link link);

        void DeleteLink(Link link);

        void DeleteLink(Guid linkId);

    }
}
