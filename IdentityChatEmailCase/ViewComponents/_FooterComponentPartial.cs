using Microsoft.AspNetCore.Mvc;

namespace IdentityChatEmailCase.ViewComponents
{
    public class _FooterComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
