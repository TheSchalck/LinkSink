using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Dk.Schalck.LinkSink.Server.Common;

namespace Dk.Schalck.LinkSink.Server.Entity
{
    public class Link
    {
        [Required]
        [Index("IX_Id", IsUnique = true, IsClustered = false)]
        public Guid Id { get; set; }

        [StringLength(256)]
        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public string Uri { get; set; }
        
        [Required]        
        public Enumerations.RecordStatus PostStatus { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }

        [StringLength(128)]
        [Required]
        public string CreatedBy { get; set; }

        [Required]
        public Guid CreatedByUserId { get; set; }
        [Required]
        public User CreatedByUser { get; set; }

        [Required]
        public Guid ProjectId { get; set; }

        [Required]
        public Project Project { get; set; }
    }
}
