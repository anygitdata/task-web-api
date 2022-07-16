using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskWebApi.Models;

namespace TaskWebApi.Interface
{
    public class CountPages
    {
        public static int GetCount_Pages(WebApiContext context, int sizePage, ETypeModel typeMode)
        {

            int numRec = 0;
            int numPages = 0;

            if (typeMode == ETypeModel.doct)
                numRec = context.Doctors.Count();
            else
                numRec = context.Patients.Count();


            if (numRec == 0) return 0;

            if (numRec < sizePage) return 1;


            numPages = numRec / sizePage;

            if (numRec % sizePage > 0)
                numRec++;


            return numPages;
        }

    }
}