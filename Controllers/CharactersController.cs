﻿using eGames.Data;
using eGames.Data.Services;
using eGames.Data.Static;
using eGames.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace eGames.Controllers
{
    //[Authorize(Roles = UserRoles.Admin)]
    public class CharactersController : Controller
    {
        
        private readonly ICharactersService _service;

        public CharactersController(ICharactersService service)
        {
            _service = service;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }

        //Get: Characters/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName, ProfilePictureURL, Bio")] Character character)
        {
            if (!ModelState.IsValid)
            {
                return View(character);
            }

            await _service.AddAsync(character);
            return RedirectToAction(nameof(Index));
        }

        // Get: Characters/Details/id
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            // does the Character exist
            var characterDetails = await _service.GetByIdAsync(id);
            if (characterDetails == null)
                return View("NotFound");

            return View(characterDetails);
        }

        //Get: Characters/Edit
        public async Task<IActionResult> Edit(int id)
        {
            var characterDetails = await _service.GetByIdAsync(id);
            if (characterDetails == null)
                return View("NotFound");


            return View(characterDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("CharacterId, FullName, ProfilePictureURL, Bio")] Character character)
        {
            if (!ModelState.IsValid)
            {
                return View(character);
            }

            await _service.UpdateAsync(id, character);
            return RedirectToAction(nameof(Index));
        }

        //Get: Characters/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var characterDetails = await _service.GetByIdAsync(id);
            if (characterDetails == null)
                return View("NotFound");


            return View(characterDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var characterDetails = await _service.GetByIdAsync(id);
            if (characterDetails == null)
                return View("NotFound");

            await _service.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}