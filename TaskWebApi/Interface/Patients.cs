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


        public ResProc Add(Patient item)
        {
            var res = new ResProc();

            if (string.IsNullOrEmpty(item.Sername)
                    || string.IsNullOrEmpty(item.FirstName)
                    || string.IsNullOrEmpty(item.LastName))
            {
                res.Message = "Empty FIO";
                return res;
            }

            if (item.DateBirth == default)
            {
                res.Message = "Empty DateBirth";
                return res;
            }

            if (string.IsNullOrEmpty(item.Address))
            {
                res.Message = "Empty Address";
                return res;
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

                res.Result = true;
                res.ObjResult = item;
            }
            catch
            {
                res.Message = "Error save";
            }


            return res;
        }

        public ResProc Delete(int id)
        {
            var res = new ResProc();

            var patient = Context.Patients.Find(id);

            if (patient is null)
            {
                res.Message = "No data";
                return res;
            }

            try
            {
                Context.Patients.Remove(patient);
                Context.SaveChanges();

                res.Result = true;
            }
            catch
            {
                res.Message = "Error delete";
            }

            return res;
        }

        public ResProc Get(int id)
        {
            var res = new ResProc();

            var patient = Context.Patients.Find(id);

            if (patient is null)
            {
                res.Message = "No data";
                return res;
            }

            res.ObjResult = patient;
            res.Result = true;

            return res;
        }

        public IEnumerable<Ls_Patients> GetList(int page, string sort)
        {
            int numPage = 3;

            if (page > CountPages.GetCount_Pages(Context, numPage, ETypeModel.patn) || page < 0)
                return new List<Ls_Patients>();


            string strSorted = "DateBirth Address Sername".ToUpper();  // идентификаторы сортировки

            if (!string.IsNullOrEmpty(sort))
                sort = sort.ToUpper();

            var lsRes = (from pcn in Context.Patients.OrderBy(p => p.PatientId).Skip((page - 1) * numPage).Take(numPage)
                         join sct in Context.Sectors on pcn.SectorId equals sct.SectorId
                         select new Ls_Patients
                         {
                             PatientId = pcn.PatientId,
                             DateBirth = pcn.DateBirth,
                             Address = pcn.Address,
                             Family = pcn.Sername,
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

                    case "SERNAME":
                        lsRes = lsRes.OrderBy(p => p.Family).ToList();
                        break;

                    case "ADDRESS":
                        lsRes = lsRes.OrderBy(p => p.Address).ToList();
                        break;
                }
            }


            return lsRes;
        }

        private ResProc IsUpdate(Patient patientDB, Patient item)
        {
            var resProc = new ResProc { ChangedData = false };

            int res = 0;


            if (string.IsNullOrEmpty(item.Sername) ||
                string.IsNullOrEmpty(item.FirstName) ||
                string.IsNullOrEmpty(item.LastName))
            {
                resProc.Message = "Empty FIO";
                return resProc;
            }

            if (string.IsNullOrEmpty(item.Address))
            {
                resProc.Message = "Empty Address";
                return resProc;
            }


            if (item.DateBirth == default)
            {
                resProc.Message = "No DateBirth";
                return resProc;
            }

            if (patientDB.Sername != item.Sername)
            {
                patientDB.Sername = item.Sername;
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


            if (patientDB.SectorId != item.SectorId)
            {
                patientDB.SectorId = item.SectorId;
                res++;
            }

            if (res > 0)
            {
                resProc.ChangedData = true;
            }


            resProc.Result = true;

            return resProc;
        }

        public ResProc Update(Patient item)
        {
            var res = new ResProc();

            var patient = Context.Patients.Find(item.PatientId);

            var resVerf = IsUpdate(patient, item);

            if (!resVerf.Result)
            {
                res.Message = resVerf.Message;
                return res;
            }

            try
            {
                switch (resVerf.ChangedData)
                {
                    case true:
                        Context.SaveChanges();
                        res.ObjResult = patient;

                        break;
                    case false:
                        res.ObjResult = item;
                        break;
                }

                res.Result = true;

            }
            catch
            {
                res.Message = "Error modify data";
            }


            return res;

        }


    }
}