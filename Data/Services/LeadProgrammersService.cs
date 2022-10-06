using eGames.Data.Base;
using eGames.Models;

namespace eGames.Data.Services
{
    public class LeadProgrammersService: EntityBaseRepository<LeadProgrammer>, ILeadProgrammersService
    {
        public LeadProgrammersService(AppDbContext context) : base(context)
        {

        }
    }
}
