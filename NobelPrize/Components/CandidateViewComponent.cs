using Microsoft.AspNetCore.Mvc;

namespace NobelPrize.Components
{
    public class CandidateViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
