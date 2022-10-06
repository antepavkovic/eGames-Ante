﻿using eGames.Data.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace eGames.Models
{
    public class Character : IEntityBase
    {
        [Key]
        public int Id
        {
            get; set;
        }

        [Display(Name ="Profile Picture")]
        [Required(ErrorMessage = "Profile picture is required")]
        public string ProfilePictureURL
        {
            get; set;
        }
        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Full name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Full name must be between 3 and 50 chars")]
        public string FullName
        {
            get; set;
        }
        [Display(Name = "Bio")]
        [Required(ErrorMessage = "Biography is required")]
        public string Bio
        {
            get; set;
        }

        // Relationships

        public List<Character_Game> Characters_Games
        {
            get; set;
        }
    }
}
