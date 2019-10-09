using System;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sparta.Web.API.Services.Abstract;
using Sparta.Web.API.ViewModel;
using Sparta.Web.Data.Abstract;
using Sparta.Web.Data.Repositories;
using Sparta.Web.Model;

namespace Sparta.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class WorkShiftController : ControllerBase
    {
        private readonly WorkShiftRepository _workShiftRepository;

        public WorkShiftController(WorkShiftRepository workShiftRepository)
        {
            _workShiftRepository = workShiftRepository;
        }

        [HttpGet]
        public ActionResult<WorkShiftViewModal[]> GetWorkShifts()
        {
            var workShifts = _workShiftRepository.GetAll();
            return workShifts.Select(w=> WorkShiftViewModal.Factory(w.Id,w.Name,w.BeginTime,w.EndTime,w.WorkDaysPeriod,w.Role)).ToArray();
        }
        [Authorize(Roles = "admin")]
        [HttpGet("remove/{id}")]
        public ActionResult<WorkShiftViewModal> RemoveWorkShift(string id)
        {
            var workShift = _workShiftRepository.GetSingle(id);
            _workShiftRepository.Delete(workShift);
            _workShiftRepository.Commit();
            return WorkShiftViewModal.Factory(workShift.Id, workShift.Name, workShift.BeginTime, workShift.EndTime, workShift.WorkDaysPeriod, workShift.Role);
        }

        [Authorize(Roles = "admin")]
        [HttpPost("update")]
        public ActionResult<WorkShiftViewModal> UpdateWorkShift(WorkShiftViewModal model)
        {
            var workShift = _workShiftRepository.GetSingle(model.Id);
            workShift.Name = model.Name;
            workShift.Role = model.Role;
            workShift.BeginTime = model.BeginTime;
            workShift.EndTime = model.EndTime;
            workShift.WorkDaysPeriod = model.WorkDaysPeriod;

            _workShiftRepository.Update(workShift);
            _workShiftRepository.Commit();

            return WorkShiftViewModal.Factory(workShift.Id, workShift.Name, workShift.BeginTime, workShift.EndTime, workShift.WorkDaysPeriod, workShift.Role);
        }

        [Authorize(Roles = "admin")]
        [HttpPost("add")]
        public ActionResult<WorkShiftViewModal> AddWorkShift(WorkShiftViewModal model)
        {
            var id = Guid.NewGuid().ToString();
            var workShift = new WorkShift
            {
                Id = id,
                Name = model.Name,
                BeginTime = model.BeginTime,
                EndTime = model.EndTime,
                WorkDaysPeriod = model.WorkDaysPeriod,
                Role = model.Role
            };
            _workShiftRepository.Add(workShift);
            _workShiftRepository.Commit();
            return WorkShiftViewModal.Factory(workShift.Id, workShift.Name, workShift.BeginTime, workShift.EndTime, workShift.WorkDaysPeriod, workShift.Role);
        }

    }
}
