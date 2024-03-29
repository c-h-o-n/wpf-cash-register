﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Penztargep_dr1_Domain.Models {
    public class User : DomainObject {
        [Required]
        public string Username { get; set; }
        [Required]
        public string PasswordHash { get; set; }
        [Required]
        public int EmployeeId { get; set; }
        public  Employee Employee { get; set; }

    }
}
