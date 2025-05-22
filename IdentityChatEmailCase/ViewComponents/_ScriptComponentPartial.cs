using Microsoft.AspNetCore.Mvc;

namespace IdentityChatEmailCase.ViewComponents
{
    public class _ScriptComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
