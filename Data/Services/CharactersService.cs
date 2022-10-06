using eGames.Data.Base;
using eGames.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eGames.Data.Services
{
    public class CharactersService : EntityBaseRepository<Character>, ICharactersService
    {
       

        public CharactersService(AppDbContext context) : base(context) { }
        
    }
}
