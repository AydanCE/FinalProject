using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using MVC.ViewModels;

namespace MVC.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;
        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        public IActionResult Index()
        {
            ContactVM vm = new()
            {
                Contacts = _contactService.GetAllContacts().Data,
            };
            return View(vm);
        }
    }
}
