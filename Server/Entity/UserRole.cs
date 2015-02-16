using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Dk.Schalck.LinkSink.Server.Entity
{
    public class UserRole
    {
        [Required]
        [Index(IsUnique = true, IsClustered = false)]
        public Guid Id { get; set; }


        [Required]
        [Index(IsClustered = true)]
        public Guid UserId { get; set; }

        public User User { get; set; }

        public Guid RoleId { get; set; }

        public Role Role { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }

        [Required]
        public string CreatedBy { get; set; }
    }
}
