using eGames.Data.Enum;
using eGames.Data.Static;
using eGames.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eGames.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                // create a reference to send or get from database 
                var context = serviceScope.ServiceProvider.GetRequiredService<AppDbContext>();

                context.Database.EnsureCreated();
                
                // cinema
                if (!context.GameEngines.Any())
                {
                    context.GameEngines.AddRange(new List<GameEngine>()
                    {
                        new GameEngine()
                        {
                            Name = "Unreal Engine",
                            Logo = "https://cdn2.unrealengine.com/ue-logo-1400x788-1400x788-8f185e1e3635.jpg",
                            Description = "Unreal Engine (UE) is a 3D computer graphics game engine developed by Epic Games, first showcased in the 1998" +
                            " first-person shooter game Unreal. Initially developed for PC first-person shooters, it has since been used in a variety of" +
                            " genres of games and has seen adoption by other industries, most notably the film and television industry. Written in C++, " +
                            "the Unreal Engine " +
                            "features a high degree of portability, supporting a wide range of desktop, mobile, console and virtual reality platforms."
                        },
                        new GameEngine()
                        {
                            Name = "Unity",
                            Logo = "https://unity.com/logo-unity-web.png",
                            Description = "Unity is a cross-platform game engine developed by Unity " +
                            "Technologies, first announced and released in June 2005 at Apple Worldwide" +
                            " Developers Conference as a Mac OS X game engine. The engine has since been " +
                            "gradually extended to support a variety of desktop, mobile, console and virtual " +
                            "reality platforms. It is particularly popular for iOS and Android mobile game " +
                            "development and is considered easy to use for beginner developers and is popular " +
                            "for indie game development.[5]"
                        },
                        new GameEngine()
                        {
                            Name = "Godot",
                            Logo = "https://godotengine.org/themes/godotengine/assets/og_image.png",
                            Description = "Godot (/ˈɡɒdoʊ/)[a] is a cross-platform, free and open-source" +
                            " game engine released under the MIT license. It was initially developed by" +
                            " Argentine software developers Juan Linietsky and Ariel Manzur[5] for several" +
                            " companies in Latin America prior to its public release.[6] The development " +
                            "environment runs on multiple operating systems including Linux, BSDs, macOS," +
                            " and Microsoft Windows. It is designed to create both 2D and 3D games targeting PC," +
                            " mobile, and web platforms. It can also be used to create non game software," +
                            " including editors."
                        },
                        new GameEngine()
                        {
                            Name = "AppGameKit",
                            Logo = "https://www.appgamekit.com/images/studio/studio-logo.png",
                            Description = "AppGameKit is an easy to learn game development engine, ideal for Beginners, Hobbyists & Indie developers"
                        },
                        new GameEngine()
                        {
                            Name = "CryEngine",
                            Logo = "https://pbs.twimg.com/profile_images/753973200032268288/KCTzYEkn_400x400.jpg",
                            Description = "CryEngine (stylized as CRYENGINE) is a game engine designed by the" +
                            " German game developer Crytek. It has been used in all of their titles with the" +
                            " initial version being used in Far Cry, and continues to be updated to support" +
                            " new consoles and hardware for their games. It has also been used for many third-party " +
                            "games under Crytek's licensing scheme, including Sniper: Ghost Warrior 2 and SNOW. " +
                            "Warhorse Studios uses a modified version of the engine for their medieval RPG Kingdom Come:" +
                            " Deliverance. Ubisoft maintains an in-house, heavily modified version of CryEngine " +
                            "from the original Far Cry called the Dunia Engine, which is used in their later " +
                            "iterations of the Far Cry series."
                        },
                    });
                    context.SaveChanges();
                }

                // Characters

                if (!context.Characters.Any())
                {
                    context.Characters.AddRange(new List<Character>()
                    {
                        new Character()
                        {
                            FullName = "Super Mario",
                            Bio = "This is the Bio of the first Character",
                            ProfilePictureURL = "https://media-cldnry.s-nbcnews.com/image/upload/t_fit-760w,f_auto,q_auto:best/streams/2012/February/120220/62076-6067122.jpg"

                        },
                        new Character()
                        {
                            FullName = "Character 2",
                            Bio = "This is the Bio of the second Character",
                            ProfilePictureURL = "https://fictionhorizon.com/wp-content/uploads/2021/09/50-Best-Video-Game-Characters-of-All-Time-2021-Updated-5.jpg"
                        },
                        new Character()
                        {
                            FullName = "Character 3",
                            Bio = "This is the Bio of the second Character",
                            ProfilePictureURL = "https://toppng.com/uploads/preview/cartoon-game-characters-11549893427ws4wn4t2sc.png"
                        },
                        new Character()
                        {
                            FullName = "Character 4",
                            Bio = "This is the Bio of the second Character",
                            ProfilePictureURL = "https://w7.pngwing.com/pngs/80/402/png-transparent-assassin-s-creed-character-assassins-creed-syndicate-assassins-creed-origins-assassins-creed-brotherhood-assassin-creed-syndicate-video-game-assassins-assassins-creed.png"
                        },
                        new Character()
                        {
                            FullName = "Character 5",
                            Bio = "This is the Bio of the second Character",
                            ProfilePictureURL = "https://www.pngkey.com/png/full/873-8739879_assassins-creed-characters.png"
                        }
                    });
                    context.SaveChanges();
                }

                // LeadProgrammers

                if (!context.LeadProgrammers.Any())
                {
                    context.LeadProgrammers.AddRange(new List<LeadProgrammer>()
                    {
                        new LeadProgrammer()
                        {
                            FullName = "LeadProgrammer 1",
                            Bio = "This is the Bio of the first Character",
                            ProfilePictureURL = "https://media.istockphoto.com/photos/senior-programmer-work-with-developing-programming-picture-id1153978534"

                        },
                        new LeadProgrammer()
                        {
                            FullName = "LeadProgrammer 2",
                            Bio = "This is the Bio of the second Character",
                            ProfilePictureURL = "https://nixolympia.com/wp-content/uploads/2022/07/NOVA-Entertainment-Lead-Programmer-Paul-Jackson-Resigns.jpg"
                        },
                        new LeadProgrammer()
                        {
                            FullName = "LeadProgrammer 3",
                            Bio = "This is the Bio of the second Character",
                            ProfilePictureURL = "https://tighten.com/assets/images/bios/kristin.jpg"
                        },
                        new LeadProgrammer()
                        {
                            FullName = "LeadProgrammer 4",
                            Bio = "This is the Bio of the second Character",
                            ProfilePictureURL = "https://tighten.com/assets/images/bios/sara.jpg"
                        },
                        new LeadProgrammer()
                        {
                            FullName = "LeadProgrammer 5",
                            Bio = "This is the Bio of the second Character",
                            ProfilePictureURL = "https://thumbs.dreamstime.com/b/lead-programmer-woman-coding-software-computer-lead-programmer-woman-coding-software-234392674.jpg"
                        }
                    });
                    context.SaveChanges();
                }

                // Games

                if (!context.Games.Any())
                {
                    context.Games.AddRange(new List<Game>()
                    {
                        new Game()
                        {
                            Name = "Assassin's Creed Valhalla",
                            Description = "This is the Assassin's Creed Valhalla game description",
                            Price = 39.50,
                            ImageURL = "https://static.posters.cz/image/1300/posteri/assassin-s-creed-valhalla-raid-i96340.jpg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(10),
                            GameEngineId = 3,
                            LeadProgrammerId = 3,
                            GameCategory =GameCategory.Action
                        },
                        new Game()
                        {
                            Name = "NFS payback",
                            Description = "This is the NFS payback game description",
                            Price = 29.50,
                            ImageURL = "https://www.goodgame.hr/wp-content/uploads/2017/09/nfs-paybackk.jpg",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(3),
                            GameEngineId = 1,
                            LeadProgrammerId = 1,
                            GameCategory = GameCategory.Racing
                        },
                        new Game()
                        {
                            Name = "Army Men: RTS",
                            Description = "This is the Army Men: RTS game description",
                            Price = 39.50,
                            ImageURL = "https://upload.wikimedia.org/wikipedia/en/thumb/9/97/Army_Men_-_RTS_Coverart.png/220px-Army_Men_-_RTS_Coverart.png",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(7),
                            GameEngineId = 4,
                            LeadProgrammerId = 4,
                            GameCategory = GameCategory.Strategy
                        },
                        new Game()
                        {
                            Name = "GTA V",
                            Description = "This is the GTA 5 game description",
                            Price = 39.50,
                            ImageURL = "https://svijet-igara.hr/wp-content/uploads/2020/03/Grand-Theft-Auto-V-Premium-Edition-GTA-V-PS4-3D-500x500.jpg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(-5),
                            GameEngineId = 1,
                            LeadProgrammerId = 2,
                            GameCategory = GameCategory.Action
                        },
                        new Game()
                        {
                            Name = "Anno 1404",
                            Description = "This is the Anno 1404 game description",
                            Price = 39.50,
                            ImageURL = "https://static.kinguin.net/cdn-cgi/image/w=1140,q=80,fit=scale-down,f=auto/media/category/s/s/ss_60f31a738264045956b6e99eb0fc1aca21ce344e.1920x1080-1024.jpg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(-2),
                            GameEngineId = 1,
                            LeadProgrammerId = 3,
                            GameCategory = GameCategory.Strategy
                        },
                        new Game()
                        {
                            Name = "Far cry 3",
                            Description = "This is the Far cry 3 description",
                            Price = 39.50,
                            ImageURL = "https://www.njuskalo.hr/image-w920x690/ps3-igre/far-cry-3-ps3-slika-56463182.jpg",
                            StartDate = DateTime.Now.AddDays(3),
                            EndDate = DateTime.Now.AddDays(20),
                            GameEngineId = 1,
                            LeadProgrammerId = 5,
                            GameCategory = GameCategory.Action
                        }
                    });
                    context.SaveChanges();
                }

                // Characters and Games

                if (!context.Characters_Games.Any())
                {
                    context.Characters_Games.AddRange(new List<Character_Game>()
                    {
                        new Character_Game()
                        {
                            CharacterId = 1,
                            GameId = 1
                        },
                        new Character_Game()
                        {
                            CharacterId = 3,
                            GameId = 1
                        },

                         new Character_Game()
                        {
                            CharacterId = 1,
                            GameId = 2
                        },
                         new Character_Game()
                        {
                            CharacterId = 4,
                            GameId = 2
                        },

                        new Character_Game()
                        {
                            CharacterId = 1,
                            GameId = 3
                        },
                        new Character_Game()
                        {
                            CharacterId = 2,
                            GameId = 3
                        },
                        new Character_Game()
                        {
                            CharacterId = 5,
                            GameId = 3
                        },


                        new Character_Game()
                        {
                            CharacterId = 2,
                            GameId = 4
                        },
                        new Character_Game()
                        {
                            CharacterId = 3,
                            GameId = 4
                        },
                        new Character_Game()
                        {
                            CharacterId = 4,
                            GameId = 4
                        },


                        new Character_Game()
                        {
                            CharacterId = 2,
                            GameId = 5
                        },
                        new Character_Game()
                        {
                            CharacterId = 3,
                            GameId = 5
                        },
                        new Character_Game()
                        {
                            CharacterId = 4,
                            GameId = 5
                        },
                        new Character_Game()
                        {
                            CharacterId = 5,
                            GameId = 5
                        },


                        new Character_Game()
                        {
                            CharacterId = 3,
                            GameId = 6
                        },
                        new Character_Game()
                        {
                            CharacterId = 4,
                            GameId = 6
                        },
                        new Character_Game()
                        {
                            CharacterId = 5,
                            GameId = 6
                        },
                    });
                    context.SaveChanges();
                }

            }
        }
        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                //Roles 
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));

                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users

                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string adminUserEmail = "admin@eGames.com";
                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FullName = "Admin User",
                        UserName = "admin-user",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "Coding@1234?");  // just creates the user
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin); // assigns the role to the user
                }

                //Creating a simple user

                
                string appUserEmail = "user@eGames.com";
                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FullName = "Application User",
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "Coding@4321?");  // just creates the user
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User); // assigns the role to the user
                }
            }
        }
    }
}
