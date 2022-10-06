namespace eGames.Models
{
    public class Character_Game
    {
        public int CharacterId
        {
            get; set;
        }

        public Game Game { get; set; }    

        public int GameId
        {
            get; set;
        }

        public Character Character { get; set; }
    }
}
