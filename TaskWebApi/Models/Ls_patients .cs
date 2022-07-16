using System;

namespace TaskWebApi.Models
{
    public class Ls_Patients
    {
        public int PatientId { get; set; }
        public string Family { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime DateBirth { get; set; }
        public string Pol { get; set; }
                
        public int Sector { get; set; }
    }
}