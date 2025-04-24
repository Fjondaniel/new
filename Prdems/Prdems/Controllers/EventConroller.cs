//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using Prdems.Data;
//using Prdems.Models.Entities;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.Extensions.Logging;
//using Prdems.Models;

//namespace Prdems.Controllers
//{
//    public class EventCon : Controller
//    {

//        private readonly ApplicationDbContext _dbContext; // Use your actual DbContext

//        public EventCon(ApplicationDbContext dbContext)
//        {

//            _dbContext = dbContext;
//        }

//        [Authorize]
//        [HttpPost]
//        public async Task<IActionResult> Event(Event viewModel)
//        {
//            if (ModelState.IsValid) // Ensure the input is valid
//            {
//                var events = new Event
//                {
//                    EventName = viewModel.EventName,
//                    EventDescription = viewModel.EventDescription,
//                    Location = viewModel.Location,
//                    CreatedDate = viewModel.CreatedDate,
//                    Category = viewModel.Category,
//                    Attendee = viewModel.Attendee,
//                };

//                await _dbContext.Event.AddAsync(events); // Use DbSet<Event>
//                await _dbContext.SaveChangesAsync();

//                return RedirectToAction("Index"); // Redirect after saving
//            }
//            return View(viewModel); // Return the view with validation messages
//        }
//    }
//}