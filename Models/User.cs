using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace API.Models
{
    public class User
    {
        [Key]
        [ForeignKey("Employee")]
        public int Id { get; set; }

        public string? Password { get; set; }
        [ForeignKey("RoleId")]

        public int RoleId { get; set; }

        public virtual Role Roles { get; set; }

        public virtual Employee Employee { get; set; }
    }
}

