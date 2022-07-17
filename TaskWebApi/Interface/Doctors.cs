using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using TaskWebApi.Models;

namespace TaskWebApi.Interface
{
    public class Doctors : IDoctors
    {

        WebApiContext Context { get; }

        public Doctors() => Context = new WebApiContext();


        public Doctor Add(Doctor item)
        {
            if (string.IsNullOrEmpty(item.FullName))
            {
                var respMess = ResProc.Create_ResponseMessage("empty FIO",
                            "empty FIO", System.Net.HttpStatusCode.InternalServerError);

                throw new HttpResponseException(respMess);
            }


            int maxId = 0;

            if (Context.Doctors.Any())
                maxId = Context.Doctors.Max(p => p.DoctorId);

            maxId++;


            item.DoctorId = maxId;

            try
            {
                Context.Doctors.Add(item);
                Context.SaveChanges();
            }
            catch
            {
                var response = ResProc.Create_ResponseMessage("Error save data",
                           "error save data", System.Net.HttpStatusCode.InternalServerError);

                throw new HttpResponseException(response);
            }


            return item;

        }

        public void Delete(int id)
        {
            var doctor = Context.Doctors.Find(id);

            if (doctor is null)
            {
                var errMes = ResProc.Create_ResponseMessage($"No data for doctorId:{doctor.DoctorId}",
                            "No data", System.Net.HttpStatusCode.InternalServerError);

                throw new HttpResponseException(errMes);
            }

            try
            {
                Context.Doctors.Remove(doctor);
                Context.SaveChanges();

            }
            catch
            {
                var errMes = ResProc.Create_ResponseMessage($"Error delete",
                            "Error delete", System.Net.HttpStatusCode.InternalServerError);

                throw new HttpResponseException(errMes);
            }
        
        }

        public Doctor Get(int id)
        {

            var doctor = Context.Doctors.Find(id);

            if (doctor is null)
            {
                var errMes = ResProc.Create_ResponseMessage($"No data for doctorId:{doctor.DoctorId}",
                            "No data", System.Net.HttpStatusCode.InternalServerError);

                throw new HttpResponseException(errMes);
            }

            return doctor;
        }

        public IEnumerable<Ls_Doctors> GetList(int page, string sort)
        {
            /*
             * Только участковые врачи имеют участки, поэтому используется
             * сценарий LEFT JOIN
             */

            int numPage = 3;

            if (page > CountPages.GetCount_Pages(Context, numPage, ETypeModel.doct) || page < 0)
                return new List<Ls_Doctors>();


            if (!string.IsNullOrEmpty(sort))
                sort = sort.ToUpper();

            string strSorted = "FullName Cabinet Sector".ToUpper();   // идентификаторы сортировки

            var lsRes = (from doct in Context.Doctors.OrderBy(p=> p.DoctorId).Skip((page-1)*numPage).Take(numPage)
                         join cab in Context.Cabinets on doct.CabinetId equals cab.CabinetId
                         from sec in Context.Sectors.Where(p=> p.SectorId == doct.SectorId).DefaultIfEmpty()
                         select new Ls_Doctors
                         {
                             DoctorId = doct.DoctorId,
                             FullName = doct.FullName,
                             Cabinet = cab.Number,
                             Sector = sec != null ? sec.Number : 0
                         }).ToList();


            if (!string.IsNullOrEmpty(sort) && strSorted.IndexOf(sort) > -1)
            {
                switch (sort)
                {
                    case "FULLNAME":
                        lsRes = lsRes.OrderBy(p => p.FullName).ToList();
                        break;

                    case "CABINET":
                        lsRes = lsRes.OrderBy(p => p.Cabinet).ToList();
                        break;

                    case "SECTOR":
                        lsRes = lsRes.OrderBy(p => p.Sector).ToList();
                        break;
                }
            }
            

            return lsRes; 

        }

        private int IsUpdate(Doctor doctorDB, Doctor item)
        {
            int res = 0;


            if (doctorDB.FullName != item.FullName)
            {
                doctorDB.FullName = item.FullName;
                res++;
            }


            if (doctorDB.CabinetId != item.CabinetId)
            {
                doctorDB.CabinetId = item.CabinetId;
                res++;
            }

            if (doctorDB.SectorId != item.SectorId)
            {
                doctorDB.SectorId = item.SectorId;
                res++;
            }

            if (doctorDB.SpecializationId != item.SpecializationId)
            {
                doctorDB.SpecializationId = item.SpecializationId;
                res++;
            }



            return res;
        }

        public Doctor Update(Doctor item)
        {
            var doctor = Context.Doctors.Find(item.DoctorId);

            if (IsUpdate(doctor, item) == 0)
                return item;

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                var response = ResProc.Create_ResponseMessage("Error modify data",
                          "Error modify data", System.Net.HttpStatusCode.InternalServerError);

                throw new HttpResponseException(response);
            }


            return doctor;

        }
        
    }
}