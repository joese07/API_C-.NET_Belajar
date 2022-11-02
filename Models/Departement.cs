using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API.Models
{
    public class Departement
    {
        [Key]
      public int Id { get; set; }

        public string Name { get; set; }

        public int DivisionId { get; set; }

        [ForeignKey("DivisionId")]
        [JsonIgnore]
        public virtual Division? Divisions { get; set; }
    }
}

