using Microsoft.AspNetCore.Mvc;

namespace IdentityChatEmailCase.ViewComponents
{
    public class _SidebarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
