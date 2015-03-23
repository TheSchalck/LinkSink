using System;
using Dk.Schalck.LinkSink.Server.Business;
using Dk.Schalck.LinkSink.Server.Business.Interface;
using Dk.Schalck.LinkSink.Server.Entity;
using Dk.Schalck.LinkSink.Server.Entity.Context;

namespace Server.Test.Generators
{
    public class LinkGenerator : BaseGenerator
    {
        public ILinkManager GetLinkManagerInstance()
        {
            var mgr = new LinkManager(ContextFactory);
            return mgr;
        }

        public Link AddLink(Guid userId, string description, Guid projectId, string title, string uri)
        {
            var p = GetLinkManagerInstance();
            var result =  p.AddLink(userId, description, projectId, title, uri);
            return result;
        }
        public Link AddLink(Guid userId, Guid projectId)
        {
            var p = GetLinkManagerInstance();
            var result =  p.AddLink(userId, Guid.NewGuid().ToString(), projectId, Guid.NewGuid().ToString(), Guid.NewGuid().ToString());
            return result;
        }
    }
}
