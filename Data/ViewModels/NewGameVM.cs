using eGames.Data.Base;
using eGames.Data.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eGames.Models
{
    public class NewGameVM
    {
        public int Id
        {
            get; set;
        }

        [Display(Name ="Game name")]
        [Required(ErrorMessage = "Name is required")]
        public string Name
        {
            get; set;
        }

        [Display(Name = "Game Description")]
        [Required(ErrorMessage = "Description is required")]
        public string Description
        {
            get; set;
        }

        [Display(Name = "Price in $")]
        [Required(ErrorMessage = "Price is required")]
        public double Price
        {
            get; set;
        }
        [Display(Name = "Game Poster URL")]
        [Required(ErrorMessage = "Game poster URL is required")]
        public string ImageURL
        {
            get; set;
        }

        [Display(Name = "Game Start Date")]
        [Required(ErrorMessage = "Start date is required")]
        public DateTime StartDate
        {
            get; set;
        }
        [Display(Name = "Game End Date")]
        [Required(ErrorMessage = "End date is required")]
        public DateTime EndDate
        {
            get; set;
        }

        // need to add Enum

        [Display(Name = "Select a category")]
        [Required(ErrorMessage = "Game category is required")]
        public GameCategory GameCategory
        {
            get; set;
        }

        //Relationships
        [Display(Name = "Select Character(s)")]
        [Required(ErrorMessage = "Game Characters are required")]
        public List<int> CharactersIds
        {
            get; set;
        }

        [Display(Name = "Select GameEngine(s)")]
        [Required(ErrorMessage = "Game engines are required")]
        public int GameEngineId
        {
            get; set;
        }

        [Display(Name = "Select LeadProgrammer")]
        [Required(ErrorMessage = "Game LeadProgrammer required")]
        public int LeadProgrammerId
        {
            get; set;
        }
      

    }
}
