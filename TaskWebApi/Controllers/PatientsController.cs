using System.Collections.Generic;
using System.Web.Http;
using TaskWebApi.Interface;
using TaskWebApi.Models;

namespace TaskWebApi.Controllers
{
    public class PatientsController : ApiController
    {

        IPatients servPatients = new Patients();


        public IEnumerable<Ls_Patients> GetList(int page = 1, string sort = "PatientId")
        {
            return servPatients.GetList(page, sort);
        }


        public IHttpActionResult Get(int id)
        {
            var res = servPatients.Get(id);
            if (!res.Result)
                return BadRequest(res.Message);

            return Ok(res.ObjResult as Patient);
        }


        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var res = servPatients.Delete(id);
            if (!res.Result)
                return BadRequest(res.Message);

            return Ok();

        }


        [HttpPost]
        public IHttpActionResult Add(Patient item)
        {
            var res = servPatients.Add(item);
            if (!res.Result)
                return BadRequest(res.Message);

            return Ok(res.ObjResult as Patient);
        }


        [HttpPut]
        public IHttpActionResult Update(Patient item)
        {
            var res = servPatients.Update(item);

            if (!res.Result)
                return BadRequest(res.Message);

            return Ok(res.ObjResult as Patient);
        }

    }
}
