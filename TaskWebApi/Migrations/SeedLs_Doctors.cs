using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskWebApi.Models;

namespace TaskWebApi.Migrations
{
    public class SeedLs_Doctors
    {
        public static List<Doctor> GetLs()
        {
            var ls = new List<Doctor>
            {
                new Doctor {DoctorId=1, FullName="Красикова Н.Н", CabinetId=1, SectorId=1, SpecializationId=1 }, // Участковый
                new Doctor {DoctorId=2, FullName="Климова В.Н",   CabinetId=1, SectorId=2, SpecializationId=1 },
                new Doctor {DoctorId=3, FullName="Ивашова В.И",   CabinetId=1, SectorId=3, SpecializationId=1 },

                new Doctor {DoctorId=4, FullName="Жданова Н.Н",   CabinetId=2, SpecializationId=2 }, // Терапевт
                new Doctor {DoctorId=5, FullName="Иванова В.Н",   CabinetId=3, SpecializationId=2 },
                new Doctor {DoctorId=6, FullName="Алешина В.И",   CabinetId=4, SpecializationId=2 },

                new Doctor {DoctorId=7, FullName="Гаврилова К.И", CabinetId=5, SpecializationId=3 }, // Неврапатолог
                new Doctor {DoctorId=8, FullName="Егоров И.Н",    CabinetId=6, SpecializationId=4 }, // Хирург
                new Doctor {DoctorId=9, FullName="Волкова К.Н",   CabinetId=7, SpecializationId=5 }  // Окулист

            };

            return ls;
        }
    }
}