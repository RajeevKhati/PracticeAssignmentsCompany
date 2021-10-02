using Company.Project.Core.Domain.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Company.Project.EventDomain.Domain
{
    public class Event : DomainBase
    {

        [Required()]
        public string TitleOfBook { get; set; }

        [Required()]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required()]
        public string Location { get; set; }

        [Required()]
        public string UserID { get; set; }

        [Required()]
        [DataType(DataType.Time)]
        public TimeSpan StartTime { get; set; }

        [Required()]
        public bool Type { get; set; } //true => private, false => public

        [Range(0,4)]
        public int DurationInHours { get; set; }

        [MaxLength(50)]
        public string Description { get; set; }

        [MaxLength(500)]
        public string OtherDetails { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }
}
