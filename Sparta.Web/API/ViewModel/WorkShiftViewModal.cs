using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Sparta.Web.Model.Enums;

namespace Sparta.Web.API.ViewModel
{
    public class WorkShiftViewModal
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public long BeginTime { get; set; }
        public long EndTime { get; set; }
        public int WorkDaysPeriod { get; set; }
        public string Role { get; set; }

        public static WorkShiftViewModal Factory(string id, string name, long beginTime, long endTime,
            int workDaysPeriod, string role)
        {
            return new WorkShiftViewModal
            {
                Id = id,
                Role = role,
                WorkDaysPeriod = workDaysPeriod,
                BeginTime = beginTime,
                Name = name,
                EndTime = endTime
            };
        }
    }
}
