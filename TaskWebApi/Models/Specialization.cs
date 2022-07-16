using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskWebApi.Models
{
    public class Specialization
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SpecializationId { get; set; }


        [Required]
        [Index(IsUnique = true)]
        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        public string Title { get; set; }

        public ICollection<Doctor> Doctors { get; set; }



    }
}