using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Migrations.Model;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dk.Schalck.LinkSink.Server.Entity
{
    public class Project
    {
        [Required]
        [Index("IX_Id", IsUnique = true, IsClustered = false)]
        public Guid Id { get; set; }

        [StringLength(128)]
        [Required]
        public string Name { get; set; }

        [StringLength(128)]
        [Required]
        public string DisplayName { get; set; }

        public string Description { get; set; }

        [Required]
        public int PostStatus { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }

        [StringLength(128)]
        [Required]
        public string CreatedBy { get; set; }

        public virtual ICollection<ProjectAdministrator> ProjectAdministrators { get; set; }
    }
}
