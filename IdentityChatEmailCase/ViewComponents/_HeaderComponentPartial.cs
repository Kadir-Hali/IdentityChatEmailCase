using Microsoft.AspNetCore.Mvc;

namespace IdentityChatEmailCase.ViewComponents
{
    public class _HeaderComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
