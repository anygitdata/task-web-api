using System.Collections.Generic;
using TaskWebApi.Models;

namespace TaskWebApi.Migrations
{
    public class SeedLs_Specializations
    {

        public static List<Specialization> GetLs()
        {
            var lsSpecializations = new List<Specialization> {
                new Specialization{ SpecializationId=1, Title="Участковый" },                
                new Specialization{ SpecializationId=2, Title="Терапевт"},

                new Specialization{ SpecializationId=3, Title="Неврапатолог" },
                new Specialization{ SpecializationId=4, Title="Хирург"},
                new Specialization{ SpecializationId=5, Title="Окулист"}
            };

            return lsSpecializations;
        }

    }
}