using eGames.Data;
using eGames.Data.Services;
using eGames.Data.Static;
using eGames.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace eGames.Controllers
{
    //[Authorize(Roles = UserRoles.Admin)]
    public class GameEnginesController : Controller
    {
        private readonly IGameEnginesService _service;

        public GameEnginesController(IGameEnginesService service)
        {
            _service = service;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allGameEngines = await _service.GetAllAsync();
            return View(allGameEngines);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name, Description, Logo")] GameEngine gameEngine)
        {
            if (!ModelState.IsValid)
            {
                return View(gameEngine);
            }

            await _service.AddAsync(gameEngine);
            return RedirectToAction(nameof(Index));
        }

       
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var gameengineDetails = await _service.GetByIdAsync(id);
            if (gameengineDetails == null)
                return View("NotFound");
            return View(gameengineDetails);
        }

        
        public async Task<IActionResult> Edit(int id)
        {
            var gameengineDetails = await _service.GetByIdAsync(id);
            if (gameengineDetails == null)
                return View("NotFound");
            return View(gameengineDetails);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Logo,Name,Description")] GameEngine gameengine)
        {
            if (!ModelState.IsValid)
                return View(gameengine);
            await _service.UpdateAsync(id, gameengine);
            return RedirectToAction(nameof(Index));
        }

        //Get: Cinemas/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var gameengineDetails = await _service.GetByIdAsync(id);
            if (gameengineDetails == null)
                return View("NotFound");


            return View(gameengineDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gameengineDetails = await _service.GetByIdAsync(id);
            if (gameengineDetails == null)
                return View("NotFound");

            await _service.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }

    }
}
