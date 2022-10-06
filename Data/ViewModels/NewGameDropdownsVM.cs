using eGames.Models;
using System.Collections.Generic;

namespace eGames.Data.ViewModels
{
    public class NewGameDropdownsVM
    {
        public NewGameDropdownsVM()
        {
            LeadProgrammers = new List<LeadProgrammer>();
            GameEngines = new List<GameEngine>();
            Characters = new List<Character>();
        }
        public List<LeadProgrammer> LeadProgrammers
        {
            get; set;
        }

        public List<GameEngine> GameEngines
        {
            get; set;
        }

        public List<Character> Characters
        {
            get; set;
        }
    }
}
