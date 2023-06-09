﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(200)]
        public string Name { get; set; }
        [StringLength(200)]
        public string Apellido { get; set; }
        [StringLength(200)]
        public string Fullname { get; set; }
        [StringLength(200)]
        public string Email { get; set; }
        public List<Loggins> Loggins { get; set; } = new List<Loggins>();

    }
}
