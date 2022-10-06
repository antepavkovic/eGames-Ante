using eGames.Data.Base;
using eGames.Models;

namespace eGames.Data.Services
{
    public class GameEnginesService : EntityBaseRepository<GameEngine>, IGameEnginesService
    {
        public GameEnginesService(AppDbContext context) : base(context) { }
       // passes the AppDbContext to the base class which is the EntityBaseRepository
    }
}
