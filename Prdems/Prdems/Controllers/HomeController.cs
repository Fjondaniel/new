using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Prdems.Models.Entities;
using Prdems.Models;
using Microsoft.EntityFrameworkCore;
using Prdems.Data;

namespace Prdems.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _dbContext; // Add a private field for your DbContext

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext dbContext) // Inject DbContext
        {
            _logger = logger;
            _dbContext = dbContext; // Assign the injected DbContext
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult Privacy()
        {
            return View();
        }

        [Authorize]
        public IActionResult Event()
        {
            return View();
        }

        //[Authorize]
        //[HttpPost]
        //public async Task<IActionResult> Event(EventViewModel viewModel)
        //{
        //    if (ModelState.IsValid) // Ensure the input is valid
        //    {
        //        var events = new Event
        //        {
        //            EventName = viewModel.EventName,
        //            EventDescription = viewModel.EventDescription,
        //            Location = viewModel.Location,
        //            CreatedDate = viewModel.CreatedDate,
        //            Category = viewModel.Category,
        //            Attendee = viewModel.Attendee,
        //        };

        //        await _dbContext.Event.AddAsync(events); // Use the injected DbContext
        //        await _dbContext.SaveChangesAsync();

        //        return RedirectToAction("Index"); // Redirect after saving
        //    }
        //    return View(viewModel); // Return the view with validation messages
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}