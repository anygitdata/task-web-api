using System.Collections.Generic;
using TaskWebApi.Models;

namespace TaskWebApi.Interface
{
    public interface IDoctors
    {
        Doctor Add(Doctor item);
        Doctor Update(Doctor item);
        void Delete(int id);


        Doctor Get(int id);
        IEnumerable<Ls_Doctors> GetList(int poage, string sort);
    }
}
