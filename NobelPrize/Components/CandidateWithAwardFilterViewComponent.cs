using Entities.Parameters;
using Microsoft.AspNetCore.Mvc;

namespace NobelPrize.Components
{
    public class CandidateWithAwardFilterViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {   
            return View();
        }
    }
}
