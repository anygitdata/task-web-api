using System.Collections.Generic;
using TaskWebApi.Models;

namespace TaskWebApi.Interface
{
    public interface IPatients
    {
        ResProc Add(Patient item);
        ResProc Update(Patient item);
        ResProc Delete(int id);


        ResProc Get(int id);
        IEnumerable<Ls_Patients> GetList(int page, string sort);
    }
}
