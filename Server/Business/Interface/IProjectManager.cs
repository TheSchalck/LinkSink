using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Dk.Schalck.LinkSink.Server.Common;
using Dk.Schalck.LinkSink.Server.Entity;


namespace Dk.Schalck.LinkSink.Server.Business.Interface
{
    public interface IProjectManager
    {
        bool ExistsProject(Guid projectId);

        Project AddProject(string name, string displayName, string description, DateTime createDate, string createdBy);

        bool DeleteProject(Project project);

        void UpdateProject(Project project);

        List<Project> GetProjectListForUser(User user);

        Project GetProject(Guid projectId);

        ProjectMember AddProjectMember(Project project, User user, DateTime createDate, string createdBy);
        List<ProjectMember> AddProjectMembers(Project project, List<User> users, DateTime createDate, string createdBy);

        void RemoveProjectMember(Project project, User user);
        void RemoveProjectMember(ProjectMember projectMember);

        ProjectMemberRole AddProjectMemberRole(ProjectMember projectMember, Enumerations.ProjectRoleEnum projectRole,
            DateTime createDate, string createdBy);

        void RemoveProjectMemberRole(ProjectMember projectMember, Enumerations.ProjectRoleEnum projectRole);
        void RemoveProjectMemberRole(ProjectMemberRole projectMemberRole);

        List<ProjectMemberRole> AddProjectMemberRoles(ProjectMember projectMember, List<Enumerations.ProjectRoleEnum> projectRoles,
            DateTime createDate, string createdBy);

    }
}
