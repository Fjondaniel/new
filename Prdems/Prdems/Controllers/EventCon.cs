using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prdems.Data;
using Prdems.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Prdems.Models;

namespace Prdems.Controllers
{
    public class EventCon : Controller
    {
       
        private readonly ApplicationDbContext _dbContext; // Use your actual DbContext

        public EventCon( ApplicationDbContext dbContext)
        {
         
            _dbContext = dbContext;
        }
        public IActionResult Event()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Event(EventViewModel viewModel)
        {
            if (ModelState.IsValid) // Ensure the input is valid
            {
                var events = new Event
                {
                    EventName = viewModel.EventName,
                    EventDescription = viewModel.EventDescription,
                    Location = viewModel.Location,
                    CreatedDate = viewModel.CreatedDate,
                    Category = viewModel.Category,
                    Attendee = viewModel.Attendee,
                };

                await _dbContext.Event.AddAsync(events); // Use DbSet<Event>
                await _dbContext.SaveChangesAsync();

                return RedirectToAction("Index"); // Redirect after saving
            }
            return View(viewModel); // Return the view with validation messages
        }
        [HttpGet]
        public async Task<IActionResult> EventList()
        {
            var events = await _dbContext.Event.ToListAsync();
            return View(events);

        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid Id)
        {
            var events = await _dbContext.Event.FindAsync(Id);
            return View(events);
        }
   
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Edit(Guid Id, Event eventModel)
        {
            if (Id != eventModel.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                _dbContext.Update(eventModel);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction("EventList"); // Redirect to event list after update
            }

            return RedirectToAction("EventList", "EventCon");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Event viewModel)
        {
            var joke = await _dbContext.Event.AsNoTracking().FirstOrDefaultAsync(x => x.Id == viewModel.Id);

            if (joke != null)
            {
                _dbContext.Event.Remove(joke);
                await _dbContext.SaveChangesAsync();
            }

            return RedirectToAction("EventList", "EventCon");
        }

    }
}