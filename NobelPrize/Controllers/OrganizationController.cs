using Business.Abstract;
using Entities;
using Microsoft.AspNetCore.Mvc;
using NobelPrize.Models;
using System.Net.WebSockets;

namespace NobelPrize.Controllers
{
    public class OrganizationController : Controller
    {
        readonly IServiceManager _service;

        public OrganizationController(IServiceManager service)
        {
            _service = service;
        }

        public async Task<IActionResult> GetAll()
        {
            var models =await _service.organizationService.GetAllOrganizations();
            return View(models);
        }
        public async Task<IActionResult> GetById(int id)
        {
            var models = await _service.organizationService.GetOrganizationById(id);
            return View(models);

        }
        public async Task<IActionResult> Create(OrganizationViewModel organization)
        {
            return View(organization);  
        }

        [HttpPost]
        public async Task<IActionResult> Create(Organization organization)
        {
            await _service.organizationService.CreateOrganization(organization);
            return RedirectToAction("GetAll");
        }

        public async Task<IActionResult> Update(int id)
        {
            var model = await _service.organizationService.GetOrganizationById(id);
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Update(Organization organization)
        {
            await _service.organizationService.UpdateOrganization(organization);
            return RedirectToAction("GetAll");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var model = await _service.organizationService.GetOrganizationById(id);
            await _service.organizationService.DeleteOrganization(model);
            return RedirectToAction("GetAll");
        }

        


    }
}
