using System.Collections.Generic;
using TaskWebApi.Models;

namespace TaskWebApi.Interface
{
    public interface IPatients
    {
        Patient Add(Patient item);
        Patient Update(Patient item);
        void Delete(int id);


        Patient Get(int id);
        IEnumerable<Ls_Patients> GetList(int page, string sort);
    }
}
