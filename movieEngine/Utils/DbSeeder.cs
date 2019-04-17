using movieEngine.Data;
using System;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using movieEngine.Data.Models;
using System.Collections.Generic;
using System.Text;

namespace movieEngine.Web.Utils
{
public class DbSeeder
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var db = serviceProvider.GetService<MyDbContext>())
        {
            List<Actor> actorsSeedList = new List<Actor>{
                new Actor { Firstname = "Tom", Lastname = "Hanks" },
                new Actor { Firstname = "Leonardo", Lastname = "Di Caprio" },
                new Actor { Firstname = "Robert", Lastname = "De Niro" },
                new Actor { Firstname = "Will", Lastname = "Smith" },
                new Actor { Firstname = "Tom", Lastname = "Cruise" },
                new Actor { Firstname = "Jackie", Lastname = "Chan" },
                new Actor { Firstname = "Denzel", Lastname = "Washington" },
                new Actor { Firstname = "Christian", Lastname = "Bale" },
                new Actor { Firstname = "Matt", Lastname = "Damon" },
                new Actor { Firstname = "Margot", Lastname = "Robbie" },
                new Actor { Firstname = "Mila", Lastname = "Cunis" },
                new Actor { Firstname = "Julia", Lastname = "Roberts" },
                new Actor { Firstname = "Jennifer", Lastname = "Lawrance" },
                new Actor { Firstname = "Jennifer", Lastname = "Aniston" },
                new Actor { Firstname = "Scarlett", Lastname = "Johansson" },
                new Actor { Firstname = "Cate", Lastname = "Blanchett" }
            };
            db.Actors.AddRange(actorsSeedList);

            TitleType mov = new TitleType { Name = "Movie" };
            TitleType theatre = new TitleType { Name = "Theatre" };
            TitleType show = new TitleType { Name = "TV Show" };
            db.TitleTypes.AddRange(mov, theatre, show);

            List<Title> titlesSeedList = new List<Title>
            {
                new Title { Name = "Black Panther", Released = new DateTime(2018, 2, 16), Type = mov, 
                            Description = "\"Black Panther\" follows T'Challa who, after the events of \"Captain America: Civil War, " +
                            "returns home to the isolated, technologically advanced African nation of Wakanda to take his place as King. " +
                            "However, when an old enemy reappears on the radar, T'Challa's mettle as King and Black Panther is tested " +
                            "when he is drawn into a conflict that puts the entire fate of Wakanda and the world at risk." 
                },
                new Title { Name = "Mission: Impossible - Fallout", Released = new DateTime(2018, 7, 26), Type = mov,
                            Description = "Fast, sleek, and fun, Mission: Impossible - Fallout lives up to the \"impossible\" part of its " +
                            "name by setting yet another high mark for insane set pieces in a franchise full of them."
                },
                new Title { Name = "Blackkklansman", Released = new DateTime(2018, 8, 10), Type = mov,
                            Description = "BlacKkKlansman uses history to offer bitingly trenchant commentary on current events -- and " +
                            "brings out some of Spike Lee's hardest-hitting work in decades along the way."
                },
                new Title { Name = "Spider-man: Into the Spider-verse", Released = new DateTime(2018, 4, 20), Type = mov,
                            Description = "Spider-Man: Into the Spider-Verse matches bold storytelling with striking animation for a " +
                            "purely enjoyable adventure with heart, humor, and plenty of superhero action."
                },
                new Title { Name = "Roma", Released = new DateTime(2017, 9, 22), Type = mov,
                            Description = "Roma finds writer-director Alfonso Cuarón in complete, enthralling command of his visual craft " +
                            "- and telling the most powerfully personal story of his career."
                },
                new Title { Name = "A star is born", Released = new DateTime(2018, 7, 6), Type = mov,
                            Description = "With appealing leads, deft direction, and an affecting love story, A Star Is Born is a remake " +
                            "done right -- and a reminder that some stories can be just as effective in the retelling."
                },
                new Title { Name = "A quit place", Released = new DateTime(2017, 6, 1), Type = mov,
                            Description = "A Quiet Place artfully plays on elemental fears with a ruthlessly intelligent creature feature " +
                            "that's as original as it is scary -- and establishes director John Krasinski as a rising talent."
                },
                new Title { Name = "Can you ever forgive me?", Released = new DateTime(2017, 2, 16), Type = mov,
                            Description = "Deftly directed and laced with dark wit, Can You Ever Forgive Me? proves a compelling showcase " +
                            "for deeply affecting work from Richard E. Grant and Melissa McCarthy."
                },
                new Title { Name = "Eighth grade", Released = new DateTime(2017, 5, 26), Type = mov,
                            Description = "Eighth Grade takes a look at its titular time period that offers a rare and resounding ring of " +
                            "truth while heralding breakthroughs for writer-director Bo Burnham and captivating star Elsie Fisher."
                },
                new Title { Name = "Paddington 2", Released = new DateTime(2018, 12, 24), Type = mov,
                            Description = "Paddington 2 honors its star's rich legacy with a sweet-natured sequel whose adorable visuals " +
                            "are matched by a story perfectly balanced between heartwarming family fare and purely enjoyable all-ages " +
                            "adventure."
                },
                new Title { Name = "The cabinet of dr. Caligari", Released = new DateTime(2018, 2, 28), Type = mov,
                            Description = "Arguably the first true horror film, The Cabinet of Dr. Caligari set a brilliantly high bar for " +
                            "the genre -- and remains terrifying nearly a century after it first stalked the screen."
                },
                new Title { Name = "Get out", Released = new DateTime(2017, 4, 19), Type = mov,
                            Description = "Funny, scary, and thought-provoking, Get Out seamlessly weaves its trenchant social critiques " +
                            "into a brilliantly effective and entertaining horror/comedy thrill ride."
                },
                new Title { Name = "The third man", Released = new DateTime(1949, 9, 3), Type = mov,
                            Description = "This atmospheric thriller is one of the undisputed masterpieces of cinema, and boasts iconic " +
                            "performances from Joseph Cotten and Orson Welles."
                },
                new Title { Name = "The wizard of Oz", Released = new DateTime(1939, 10, 25), Type = mov,
                            Description = "An absolute masterpiece whose groundbreaking visuals and deft storytelling are still every " +
                            "bit as resonant, The Wizard of Oz is a must-see film for young and old."
                },
                new Title { Name = "Black summer", Released = new DateTime(2018, 2, 17), Type = show,
                            Description = "In the dark, early days of a zombie apocalypse, complete strangers band together to find the " +
                            "strength they need to survive and get back to loved ones."
                },
                new Title { Name = "Killing Eve", Released = new DateTime(2018, 3, 16), Type = show,
                            Description = "With the titillating cat-and-mouse game still rooted at its core, Killing Eve returns for an " +
                            "enthralling second season."
                },
                new Title { Name = "A discovery of Witches", Released = new DateTime(2018, 4, 15), Type = show,
                            Description = "A Discovery of Witches smartly grounds its flights of fancy with a lived-in authenticity and " +
                            "harnesses the chemistry."
                },
                new Title { Name = "The OA", Released = new DateTime(2018, 5, 14), Type = show,
                            Description = "The OA's second season provides satisfying answers to its predecessors."
                },
                new Title { Name = "Unforgotten", Released = new DateTime(2018, 6, 13), Type = show,
                            Description = "No consensus yet."
                },
                new Title { Name = "Barry", Released = new DateTime(2018, 7, 22), Type = show,
                            Description = "Barry follows up a pitch-perfect debut with a second season that balances darkness with comedy."
                },
                new Title { Name = "Les Miserables", Released = new DateTime(2018, 8, 21), Type = show,
                            Description = "Andrew Davies' deft adaptation of the oft-retold Victor Hugo classic affords viewers a newfound " +
                            "intimacy with these outcasts."
                },
                new Title { Name = "Chilling adventures of Sabrina", Released = new DateTime(2018, 2, 9), Type = show,
                            Description = "With a stronger central mystery steeped in witchy world building."
                },
                new Title { Name = "American gods", Released = new DateTime(2018, 9, 9), Type = show,
                            Description = "American Gods retains its bombastic style but loses its divine inspiration in a derivative second season."
                },
                new Title { Name = "The twilight zone", Released = new DateTime(2018, 11, 11), Type = show,
                            Description = "The Twilight Zone explores the strangeness of the modern world through Rod Serling's winning formula."
                },
                new Title { Name = "Hanna", Released = new DateTime(2017, 11, 16), Type = show,
                            Description = "A gritty reimagining of the 2011 film, Hanna adds new wrinkles to the mythology and texture to the " +
                            "titular assassin -- though the series' long-winded journey may try the patience of viewers who want their violent " +
                            "fables concise."
                },
                new Title { Name = "Two and a half men", Released = new DateTime(2011, 2, 10), Type = show,
                            Description = "Really good comedy!"
                },
            };
            db.Titles.AddRange(titlesSeedList);
            db.SaveChanges();

            var random = new Random();
            db.Titles.ToList().ForEach(t => {
                int randomIndex = random.Next(actorsSeedList.Count - 1);
                t.Actors = new List<TitleActor>() {
                    new TitleActor { Title = t, Actor = actorsSeedList[randomIndex] },
                    new TitleActor { Title = t, Actor = actorsSeedList[randomIndex + 1] }
                };
            });

            Client thisapp = new Client { Name = "Mistral - EJ Test App", Username = "eja" };
            Client clientapp1 = new Client { Name = "Imdb Co.", Username = "imdbco" };
            Client clientapp2 = new Client { Name = "Rotten Tomatoes", Username = "rottentoms" };
            thisapp.Token = SeedTokensHelper(thisapp);
            clientapp1.Token = SeedTokensHelper(clientapp1);
            clientapp2.Token = SeedTokensHelper(clientapp2);

            db.Clients.AddRange(thisapp, clientapp1, clientapp2);

            db.SaveChanges();
        }

    }

    private static String SeedTokensHelper(Client client) => 
        Convert.ToBase64String(Encoding.UTF8.GetBytes(client.Username + ":" + client.Username));
}
}
