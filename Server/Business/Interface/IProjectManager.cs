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
        void AddProject(Project project );

        bool DeleteProject(Project project);

        void UpdateProject(Project project);

        List<Project> GetProjectListForUser(User user);


    }
}
