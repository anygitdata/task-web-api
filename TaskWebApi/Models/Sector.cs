using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskWebApi.Models
{
    public class Sector
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SectorId { get; set; }
        public int Number { get; set; }


        public ICollection<Doctor> Doctors { get; set; }
        public ICollection<Patient> Patients { get; set; }

    }
}