using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskWebApi.Models;

namespace TaskWebApi.Migrations
{
    public class SeedLs_Cabinets
    {
        public static List<Cabinet> GetLs()
        {
            var ls = new List<Cabinet>
            {
                new Cabinet{CabinetId=1, Number=1 }, // Участковый

                new Cabinet{CabinetId=2, Number=2 }, // Терапевт
                new Cabinet{CabinetId=3, Number=3 }, // Терапевт
                new Cabinet{CabinetId=4, Number=4 }, // Терапевт
                
                new Cabinet{CabinetId=5, Number=5 }, // Неврапатолог
                new Cabinet{CabinetId=6, Number=6 }, // Хирург
                new Cabinet{CabinetId=7, Number=7 }, // Окулист
            };

            return ls;
        }
    }
}