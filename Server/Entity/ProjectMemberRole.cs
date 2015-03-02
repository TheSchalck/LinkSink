using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Dk.Schalck.LinkSink.Server.Common;

namespace Dk.Schalck.LinkSink.Server.Entity
{
    public class ProjectMemberRole
    {
        [Required]
        [Index(IsUnique = true, IsClustered = false)]
        public Guid Id { get; set; }

        [Required]
        public Guid ProjectMemberId { get; set; }

        public ProjectMember ProjectMember { get; set; }

        [Required]
        public int ProjectRoleId { get; set; }

        public ProjectRole ProjectRole { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }
        [Required]
        public string CreatedBy { get; set; }


    }
}
