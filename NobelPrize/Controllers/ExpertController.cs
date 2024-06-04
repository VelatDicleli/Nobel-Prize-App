using Business.Abstract;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NobelPrize.Models;

namespace NobelPrize.Controllers
{
    public class ExpertController : Controller
    {
        readonly IServiceManager _serviceManager;

        public ExpertController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public async Task<IActionResult> GetAll()
        {
            var models = await _serviceManager.expertService.GetAllExperts();
            return View(models);
          
        }

        public async Task<IActionResult> Create(ExpertViewModel expert)
        {
            var committees = await _serviceManager.committeeService.GetAllCommitties();
            ViewBag.Committees = new SelectList(committees, "CommitteeId", "CommitteeCategory");

            return View(expert);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Expert expert)
        {
            await _serviceManager.expertService.CreateExpert(expert);
            return RedirectToAction("GetAll");
        }
        public async Task<IActionResult> Edit(int id)
        {
            var model = await _serviceManager.expertService.GetExpertById(id);
            var committees = await _serviceManager.committeeService.GetAllCommitties();
            ViewBag.Committees = new SelectList(committees, "CommitteeId", "CommitteeCategory");

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Expert expert)
        {
            await _serviceManager.expertService.UpdateExpert(expert);
            return RedirectToAction("GetAll");
        }

        public async Task<IActionResult> Remove(int id)
        {
            var model = await _serviceManager.expertService.GetExpertById(id);
            await _serviceManager.expertService.DeletExpert(model);
            return RedirectToAction("GetAll");
        }
    }
}
