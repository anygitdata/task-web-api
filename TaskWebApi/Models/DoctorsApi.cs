using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskWebApi.Models
{
    public class DoctorsApi
    {

        public static List<string> GetData(int doctorId)
        {
            var res = new List<string>();

            var context = new WebApiContext();

            var doctror = context.Doctors.Find(doctorId);

            var sector = context.Sectors.Find(doctror.SectorId)?.Number.ToString() ?? "Нет";
            var cabinet = context.Cabinets.Find(doctror.CabinetId).Number;
            var specialization = context.Specializations.Find(doctror.SpecializationId).Title;

            res.Add($"Участок: {sector}");
            res.Add($"Кабинет: {cabinet}");
            res.Add($"Специализация: {specialization}");

            return res;
        }

    }
}