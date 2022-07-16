namespace TaskWebApi.Models
{
    public class Ls_Doctors
    {
        public int DoctorId { get; set; }
        public string FullName { get; set; }
                

        public int Cabinet { get; set; }
        public string Specialization { get; set; }
        public int Sector { get; set; }
    }
}