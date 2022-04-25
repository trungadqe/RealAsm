﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using RealAsm.Areas.Identity.Data;
using RealAsm.Models;
using System.Diagnostics;

namespace RealAsm.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmailSender _emailSender;
        private readonly UserManager<RealAsmUser> _userManager;
        public HomeController(ILogger<HomeController> logger, IEmailSender emailSender, UserManager<RealAsmUser> userManager)
        {
            _logger = logger;
            _emailSender = emailSender;
            _userManager = userManager;
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