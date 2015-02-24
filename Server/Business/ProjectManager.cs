﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Dk.Schalck.LinkSink.Server.Business.Interface;
using Dk.Schalck.LinkSink.Server.Common;
using Dk.Schalck.LinkSink.Server.Entity;
using Dk.Schalck.LinkSink.Server.Entity.Context;

namespace Dk.Schalck.LinkSink.Server.Business
{
    public class ProjectManager : BaseManager, IProjectManager
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Object"/> class.
        /// </summary>
        public ProjectManager(IDatabaseContextFactory factory)
            : base(factory)
        {
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

            var context = Factory.GetContext();
            context.Projects.Add(p);
            context.SaveChanges();

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
                throw new ArgumentException(createDate.ToString());

        }

        public Project GetProject(Guid projectId)
        {
            var context = Factory.GetContext();
            var p = context.Projects
                .Include(x => x.ProjectMembers)
                .SingleOrDefault(x => x.Id == projectId);
            return p;
        }

        public ProjectMember AddProjectMember(Project project, User user, DateTime createDate, string createdBy)
        {
            var pm = new ProjectMember
            {
                Id = Guid.NewGuid(),
                Project = project,
                User = user,
                CreateDate = createDate,
                CreatedBy = createdBy
            };
            var ctx = Factory.GetContext();
            ctx.Projects.Attach(project);
            ctx.Users.Attach(user);
            var result = ctx.ProjectMembers.Add(pm);
            ctx.SaveChanges();
            return result;
        }

        public List<ProjectMember> AddProjectMembers(Project project, List<User> users, DateTime createDate, string createdBy)
        {
            var list = new List<ProjectMember>();

            var ctx = Factory.GetContext();
            ctx.Projects.Attach(project);

            foreach (var user in users)
            {
                var pm = new ProjectMember
                {
                    Id = Guid.NewGuid(),
                    Project = project,
                    User = user,
                    CreateDate = createDate,
                    CreatedBy = createdBy
                };
                ctx.Users.Attach(user);
                list.Add(ctx.ProjectMembers.Add(pm));
            }

            ctx.SaveChanges();
            return list;
        }

        public void RemoveProjectMember(Project project, User user)
        {
            var ctx = Factory.GetContext();
            var pm = ctx.ProjectMembers.SingleOrDefault(x => x.ProjectId == project.Id && x.UserId == user.Id);
            if (pm == null)
                return;

            ctx.ProjectMembers.Remove(pm);
            ctx.SaveChanges();
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
