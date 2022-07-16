using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskWebApi.Models;

namespace TaskWebApi.Migrations
{
    public class SeedLs_Patients
    {
        public static List<Patient> GetLs()
        {
            var ls = new List<Patient>
            {
                // sectorId = 1
                new Patient {PatientId = 1, Family="Грачева", FirstName="Маргарита", LastName="Васильевна", 
                        Pol=false, SectorId=1, DateBirth= new DateTime(1950, 2, 10), Address="2 Линия д.12"},

                new Patient {PatientId = 2, Family="Ильин", FirstName="Владислав", LastName="Васильевич",
                        Pol=true, SectorId=1, DateBirth= new DateTime(1945, 6, 22), Address="2 Линия д.17"},

                new Patient {PatientId = 3, Family="Беляева", FirstName="Анна", LastName="Николаевна",
                        Pol=false, SectorId=1, DateBirth= new DateTime(1949, 5, 20), Address="1 Переулок д.15 кв.32" },


                // sectorId = 2
                new Patient {PatientId = 4, Family="Дубинина", FirstName="Лариса", LastName="Ивановка",
                        Pol=false, SectorId=2, DateBirth= new DateTime(1953, 3, 15), Address="Безымянная д.37" },


                // sectorId = 3
                new Patient {PatientId = 5, Family="Бочарова", FirstName="Клавдия", LastName="Петровна",
                        Pol=false, SectorId=3, DateBirth= new DateTime(1958, 12, 22), Address="Маршала Жукова д.50 кв.1" },


                new Patient {PatientId = 6, Family="Гусев", FirstName="Иван", LastName="Александрович",
                        Pol=true, SectorId=3, DateBirth= new DateTime(1950, 2, 10), Address="2 Линия д.12"}


            };


            return ls;
        }
    }
}