using eGames.Data.Base;
using eGames.Data.ViewModels;
using eGames.Models;
using System.Threading.Tasks;

namespace eGames.Data.Services
{
    public interface IGamesService : IEntityBaseRepository<Game>
    {
        Task<Game> GetGameByIdAsync(int id);
        Task<NewGameDropdownsVM> GetNewGameDropdownsValues();
        Task AddNewGameAsync(NewGameVM data);

        Task UpdateGameAsync(NewGameVM data);
    }
}