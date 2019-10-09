using Sparta.Web.Data.Abstract;
using Sparta.Web.Model;

namespace Sparta.Web.Data.Repositories
{

    public class WorkShiftRepository : EntityBaseRepository<WorkShift>
    {
        public WorkShiftRepository(SpartaContext context) : base(context) { }

    }
}
