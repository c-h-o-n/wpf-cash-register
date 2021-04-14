using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Penztargep_dr1_Domain.Models {
    /// <summary>
    /// Ensures that every model has an Id
    /// </summary>
    public class DomainObject {
        [Key]
        public int Id { get; set; }
    }
}
