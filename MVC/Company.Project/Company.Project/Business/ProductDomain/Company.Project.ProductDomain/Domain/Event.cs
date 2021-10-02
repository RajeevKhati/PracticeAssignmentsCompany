using Company.Project.Core.Domain.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Company.Project.ProductDomain.Domain
{
    public class Event : DomainBase
    {

        /// <summary>
        /// Gets or sets the name of the title of the book.
        /// </summary>
        /// <value>
        /// The name of the book.
        /// </value>
        [Required()]
        public string TitleOfBook { get; set; }

        /// <summary>
        /// Gets or sets the date of event.
        /// </summary>
        /// <value>
        /// date at which event is going to occur.
        /// </value>
        [Required()]
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        /// <value>
        /// location of event.
        /// </value>
        [Required()]
        public string Location { get; set; }
        [Required()]
        [ForeignKey("User")]
        public int UserID { get; set; }

        public virtual ICollection<EventAndPerson> EventsAndPeople { get; set; }
    }
}
