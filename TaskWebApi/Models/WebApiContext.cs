using System.Data.Entity;


namespace TaskWebApi.Models
{
    public class WebApiContext: DbContext
    {
        public WebApiContext(): base("TaskWebConnection")
        {

        }

        public DbSet<Sector> Sectors { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<Cabinet> Cabinets { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }

    }
}