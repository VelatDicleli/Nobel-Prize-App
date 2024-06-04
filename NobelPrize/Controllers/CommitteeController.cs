using Business.Abstract;
using Entities;
using Microsoft.AspNetCore.Mvc;
using NobelPrize.Models;

namespace NobelPrize.Controllers
{
    public class CommitteeController : Controller
    {
        readonly IServiceManager _service;

        public CommitteeController(IServiceManager service)
        {
            _service = service;
        }

        public async Task<IActionResult> GetAll()
        {
            var models = await _service.committeeService.GetAllCommitties();
            return View(models);
        }

        public async Task<IActionResult> Create(CommitteeViewModel committeeViewModel)
        {
            return View(committeeViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Committee committee)
        {   
            await _service.committeeService.CreateCommittee(committee);
            return RedirectToAction("GetAll");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var model = await _service.committeeService.GetCommitteeById(id);
            return View(model);
        }

        [HttpPost]
        
        public async Task<IActionResult> Edit(Committee committee)
        {
            await _service.committeeService.UpdateCommittee(committee);
            return RedirectToAction("GetAll");
        }

        public async Task<IActionResult> Remove(int id)
        {
            var model = await _service.committeeService.GetCommitteeById(id);
            await _service.committeeService.DeleteCommitteeById(model);
            return RedirectToAction("GetAll");
        }

        public async Task<IActionResult> Details(int id)
        {
            var model = await _service.committeeService.GetCommitteeById(id);
            return View(model);
        }
    }
}
