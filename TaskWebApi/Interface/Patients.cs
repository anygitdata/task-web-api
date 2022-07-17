using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using TaskWebApi.Models;

namespace TaskWebApi.Interface
{
    public class Patients : IPatients
    {

        WebApiContext Context { get; }

        public Patients() => Context = new WebApiContext();
        

        public Patient Add(Patient item)
        {
            if (string.IsNullOrEmpty(item.Family) 
                    || string.IsNullOrEmpty(item.FirstName)
                    || string.IsNullOrEmpty(item.LastName)   )
            {
                var respMess = ResProc.Create_ResponseMessage("Empty FIO",
                            "Empty FIO", System.Net.HttpStatusCode.InternalServerError);

                throw new HttpResponseException(respMess);
            }


            int maxId = 0;

            if (Context.Patients.Any())
                maxId = Context.Patients.Max(p => p.PatientId);

            maxId++;


            item.PatientId = maxId;

            try
            {
                Context.Patients.Add(item);
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
            var patient = Context.Patients.Find(id);

            if (patient is null)
            {
                var errMes = ResProc.Create_ResponseMessage($"No data for doctorId:{patient.PatientId}",
                            "No data", System.Net.HttpStatusCode.InternalServerError);

                throw new HttpResponseException(errMes);
            }

            try
            {
                Context.Patients.Remove(patient);
                Context.SaveChanges();
            }
            catch
            {
                var errMes = ResProc.Create_ResponseMessage($"Error delete",
                           "Error delete", System.Net.HttpStatusCode.InternalServerError);

                throw new HttpResponseException(errMes);
            }

        }

        public Patient Get(int id)
        {

            var patient = Context.Patients.Find(id);

            if (patient is null)
            {
                var errMes = ResProc.Create_ResponseMessage($"No data for patientId:{patient.PatientId}",
                            "No data", System.Net.HttpStatusCode.InternalServerError);

                throw new HttpResponseException(errMes);
            }

            return patient;
        }

        public IEnumerable<Ls_Patients> GetList(int page, string sort)
        {
            int numPage = 3;

            if (page > CountPages.GetCount_Pages(Context, numPage, ETypeModel.patn) || page < 0)
                return new List<Ls_Patients>();


            string strSorted = "DateBirth Address Family".ToUpper();  // идентификаторы сортировки

            if (!string.IsNullOrEmpty(sort))
                sort = sort.ToUpper();

            var lsRes = (from pcn in Context.Patients.OrderBy(p => p.PatientId).Skip((page - 1) * numPage).Take(numPage)
                         join sct in Context.Sectors on pcn.SectorId equals sct.SectorId
                         select new Ls_Patients
                         {
                             PatientId = pcn.PatientId,
                             DateBirth = pcn.DateBirth,
                             Address = pcn.Address,
                             Family = pcn.Family,
                             FirstName = pcn.FirstName,
                             LastName = pcn.LastName,
                             Pol = pcn.Pol ? "М" : "Ж",
                             Sector = sct.Number
                         }).ToList();


            if (!string.IsNullOrEmpty(sort) && strSorted.IndexOf(sort) > -1)
            {
                switch (sort)
                {
                    case "DATEBIRTH":
                        lsRes = lsRes.OrderBy(p => p.DateBirth).ToList();
                        break;

                    case "FAMILY":
                        lsRes = lsRes.OrderBy(p => p.Family).ToList();
                        break;

                    case "ADDRESS":
                        lsRes = lsRes.OrderBy(p => p.Address).ToList();
                        break;
                }
            }


            return lsRes;
        }

        private int IsUpdate(Patient patientDB, Patient item)
        {
            int res = 0;


            if (patientDB.Family != item.Family)
            {
                patientDB.Family = item.Family;
                res++;
            }

            if (patientDB.FirstName != item.FirstName)
            {
                patientDB.FirstName = item.FirstName;
                res++;
            }


            if (patientDB.LastName != item.LastName)
            {
                patientDB.LastName = item.LastName;
                res++;
            }


            if (patientDB.DateBirth != item.DateBirth)
            {
                patientDB.DateBirth = item.DateBirth;
                res++;
            }


            if (patientDB.SectorId != item.SectorId)
            {
                patientDB.SectorId = item.SectorId;
                res++;
            }


            if (patientDB.Address != item.Address)
            {
                patientDB.Address = item.Address;
                res++;
            }

            if (patientDB.Pol != item.Pol)
            {
                patientDB.Pol = item.Pol;
                res++;
            }


            return res;
        }

        public Patient Update(Patient item)
        {
            var patient = Context.Patients.Find(item.PatientId);

            if (IsUpdate(patient, item) == 0)
                return item;

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                var response = ResProc.Create_ResponseMessage("Error modify data",
                          "error modify data", System.Net.HttpStatusCode.InternalServerError);

                throw new HttpResponseException(response);
            }


            return patient;

        }


    }
}