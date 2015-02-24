using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dk.Schalck.LinkSink.Server.Common;

namespace Dk.Schalck.LinkSink.Server.Entity
{
    public class ProjectMember
    {
        [Required]
        [Index("IX_Id", IsUnique = true, IsClustered = false)]
        public Guid Id { get; set; }

        [Required]
        [Index("IX_ProjectId", IsUnique = false, IsClustered = true)]
        public Guid ProjectId { get; set; }

        public Project Project { get; set; }

        [Required]
        public Guid UserId { get; set; }

        /// <summary>
        /// Gets or sets the user as navigational property.
        /// </summary>
        /// <value>
        /// The user.
        /// </value>
        public User User { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }

        [StringLength(128)]
        [Required]
        public string CreatedBy { get; set; }

        public virtual ICollection<ProjectMemberRole> ProjectMemberRoles { get; set; }
    }
}
