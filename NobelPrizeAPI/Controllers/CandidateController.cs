using Business.Abstract;
using Entities.Parameters;
using Microsoft.AspNetCore.Mvc;

namespace NobelPrizeAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CandidateController : Controller
    {
        readonly IServiceManager _service;

        public CandidateController(IServiceManager service)
        {
            _service = service;
        }
        [HttpGet("GetAllCandidatesTable")]
        public async Task<IActionResult> GetAllCandidatesTable([FromQuery]CandidateWithAwardParameter? p)
        {
            var models = await _service.candidateService.GetAllCandidatesWithAwardAsync(p);
            return Ok(models);

        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetCandidateById([FromQuery]int id)
        {
            var model = await _service.candidateService.GetCandidate(id);
            return Ok(model);
        }
    }
}
