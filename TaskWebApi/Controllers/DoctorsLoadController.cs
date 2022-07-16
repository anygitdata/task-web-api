using System.Web.Http;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.Migrations;
using TaskWebApi.Migrations;
using TaskWebApi.Models;
using TaskWebApi.Interface;

namespace TaskWebApi.Controllers
{
    public class DoctorsLoadController : ApiController
    {

        // Детализация структуры модели Doctor
        public IEnumerable<string> GetData(int id)
        {
            var list = DoctorsApi.GetData(id);

            return list;
        }


        [HttpPost]
        public int LoadDoctors()
        {
            var context = new WebApiContext();

            foreach (var item in SeedLs_Doctors.GetLs())
                context.Doctors.AddOrUpdate(x => x.DoctorId, item);

            context.SaveChanges();

            var res = context.Doctors.Count();

            return res;
        }

    }
}
