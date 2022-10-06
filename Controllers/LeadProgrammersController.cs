using eGames.Data;
using eGames.Data.Services;
using eGames.Data.Static;
using eGames.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace eGames.Controllers
{
   // [Authorize(Roles = UserRoles.Admin)]
    public class LeadProgrammersController : Controller
    {

        private readonly ILeadProgrammersService _service;


        public LeadProgrammersController(ILeadProgrammersService service)
        {
            _service = service;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allLeadProgrammers = await _service.GetAllAsync();
            return View(allLeadProgrammers);
        }

        //GET: LeadProgrammers/details/1
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var leadprogrammersDetails = await _service.GetByIdAsync(id);

            if (leadprogrammersDetails == null)
                return View("NotFound");

            return View(leadprogrammersDetails);
        }

        //GET: LeadProgrammers/create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("ProfilePictureURL, FullName, Bio")] LeadProgrammer leadprogrammers)
        {
            if (!ModelState.IsValid)
                return View(leadprogrammers);

            await _service.AddAsync(leadprogrammers);
            return RedirectToAction(nameof(Index));
        }

        //GET: LeadProgrammers/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var leadprogrammerDetails = await _service.GetByIdAsync(id);
            if (leadprogrammerDetails == null)
                return View("NotFound");


            return View(leadprogrammerDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProfilePictureURL, FullName, Bio")] LeadProgrammer leadprogrammer)
        {

            if (!ModelState.IsValid)
                return View(leadprogrammer);

            if (id == leadprogrammer.Id)
            {

                await _service.UpdateAsync(id, leadprogrammer);
                return RedirectToAction(nameof(Index));
            }

            return View(leadprogrammer);
        }

        // Delete
        // GET: LeadProgrammers/delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var leadprogrammerDetails = await _service.GetByIdAsync(id);
            if (leadprogrammerDetails == null)
                return View("NotFound");

            return View(leadprogrammerDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            var leadprogrammerDetails = await _service.GetByIdAsync(id);
            if (leadprogrammerDetails == null)
                return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
