using Microsoft.AspNetCore.Mvc;

namespace IdentityChatEmailCase.ViewComponents
{
    public class _NavbarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }

}
