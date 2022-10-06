using eGames.Data.Base;
using eGames.Data.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eGames.Models
{
    public class Game : IEntityBase
    {
        [Key]
        public int Id
        {
            get; set;
        }

        public string Name
        {
            get; set;
        }

        public string Description
        {
            get; set;
        }

        public double Price
        {
            get; set;
        }
        public string ImageURL
        {
            get; set;
        }

        public DateTime StartDate
        {
            get; set;
        }

        public DateTime EndDate
        {
            get; set;
        }

        // need to add Enum

        public GameCategory GameCategory
        {
            get; set;
        }

        //Relationships

        public List<Character_Game> Characters_Games 
        {
            get; set;
        }

        //Cinema

        
        public int GameEngineId
        {
            get; set;
        }
        [ForeignKey("GameEngineId")]
        public GameEngine GameEngine
        {
            get; set;
        }

        //LeadProgrammer

       
        public int LeadProgrammerId
        {
            get; set;
        }
        [ForeignKey("LeadProgrammerId")]
        public LeadProgrammer LeadProgrammer
        {
            get; set;
        }

    }
}
