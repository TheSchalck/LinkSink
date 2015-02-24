using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Dk.Schalck.LinkSink.Server.Entity;


namespace Dk.Schalck.LinkSink.Server.Business.Interface
{
    public interface IProjectManager
    {
        Project AddProject(string name, string displayName, string description, DateTime createDate, string createdBy);

        bool DeleteProject(Project project);

        void UpdateProject(Project project);

        List<Project> GetProjectListForUser(User user);

        Project GetProject(Guid projectId);

        ProjectMember AddProjectMember(Project project, User user, DateTime createDate, string createdBy);
        List<ProjectMember> AddProjectMembers(Project project, List<User> users, DateTime createDate, string createdBy);

        void RemoveProjectMember(Project project, User user);


    }
}
