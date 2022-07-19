using Microsoft.AspNet.Identity;
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


        public IHttpActionResult Get(int id)
        {

            var res = servDoctors.Get(id);

            if (!res.Result)
                return BadRequest(res.Message);

            return Ok(res.ObjResult as Doctor);
        }


        [HttpPost]
        public IHttpActionResult Add(Doctor item)
        {
            var res = servDoctors.Add(item);

            if (!res.Result)
                return BadRequest(res.Message);

            return Ok(res.ObjResult as Doctor);
        }


        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var res = servDoctors.Delete(id);

            if (!res.Result)
                return BadRequest(res.Message);

            return Ok();
        }


        [HttpPut]
        public IHttpActionResult Update(Doctor item)
        {
            var res = servDoctors.Update(item);
            if (!res.Result)
            {
                return BadRequest(res.Message);
            }

            return Ok(res.ObjResult as Doctor); 
        }


    }
}
