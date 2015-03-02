namespace Dk.Schalck.LinkSink.Server.Common
{
    public static class Enumerations
    {
        public enum RecordStatus
        {
            Active = 10,
            InActive = 20,
            Deleted = 99
        }

        public enum ProjectRoleEnum
        {
            ProjectAdministrator = 10,
            SiteAdministrator = 20,
            ProjectReader = 30,
            ProjectContributor = 40
        }
    }
}
