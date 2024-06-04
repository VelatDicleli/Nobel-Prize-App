using Business.Abstract;
using Entities;
using Microsoft.AspNetCore.Mvc;
using NobelPrize.Models;

namespace NobelPrize.Controllers
{
    public class AwardController : Controller
    {
        readonly IServiceManager _service;

        public AwardController(IServiceManager service)
        {
            _service = service;
        }
        public async Task<IActionResult> GetAll()
        {
            var models = await _service.awardService.GetAllAwards();
            return View(models);    
        }
        public async Task<IActionResult> Create(AwardViewModel award)
        {
            return View(award);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Award award)
        {   
            await _service.awardService.CreateAward(award);
            return RedirectToAction("GetAll");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var model = await _service.awardService.GetAwardById(id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Award award)
        {   
            await _service.awardService.UpdateAward(award);
            return RedirectToAction("GetAll");
        }

        public async Task<IActionResult> Remove(int id)
        {
            var model = await _service.awardService.GetAwardById(id);
            await _service.awardService.DeleteAward(model);
            return RedirectToAction("GetAll");
        }
    }
}
