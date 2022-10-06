using eGames.Data.Services;
using eGames.Data.Static;
using eGames.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace eGames.Controllers
{
    //[Authorize(Roles = UserRoles.Admin)]
    public class GamesController : Controller
    {
        // private readonly AppDbContext _context;
        private readonly IGamesService _service;

        public GamesController(IGamesService service)
        {

            _service = service;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allGames = await _service.GetAllAsync(n => n.GameEngine);   // this will be the property that's included

            return View(allGames);
        }
        [AllowAnonymous]
        public async Task<IActionResult> Filter(string searchString)
        {
            var allGames = await _service.GetAllAsync(n => n.GameEngine);   // this will be the property that's included

            // filter the Games results

            if (!string.IsNullOrEmpty(searchString))
            {
                // var filteredResult = allGames.Where(n => n.Name.ToLower().Contains(searchString.ToLower()) || n.Description.ToLower().Contains(searchString.ToLower())).ToList();

                var filteredResult = allGames.Where(n => string.Equals(n.Name, searchString, StringComparison.CurrentCultureIgnoreCase) || 
                string.Equals(n.Description, searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();

                return View("Index", filteredResult);
            }

            return View("Index", allGames);
        }

        //GET: Games/Details/1
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var gameDetail = await _service.GetGameByIdAsync(id);
            return View(gameDetail);    // passing Game data to the view
        }

        // GET: Games/Create

        public async Task<IActionResult> Create()
        {
            // ViewData["Welcome"] = "welcome to our store";
            //  ViewBag.Description = "This is the store description";
            var GameDropdownsData = await _service.GetNewGameDropdownsValues();

            // bind with the Select dropdowns in the view

            ViewBag.GameEngines = new SelectList(GameDropdownsData.GameEngines, "Id", "Name");
            ViewBag.LeadProgrammers = new SelectList(GameDropdownsData.LeadProgrammers, "Id", "FullName");
            ViewBag.Characters = new SelectList(GameDropdownsData.Characters, "Id", "FullName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewGameVM game)
        {

            if (!ModelState.IsValid)
            {
                var gameDropdownsData = await _service.GetNewGameDropdownsValues();
                ViewBag.GameEngines = new SelectList(gameDropdownsData.GameEngines, "Id", "Name");
                ViewBag.LeadProgrammers = new SelectList(gameDropdownsData.LeadProgrammers, "Id", "FullName");
                ViewBag.Characters = new SelectList(gameDropdownsData.Characters, "Id", "FullName");
                return View(game);
            }

            await _service.AddNewGameAsync(game);
            return RedirectToAction(nameof(Index));
        }

        // GET: Games/Edit/1

        public async Task<IActionResult> Edit(int id)
        {
            // ViewData["Welcome"] = "welcome to our store";
            //  ViewBag.Description = "This is the store description";

            var gameDetails = await _service.GetGameByIdAsync(id);
            // if the Game is not found

            if (gameDetails == null)
            {
                return View("NotFound");
            }
            // otherwise construct a response

            var response = new NewGameVM()
            {
                Id = gameDetails.Id,
                Name = gameDetails.Name,
                Description = gameDetails.Description,
                Price = gameDetails.Price,
                StartDate = gameDetails.StartDate,
                EndDate = gameDetails.EndDate,
                ImageURL = gameDetails.ImageURL,
                GameCategory = gameDetails.GameCategory,
                GameEngineId = gameDetails.GameEngineId,
                LeadProgrammerId = gameDetails.LeadProgrammerId,
                CharactersIds = gameDetails.Characters_Games.Select(n => n.CharacterId).ToList()
            };

            var gameDropdownsData = await _service.GetNewGameDropdownsValues();

            // bind with the Select dropdowns in the view

            ViewBag.GameEngines = new SelectList(gameDropdownsData.GameEngines, "Id", "Name");
            ViewBag.LeadProgrammers = new SelectList(gameDropdownsData.LeadProgrammers, "Id", "FullName");
            ViewBag.Characters = new SelectList(gameDropdownsData.Characters, "Id", "FullName");
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewGameVM game)
        {
            if (id != game.Id)
                return View("NotFound");


            if (!ModelState.IsValid)
            {
                var gameDropdownsData = await _service.GetNewGameDropdownsValues();
                ViewBag.GameEngines = new SelectList(gameDropdownsData.GameEngines, "Id", "Name");
                ViewBag.LeadProgrammers = new SelectList(gameDropdownsData.LeadProgrammers, "Id", "FullName");
                ViewBag.Characters = new SelectList(gameDropdownsData.Characters, "Id", "FullName");
                return View(game);
            }

            await _service.UpdateGameAsync(game);
            return RedirectToAction(nameof(Index));
        }

    }
}
