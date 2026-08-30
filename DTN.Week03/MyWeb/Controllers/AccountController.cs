using Microsoft.AspNetCore.Mvc;
using MyWeb.Models;

namespace MyWeb.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            List<Account> accounts = new List<Account>
            {
                new Account()
                {
                    Id = 1,Name = "Thành Nam",
                    Email = "nam@gmail.com",
                    Phone = "0987654321",
                    Address = "Hà Nội",
                    Avatar = Url.Content("~/images/Avatar/02.jfif"),
                    Gender = 1,
                    Bio = "My name is small",
                    Birthday = new DateTime(2006,12,27)
                },
                new Account()
                {
                    Id = 2,Name = "Bá Vũ",
                    Email = "vu@gmail.com",
                    Phone = "0987654321",
                    Address = "Hà Nội",
                    Avatar = Url.Content("~/images/Avatar/03.jfif"),
                    Gender = 1,
                    Bio = "My name is small",
                    Birthday = new DateTime(2006,12,27)
                },
                new Account()
                {
                    Id = 3,Name = "Phương Khánh",
                    Email = "khanh@gmail.com",
                    Phone = "0987654321",
                    Address = "Hà Nội",
                    Avatar = Url.Content("~/images/Avatar/04.jfif"),
                    Gender = 1,
                    Bio = "My name is small",
                    Birthday = new DateTime(2006,12,27)
                }
            };
            ViewBag.Accounts = accounts;
            return View();
        }

        [Route("ho-so-cua-toi",Name = "profile")]
        public IActionResult Profile(int id)
        {
            List<Account> accounts = new List<Account>
            {
                new Account()
                {
                    Id = 1,Name = "Thành Nam",
                    Email = "nam@gmail.com",
                    Phone = "0987654321",
                    Address = "Hà Nội",
                    Avatar = Url.Content("~/images/Avatar/02.jfif"),
                    Gender = 1,
                    Bio = "My name is small",
                    Birthday = new DateTime(2006,12,27)
                },
                new Account()
                {
                    Id = 2,Name = "Bá Vũ",
                    Email = "vu@gmail.com",
                    Phone = "0987654321",
                    Address = "Hà Nội",
                    Avatar = Url.Content("~/images/Avatar/03.jfif"),
                    Gender = 1,
                    Bio = "My name is small",
                    Birthday = new DateTime(2006,12,27)
                },
                new Account()
                {
                    Id = 3,Name = "Phương Khánh",
                    Email = "khanh@gmail.com",
                    Phone = "0987654321",
                    Address = "Hà Nội",
                    Avatar = Url.Content("~/images/Avatar/04.jfif"),
                    Gender = 1,
                    Bio = "My name is small",
                    Birthday = new DateTime(2006,12,27)
                }
            };
            Account account = accounts.FirstOrDefault(ac => ac.Id == id);
            ViewBag.account = account;
            return View();
        }
    }
}
