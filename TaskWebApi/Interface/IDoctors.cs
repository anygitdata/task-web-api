using System.Collections.Generic;
using TaskWebApi.Models;

namespace TaskWebApi.Interface
{
    public interface IDoctors
    {
        ResProc Add(Doctor item);
        ResProc Update(Doctor item);
        ResProc Delete(int id);


        ResProc Get(int id);
        IEnumerable<Ls_Doctors> GetList(int poage, string sort);
    }
}
