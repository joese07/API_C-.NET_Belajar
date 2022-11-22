using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        public string FullName { get; set; }

        public string Gender { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string BirthDate { get; set; }

        public int DepartementId { get; set; }

        [ForeignKey("DepartementId")]
        [JsonIgnore]
        public virtual Departement? Departements { get; set; }

    }
}

