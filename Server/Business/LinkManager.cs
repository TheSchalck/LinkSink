using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dk.Schalck.LinkSink.Server.Business.Interface;
using Dk.Schalck.LinkSink.Server.Common;
using Dk.Schalck.LinkSink.Server.Entity;
using Dk.Schalck.LinkSink.Server.Entity.Context;

namespace Dk.Schalck.LinkSink.Server.Business
{
    public class LinkManager : BaseManager, ILinkManager
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Object"/> class.
        /// </summary>
        public LinkManager(IDatabaseContextFactory factory) : base(factory)
        {
        }

        public Link AddLink(Guid userId, string description, Guid projectId, string title, string uri)
        {
            EnsureValidLinkData(title, description, userId, projectId, uri);

            var link = new Link
            {
                CreateDate = DateTime.UtcNow,
                CreatedByUserId = userId,
                Description = description,
                Id = Guid.NewGuid(),
                PostStatus = Enumerations.RecordStatus.Active,
                ProjectId = projectId,
                Title = title,
                Uri = uri
            };

            var ctx = Factory.GetContext();
            ctx.Links.Add(link);

            return link;
        }

        public Link UpdateLink(Link link)
        {
            throw new NotImplementedException();
        }

        public void DeleteLink(Link link)
        {
           DeleteLink(link.Id);
        }

        public void DeleteLink(Guid linkId)
        {
            var ctx = Factory.GetContext();
            var link = ctx.Links.SingleOrDefault(x => x.Id == linkId);
            if (link == null)
                return;

            link.PostStatus = Enumerations.RecordStatus.Deleted;
            ctx.SaveChanges();
            return;
        }

        private bool EnsureValidLinkData(string title, string description, Guid userId, Guid projectId,  string uri)
        {
            // TODO -- remains to be implemented


            if (string.IsNullOrEmpty(title))
                throw new ArgumentException(title);
            if (string.IsNullOrEmpty(description))
                throw new ArgumentException(description);
            if (string.IsNullOrEmpty(uri))
                throw new ArgumentException(uri);

            var userManager = new UserManager(Factory);
            if (!userManager.ExistsUser(userId))
                throw new ArgumentException(userId.ToString());

            var projectManager = new ProjectManager(Factory);
            if (!projectManager.ExistsProject(projectId))
                throw new ArgumentException(projectId.ToString());

            return true;
        }

    }
}
