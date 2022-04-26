using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealAsm.Areas.Identity.Data;
using RealAsm.Models;
using System.Diagnostics;
using System.Linq;

namespace RealAsm.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmailSender _emailSender;
        private readonly UserManager<RealAsmUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;


        public HomeController(ILogger<HomeController> logger, IEmailSender emailSender, UserManager<RealAsmUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _logger = logger;
            _emailSender = emailSender;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public List<IdentityRole> roles { set; get; }
        public System.Security.Claims.ClaimsPrincipal GetUser()
        {
            return User;
        }

        public IActionResult HomeCustomerIndex()
        {
            return View();
        }
        public IActionResult HomeSellerIndex()
        {
            return View();
        }
        public async Task<IActionResult> Testrolelogin()
        {
            /*var roles = await _roleManager.GetRoleNameAsync(role);
            ViewBag.message = "this role is:" + roles;*/
            var userName = await _userManager.GetUserAsync(HttpContext.User);
            /*ViewBag.message = "this user name is:" + userName;*/
            /*var userID = await _userManager.GetUserIdAsync(userName);
            ViewBag.message = userID;*/
            var rolesname = await _userManager.GetRolesAsync(userName);
            
            if (rolesname.Contains("Customer"))
            {
                return View("Views/Home/Index.cshtml");
            }
            /*ViewBag.message = roles;*/ // đang chỉnh sữa
            /*var userRoles = await _userManager.GetRolesAsync(userName);
            ViewBag.message = userRoles;*/
            /*ViewBag.message = "This is for Customer only! Hi " + _userManager.GetUserId(HttpContext.User);*/
            return View();
        }

        [Authorize(Roles = "Customer")]
        public IActionResult ForCustomerOnly()
        {
            ViewBag.message = "This is for Customer only! Hi " + _userManager.GetUserName(HttpContext.User);
            return View("Views/Home/Index.cshtml");
        }

        [Authorize(Roles = "Seller")]
        public IActionResult ForSellerOnly()
        {
            ViewBag.message = "This is for Store Owner only!";
            return View("Views/Home/Index.cshtml");
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Privacy()
        {
            await _emailSender.SendEmailAsync("yeuthanh3466@gmail.com", "test send mail", "just test");
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}