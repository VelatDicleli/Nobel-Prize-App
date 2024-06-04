using Business.Abstract;
using Entities;
using Entities.Parameters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NobelPrize.Models;

namespace NobelPrize.Controllers
{
    public class HomeController : Controller
    {
       
        readonly IServiceManager _service;

        public HomeController(IServiceManager service)
        {
            _service = service;
            
        }

        public async Task<IActionResult> Index(CandidateWithAwardParameter parameter)
        {
            var models = await _service.candidateService.GetAllCandidatesAsync(parameter);
            return View(models);
        }

        public async Task<IActionResult> GetAllCandidatesWithAward(CandidateWithAwardParameter? p)
        {
            var result = await _service.candidateService.GetAllCandidatesWithAwardAsync(p);
            return View(result);
        }

        
       
        [HttpGet]
        public async Task<IActionResult> CreateCandidate(CreateCandidateViewModel createCandidateViewModel)
        {
            var committees = await _service.committeeService.GetAllCommitties();
            ViewBag.Committees = new SelectList(committees, "CommitteeId", "CommitteeCategory");

            var organizations = await _service.organizationService.GetAllOrganizations();
            ViewBag.Organizations = new SelectList(organizations, "OrganizationId", "Name");

            var awards = await _service.awardService.GetAllAwards();
            ViewBag.Awards = new SelectList(awards, "AwardId", "DescriptorName");
            

            return View(createCandidateViewModel);
        }



        [HttpPost]
        public async Task<IActionResult> CreateCandidate(Candidate candidate,CreateCandidateRequest createCandidateRequest)
        {   
            await _service.candidateService.CreateCandidate(candidate,createCandidateRequest);
            return RedirectToAction("GetAllCandidatesWithAward");
        }

        public async Task<IActionResult> GetCandidateDetails(int id)
        {
            var model = await _service.candidateService.GetCandidateByIdForRemoving(id);
            return View(model);
        }

        public async Task<IActionResult> RemoveCandidate(int id)
        {
            var candidate = await _service.candidateService.GetCandidateByIdForRemoving(id);
            await _service.candidateService.Delete(candidate);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCandidate(int id)
        {
            var committees = await _service.committeeService.GetAllCommitties();
            ViewBag.Committees = new SelectList(committees, "CommitteeId", "CommitteeCategory");

            var organizations = await _service.organizationService.GetAllOrganizations();
            ViewBag.Organizations = new SelectList(organizations, "OrganizationId", "Name");

            var awards = await _service.awardService.GetAllAwards();
            ViewBag.Awards = new SelectList(awards, "AwardId", "DescriptorName");
            
            var oldCandidate = await _service.candidateService.GetCandidate(id);
           
            return View(oldCandidate);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCandidate(Candidate candidate, UpdateCandidateParameters updateCandidateParameters)
        {
            await _service.candidateService.UpdateCandidate(candidate, updateCandidateParameters);
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        
    }
}
