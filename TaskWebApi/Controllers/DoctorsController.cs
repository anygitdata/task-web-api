using System.Collections.Generic;
using System.Web.Http;
using TaskWebApi.Interface;
using TaskWebApi.Models;

namespace TaskWebApi.Controllers
{
    public class DoctorsController : ApiController
    {

        IDoctors servDoctors;

        public DoctorsController()
        {
            servDoctors = new Doctors();
        }


        public IEnumerable<Ls_Doctors> GetList(int page = 1, string sort = "DoctorId")
        {
            return servDoctors.GetList(page, sort);
        }

        public Doctor Get(int id)
        {

            return servDoctors.Get(id);
        }


        [HttpPost]
        public Doctor Add(Doctor item)
        {
            return servDoctors.Add(item);
        }


        [HttpDelete]
        public void Delete(int id)
        {
            servDoctors.Delete(id);
        }


        [HttpPut]
        public Doctor Update(Doctor item)
        {
            var res = servDoctors.Update(item);


            return res; 
        }




    }
}
