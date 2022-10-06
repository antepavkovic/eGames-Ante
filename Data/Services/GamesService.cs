using eGames.Data.Base;
using eGames.Data.ViewModels;
using eGames.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace eGames.Data.Services
{
    public class GamesService : EntityBaseRepository<Game>, IGamesService
    {
        private readonly AppDbContext _context;
        public GamesService(AppDbContext context) : base(context)
        {
            _context = context;
        }

 

        public async Task AddNewGameAsync(NewGameVM data)
        {
            // Add the data to the database

            // Start by creating a new Game object

            var newGame = new Game()
            {
                Name = data.Name,
                Description = data.Description,
                Price = data.Price,
                ImageURL = data.ImageURL,
                GameEngineId = data.GameEngineId,
                StartDate = data.StartDate,
                EndDate = data.EndDate,
                GameCategory = data.GameCategory,
                LeadProgrammerId = data.LeadProgrammerId,
            };

            await _context.Games.AddAsync(newGame);
            await _context.SaveChangesAsync();

            // Add Game Characters

            foreach (var CharacterId in data.CharactersIds)
            {
                var newCharacterGame = new Character_Game()
                {
                    GameId = newGame.Id,
                    CharacterId = CharacterId,

                };

                await _context.Characters_Games.AddAsync(newCharacterGame);
            }
            await _context.SaveChangesAsync();
        }

  

        public async Task<Game> GetGameByIdAsync(int id)
        {
            var GameDetails = await _context.Games
                  .Include(c => c.GameEngine)
                  .Include(p => p.LeadProgrammer)
                  .Include(am => am.Characters_Games).ThenInclude(a => a.Character)
                  .FirstOrDefaultAsync(n => n.Id == id);

            return GameDetails;
        }

       

        public async Task<NewGameDropdownsVM> GetNewGameDropdownsValues()
        {
            var response = new NewGameDropdownsVM()
            {
                Characters = await _context.Characters.OrderBy(n => n.FullName).ToListAsync(),
                GameEngines = await _context.GameEngines.OrderBy(c => c.Name).ToListAsync(),
                LeadProgrammers = await _context.LeadProgrammers.OrderBy(c => c.FullName).ToListAsync()
            };

            return response;
        }

    

        public async Task UpdateGameAsync(NewGameVM data)
        {
            var dbGame = await _context.Games.FirstOrDefaultAsync(n => n.Id == data.Id);

            if (dbGame != null)
            {

                dbGame.Name = data.Name;
                dbGame.Description = data.Description;
                dbGame.Price = data.Price;
                dbGame.ImageURL = data.ImageURL;
                dbGame.GameEngineId = data.GameEngineId;
                dbGame.StartDate = data.StartDate;
                dbGame.EndDate = data.EndDate;
                dbGame.GameCategory = data.GameCategory;
                dbGame.LeadProgrammerId = data.LeadProgrammerId;

                await _context.SaveChangesAsync();
            }

            // Remove existing Characters

            var existingCharactersDb = _context.Characters_Games.Where(n => n.GameId == data.Id).ToList();
            _context.Characters_Games.RemoveRange(existingCharactersDb);
            await _context.SaveChangesAsync();

            // Add new Game Characters

            foreach (var CharacterId in data.CharactersIds)
            {
                var newCharacterGame = new Character_Game()
                {
                    GameId = data.Id,
                    CharacterId = CharacterId,

                };

                await _context.Characters_Games.AddAsync(newCharacterGame);
            }
            await _context.SaveChangesAsync();
        }
    }
}