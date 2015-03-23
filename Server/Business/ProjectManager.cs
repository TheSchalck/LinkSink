using System;
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

        #region Project methods

        public bool ExistsProject(Guid projectId)
        {
            // TODO - missing Unit test
            var ctx = Factory.GetContext();
            return ctx.Projects.Any(x => x.Id == projectId);
        }

        public Project AddProject(string name, string displayName, string description, DateTime createDate,
            string createdBy)
        {
            // Ensure valid data
            EnsureValidProjectData(name, displayName, createDate, createdBy);

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

        private void EnsureValidProjectData(string name, string displayName, DateTime createDate, string createdBy)
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

        public bool DeleteProject(Project project)
        {
            throw new NotImplementedException();
        }

        public void UpdateProject(Project project)
        {
            throw new NotImplementedException();
        }

        #endregion


        #region ProjectMember methods

        public ProjectMember AddProjectMember(Project project, User user, DateTime createDate, string createdBy)
        {

            var ctx = Factory.GetContext();

            var exists =
                ctx.ProjectMembers.SingleOrDefault(member => member.ProjectId == project.Id && member.UserId == user.Id);
            if (exists != null)
                return exists;

            var pm = new ProjectMember
            {
                Id = Guid.NewGuid(),
                Project = project,
                User = user,
                CreateDate = createDate,
                CreatedBy = createdBy
            };
            ctx.Projects.Attach(project);
            ctx.Users.Attach(user);
            var result = ctx.ProjectMembers.Add(pm);
            ctx.SaveChanges();
            return result;
        }

        public List<ProjectMember> AddProjectMembers(Project project, List<User> users, DateTime createDate,
            string createdBy)
        {
            var list = new List<ProjectMember>();

            var ctx = Factory.GetContext();
            ctx.Projects.Attach(project);

            var existingMembers = ctx.ProjectMembers.Where(x => x.ProjectId == project.Id).ToList();


            foreach (var user in users)
            {
                if (existingMembers.Any(x => x.UserId == user.Id))
                {
                    list.Add(existingMembers.Single(x => x.UserId == user.Id));
                }
                else
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

        public void RemoveProjectMember(ProjectMember projectMember)
        {
            var ctx = Factory.GetContext();
            var pm = ctx.ProjectMembers.Attach(projectMember);
            ctx.ProjectMembers.Remove(pm);
            ctx.SaveChanges();
        }

        #endregion


        #region ProjectMemberRoles

        public ProjectMemberRole AddProjectMemberRole(ProjectMember projectMember, Enumerations.ProjectRoleEnum projectRole,
            DateTime createDate, string createdBy)
        {

            var ctx = Factory.GetContext();

            var exists =
                ctx.ProjectMemberRoles.SingleOrDefault(
                    role => role.ProjectMemberId == projectMember.Id && role.ProjectRoleId == (int)projectRole);
            if (exists != null)
                return (exists);

            var pm = new ProjectMemberRole
            {
                Id = Guid.NewGuid(),
                ProjectMemberId = projectMember.Id,
                ProjectRoleId = (int)projectRole,
                CreateDate = createDate,
                CreatedBy = createdBy
            };

            var result = ctx.ProjectMemberRoles.Add(pm);
            ctx.SaveChanges();
            return result;

        }

        public void RemoveProjectMemberRole(ProjectMember projectMember, Enumerations.ProjectRoleEnum projectRole)
        {
            var ctx = Factory.GetContext();
            var pm =
                ctx.ProjectMemberRoles.SingleOrDefault(
                    x => x.ProjectMemberId == projectMember.Id && x.ProjectRoleId == (int)projectRole);
            if (pm == null)
                return;

            ctx.ProjectMemberRoles.Remove(pm);
            ctx.SaveChanges();
        }

        public void RemoveProjectMemberRole(ProjectMemberRole projectMemberRole)
        {
            var ctx = Factory.GetContext();
            var pm = ctx.ProjectMemberRoles.Attach(projectMemberRole);
            ctx.ProjectMemberRoles.Remove(pm);
            ctx.SaveChanges();
        }

        public List<ProjectMemberRole> AddProjectMemberRoles(ProjectMember projectMember, List<Enumerations.ProjectRoleEnum> projectRoles,
            DateTime createDate, string createdBy)
        {
            var list = new List<ProjectMemberRole>();

            var ctx = Factory.GetContext();

            var existingMemberRoles = ctx.ProjectMemberRoles.Where(x => x.ProjectMemberId == projectMember.Id).ToList();

            foreach (var role in projectRoles)
            {
                if (existingMemberRoles.Any(memberRole => memberRole.ProjectRoleId == (int)role))
                {
                    list.Add(existingMemberRoles.Single(memberRole => memberRole.ProjectRoleId == (int)role));
                }
                else
                {
                    var pm = new ProjectMemberRole
                    {
                        Id = Guid.NewGuid(),
                        ProjectMemberId = projectMember.Id,
                        ProjectRoleId = (int)role,
                        CreateDate = createDate,
                        CreatedBy = createdBy
                    };
                    list.Add(ctx.ProjectMemberRoles.Add(pm));

                }
            }
            ctx.SaveChanges();
            return list;
        }

        #endregion



        public List<Project> GetProjectListForUser(User user)
        {
            throw new NotImplementedException();
        }



    }
}
