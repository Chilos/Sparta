using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sparta.Web.Model.Abstract;
using Sparta.Web.Model.Enums;

namespace Sparta.Web.Model
{
    public class WorkShift : IEntityBase
    {
        public  string Id { get; set; }
        public string Name { get; set; }
        public DateTime BeginTime { get; set; }
        public DateTime EndTime { get; set; }
        public WorkDaysPeriod WorkDaysPeriod { get; set; }
        public string Role { get; set; }
    }
}
