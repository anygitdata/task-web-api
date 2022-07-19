using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskWebApi.Models
{
    public class Doctor
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DoctorId { get; set; }

        [Required]
        [Column(TypeName="varchar")]
        [MaxLength(100)]
        public string FullName { get; set; }


        public int CabinetId { get; set; } = 1;
        public Cabinet Cabinet { get; set; }


        public int SpecializationId { get; set; } = 1;
        public Specialization Specialization { get; set; }

        public int? SectorId { get; set; } = null;
        public Sector Sector { get; set; }

    }
}