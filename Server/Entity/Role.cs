using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Dk.Schalck.LinkSink.Server.Entity
{
    public class Role
    {
        [Required]
        [Index(IsUnique = true, IsClustered = false)]
        public Guid Id { get; set; }

        [Required]
        [Index(IsUnique = true, IsClustered = true)]
        [StringLength(128)]
        public string Name { get; set; }

        [Required]
        public string DisplayName { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }
        [Required]
        public string CreatedBy { get; set; }

        [Required]
        public int PostStatus { get; set; }


    }
}
