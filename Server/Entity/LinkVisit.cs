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
    public class LinkVisit
    {
        [Required]
        [Index("IX_Id", IsUnique = true, IsClustered = false)]
        public Guid Id { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }

        [Required]
        public Guid LinkId { get; set; }

        public Link Link { get; set; }

        [Required]
        public Guid CreatedByUserId { get; set; }
        [Required]
        public User CreatedByUser { get; set; }
    }
}
