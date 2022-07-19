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


        public ResProc Add(Doctor item)
        {
            var resProc = new ResProc();

            if (string.IsNullOrEmpty(item.FullName))
            {
                resProc.Message = "empty FullName";
                return resProc;                
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

                resProc.ObjResult = item;
                resProc.Result = true;
            }
            catch
            {
                resProc.Message = "Error save data";             
            }


            return resProc;

        }

        public ResProc Delete(int id)
        {
            var res = new ResProc();

            var doctor = Context.Doctors.Find(id);

            if (doctor is null)
            {
                res.Message = "No data";
                return res;
            }

            try
            {
                Context.Doctors.Remove(doctor);
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

            var doctor = Context.Doctors.Find(id);

            if (doctor is null)
            {
                res.Message = "No data for doctorId";
                return res; 

            }

            res.ObjResult = doctor;
            res.Result = true;

            return res;
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

            string strSorted = "FullName Cabinet Sector Specialization".ToUpper();   // идентификаторы сортировки

            var lsRes = (from doct in Context.Doctors.OrderBy(p=> p.DoctorId).Skip((page-1)*numPage).Take(numPage)
                         join cab in Context.Cabinets on doct.CabinetId equals cab.CabinetId
                         join spec in Context.Specializations on doct.SpecializationId equals spec.SpecializationId
                         from sec in Context.Sectors.Where(p=> p.SectorId == doct.SectorId).DefaultIfEmpty()
                         select new Ls_Doctors
                         {
                             DoctorId = doct.DoctorId,
                             FullName = doct.FullName,
                             Cabinet = cab.Number,
                             Specialization = spec.Title,
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

                    case "SPECIALIZATION":
                        lsRes = lsRes.OrderBy(p => p.Specialization).ToList();
                        break;
                }
            }
            

            return lsRes; 

        }

        private ResProc IsUpdate(Doctor doctorDB, Doctor item)
        {
            var resProc = new ResProc {ChangedData = false };

            int res = 0;

            if (string.IsNullOrEmpty(item.FullName))
            {
                resProc.Message = "FullName empty";

                return resProc;
            }

            if (doctorDB.FullName != item.FullName)
            {
                doctorDB.FullName = item.FullName;
                res++;
            }

            // Из соображений упрощения
            // js code тестовой страницы заполняет эти поля
            //if (doctorDB.CabinetId != item.CabinetId)
            //{
            //    doctorDB.CabinetId = item.CabinetId;
            //    res++;
            //}

            //if (doctorDB.SectorId != item.SectorId)
            //{
            //    doctorDB.SectorId = item.SectorId;
            //    res++;
            //}

            //if (doctorDB.SpecializationId != item.SpecializationId)
            //{
            //    doctorDB.SpecializationId = item.SpecializationId;
            //    res++;
            //}

            if (res > 0)
                resProc.ChangedData = true;
            
            resProc.Result = true;

            return resProc;
        }

        public ResProc Update(Doctor item)
        {
            var res = new ResProc();

            try
            {
                var doctor = Context.Doctors.Find(item.DoctorId);
                var resVerf = IsUpdate(doctor, item);

                if (!resVerf.Result)
                {
                    res.Message = resVerf.Message;
                    return res; 
                }

                switch (resVerf.ChangedData)
                {
                    case true:
                        Context.SaveChanges();
                        res.ObjResult = doctor;

                        break;
                    case false:
                        res.ObjResult = item;
                        break;
                }

                res.Result = true;

            }
            catch
            {
                res.Message = "Error save";
            }


            return res;

        }
        
    }
}