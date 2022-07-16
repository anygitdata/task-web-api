using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskWebApi.Models;

namespace TaskWebApi.Migrations
{
    public class SeedLs_Sectors
    {
        public static List<Sector> GetLs()
        {
            List<Sector> ls = new List<Sector> { 
                new Sector{SectorId=1, Number=1},
                new Sector{SectorId=2, Number=2},
                new Sector{SectorId=3, Number=3}
            };

            return ls;
        }

    }
}