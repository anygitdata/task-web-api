using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskWebApi.Models
{
    public class Patient
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PatientId { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        public string Sername { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [Column(TypeName="varchar")]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [MaxLength(100)]
        public string Address { get; set; }

        public DateTime DateBirth { get; set; }
        public bool Pol { get; set; }


        public int SectorId { get; set; }
        public Sector Sector { get; set; }

    }
}