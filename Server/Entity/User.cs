using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Dk.Schalck.LinkSink.Server.Common;

namespace Dk.Schalck.LinkSink.Server.Entity
{
    public class User
    {
        [Required]
        [Index(IsUnique = true, IsClustered = false)]
        public Guid Id { get; set; }

        [Required]
        [StringLength(128)]
        [Index(IsUnique = false, IsClustered = false)]
        public string UserName { get; set; }

        [Required]
        [StringLength(128)]
        public string Name { get; set; }
        
        [Required]
        [StringLength(128)]
        public string Description { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [StringLength(256)]
        public string Email { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }

        [Required]
        [StringLength(128)]
        public string CreatedBy { get; set; }

        [Required]
        public Enumerations.RecordStatus PostStatus { get; set; }

    }
}
