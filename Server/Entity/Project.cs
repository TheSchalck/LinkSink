using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Dk.Schalck.LinkSink.Server.Common;

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
        public Enumerations.RecordStatus PostStatus { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }

        [StringLength(128)]
        [Required]
        public string CreatedBy { get; set; }

        public virtual ICollection<ProjectMember> ProjectMembers { get; set; }
    }
}
