using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskWebApi.Models
{
    public class Cabinet
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CabinetId { get; set; }
        public int Number { get; set; }


        public ICollection<Doctor> Doctors { get; set; }
        
    }
}