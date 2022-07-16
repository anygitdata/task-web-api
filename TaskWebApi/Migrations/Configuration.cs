namespace TaskWebApi.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using TaskWebApi.Models;
    using System.Linq;
    using TaskWebApi.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<TaskWebApi.Models.WebApiContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebApiContext context)
        {
            foreach (var item in SeedLs_Cabinets.GetLs())
                context.Cabinets.AddOrUpdate(x => x.CabinetId, item);

            foreach (var item in SeedLs_Sectors.GetLs())
                context.Sectors.AddOrUpdate(x => x.SectorId, item);

            foreach (var item in SeedLs_Specializations.GetLs())
                context.Specializations.AddOrUpdate(x => x.SpecializationId, item);

            foreach (var item in SeedLs_Doctors.GetLs())
                context.Doctors.AddOrUpdate(x => x.DoctorId, item);

            foreach (var item in SeedLs_Patients.GetLs())
                context.Patients.AddOrUpdate(x => x.PatientId, item);

            context.SaveChanges();
        }
    }
}
