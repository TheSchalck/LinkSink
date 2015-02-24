using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Dk.Schalck.LinkSink.Server.Business.Interface;
using Dk.Schalck.LinkSink.Server.Common;
using Dk.Schalck.LinkSink.Server.Entity;
using Dk.Schalck.LinkSink.Server.Entity.Context;

namespace Dk.Schalck.LinkSink.Server.Business
{
    public class ProjectManager : IProjectManager
    {
        private readonly ILinkSinkDatabaseContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Object"/> class.
        /// </summary>
        public ProjectManager(ILinkSinkDatabaseContext context)
        {
            _context = context;
        }

        public Project AddProject(string name, string displayName, string description, DateTime createDate, string createdBy)
        {
            // Ensure valid data
            EnsureValidData(name, displayName, createDate, createdBy);

            Guid id = Guid.NewGuid();
            var p = new Project
            {
                CreateDate = createDate,
                CreatedBy = createdBy,
                Description = description,
                DisplayName = displayName,
                Id = id,
                Name = name,
                PostStatus = Enumerations.RecordStatus.Active
            };

            _context.Projects.Add(p);
            _context.SaveChanges();

            return p;
        }

        private void EnsureValidData(string name, string displayName, DateTime createDate, string createdBy)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException(name);
            if (string.IsNullOrEmpty(displayName))
                throw new ArgumentException(displayName);
            if (string.IsNullOrEmpty(createdBy))
                throw new ArgumentException(createdBy);
            if (createDate == null)
                throw new ArgumentException(createdBy);
            
        }

        public Project GetProject(Guid projectId)
        {
            var p = _context.Projects
                .Include(x=>x.ProjectMembers)
                .SingleOrDefault(x => x.Id == projectId);
            return p;
        }

        public bool DeleteProject(Project project)
        {
            throw new NotImplementedException();
        }

        public void UpdateProject(Project project)
        {
            throw new NotImplementedException();
        }

        public List<Project> GetProjectListForUser(User user)
        {
            throw new NotImplementedException();
        }

    }
}
