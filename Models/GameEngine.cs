using eGames.Data.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace eGames.Models
{
    public class GameEngine : IEntityBase
    {
        [Key]
        public int Id
        {
            get; set;
        }

        [Required(ErrorMessage = "A GameEngine logo is required.")]
        [Display(Name = "GameEngine Logo")]
        public string Logo
        {
            get; set;
        }

        [Required(ErrorMessage = "A GameEngine name is required.")]
        [MinLength(3, ErrorMessage = "The name must be at least 3 characters")]
        [Display(Name = "GameEngine Name")]
        public string Name
        {
            get; set;
        }

        [Required(ErrorMessage = "A GmaeEngine description is required.")]
        [MinLength(3, ErrorMessage = "The description must be at least 3 characters")]
        [Display(Name = "Description")]
        public string Description
        {
            get; set;
        }

        // relationships

        public List<Game> Games
        {
            get; set;
        }
    }
}
