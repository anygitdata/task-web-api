using System.Collections.Generic;
using System.Web.Http;
using TaskWebApi.Interface;
using TaskWebApi.Models;

namespace TaskWebApi.Controllers
{
    public class PatientsController : ApiController
    {

        IPatients servPatients = new Patients();


        public IEnumerable<Ls_Patients> GetList(int page=1, string sort= "PatientId")
        {
            return servPatients.GetList(page, sort);
        }


        public Patient Get(int id)
        {
            return servPatients.Get(id);
        }


        [HttpPost]
        public Patient Add(Patient item)
        {
            return servPatients.Add(item);
        }


        [HttpDelete]
        public void Delete(int id)
        {
            servPatients.Delete(id);
        }


        [HttpPut]
        public Patient Update(Patient item)
        {
            return servPatients.Update(item);
        }

    }
}
