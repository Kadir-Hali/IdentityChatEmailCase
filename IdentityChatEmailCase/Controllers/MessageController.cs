using IdentityChatEmailCase.Context;
using IdentityChatEmailCase.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityChatEmailCase.Controllers
{
    public class MessageController : Controller
    {
        private readonly EmailContext _context;
        private readonly UserManager<AppUser> _userManager;

        public MessageController(EmailContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

  
        public async Task<IActionResult> Inbox(string search)
        {
            ViewBag.Kategori = "Mesajlar";
            ViewBag.AltKategori = "Gelen Kutusu";
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.email = values.Email;
            ViewBag.v1 = values.Name + " " + values.Surname;
            List<Message> messages;
            if(!string.IsNullOrWhiteSpace(search))
            {
                messages = _context.Messages.Where(x => x.ReceiverEmail == values.Email).Where(x => x.Subject.ToLower().Contains(search.ToLower())).ToList();
            }
            else
            {
                messages = _context.Messages.Where(x => x.ReceiverEmail == values.Email).ToList();
            }
            messages = messages.OrderByDescending(x => x.SendDate).ToList();    
            return View(messages);
        }

        public async Task<IActionResult> SendBox(string search)
        {
            ViewBag.Kategori = "Mesajlar";
            ViewBag.AltKategori = "Giden Kutusu";
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            string emailValue = values.Email;
            var sendMessageList = _context.Messages.Where(x => x.SenderMail == emailValue).ToList();
            return View(sendMessageList);
        }

        [HttpGet]
        public IActionResult CreateMessage()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateMessage(Message message)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            string senderEmail = values.Email;

            message.SenderMail = senderEmail;
            message.IsRead = false;
            message.SendDate = DateTime.Now;
            _context.Messages.Add(message);
            _context.SaveChanges();
            return RedirectToAction("SendBox");
        }
    }
}

