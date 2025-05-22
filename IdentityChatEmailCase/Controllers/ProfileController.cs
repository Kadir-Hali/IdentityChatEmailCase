using IdentityChatEmailCase.Context;
using IdentityChatEmailCase.Entities;
using IdentityChatEmailCase.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityChatEmailCase.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly EmailContext _context;  
        private readonly UserManager<AppUser> _userManager;

        public ProfileController(EmailContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> ProfileDetail()
        {
            ViewBag.Kategori = "Profil";
            ViewBag.AltKategori = "Profil Detayları";
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            var user = new UpdateProfileViewModel
            {
                Name = values.Name,
                Surname = values.Surname
            };
            ViewBag.GonderilenMesaj = _context.Messages.Where(x => x.SenderMail == values.Email).Count();
            ViewBag.AlinanMesaj = _context.Messages.Where(x => x.ReceiverEmail == values.Email).Count();
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> ProfileDetail(UpdateProfileViewModel profile)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            user.Name = profile.Name;
            user.Surname = profile.Surname;
            var result = await _userManager.UpdateAsync(user);
            if(result.Succeeded)
            {
                if (profile.Password != null && profile.NewPassword != null)
                {
                    var resultt = await _userManager.ChangePasswordAsync(user, profile.Password, profile.NewPassword);
                    if (resultt.Succeeded)
                    {
                        return RedirectToAction("Logout", "Login");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                    }
                }
                return RedirectToAction("ProfileDetail");
            }
            else
            {
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return RedirectToAction("ProfileDetail");
        }
    }
}
