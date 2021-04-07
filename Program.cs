using System;
using System.Linq;
using ProjectIt1Business;

namespace AddData
{
    public class Program
    {
        static void Main(string[] args)
        {
            AddAuthor("Mikey1886", "m.abs@email.com", "password", "Mike Abs");
            AddAuthor("Dyl1967", "dyl_l@email.com", "password", "Dylan Lewis");
            AddAuthor("MartyBWHUFC", "marty@email.com", "password", "Martin Boyle");
            AddAuthor("JWalker1888", "johnwalker@email.com", "password", "John Walker");

            AddTeamPage("Mikey1886", "Arsenal");
            AddTeamPage("Dyl1967", "Celtic");
            AddTeamPage("MartyBWHUFC", "West Ham");
            AddTeamPage("JWalker1888", "Hibs");

            AddArticle("Mike Abs", "Arsenal Lose Again",
                "Arsenal were beaten by Spurs");

            AddArticle("Mike Abs", "Arsenal Lose ",
                "Arsenal were beaten by Crystal Palace");

            AddArticle("Dylan Lewis", "Celtic end awful streak",
                "Celtic ended their 10 game losing streak by beating Motherwell 2-0");

            AddArticle("Dylan Lewis", "Celtic continue winning run",
                "Celtic beat Rangers 5-0 to continue on from their win last week.");

            AddArticle("Martin Boyle", "West Ham win champions league",
                "West Ham win champions league as they thrash Bayern Munich 4-1.");

            AddArticle("John Walker", "Hibs find form",
                "Hibs have now won 3 games in a row as they make a push for the title");
        }

        static void AddAuthor(string username, string email, string password, string authorName)
        {
            using (SportsDbContext db = new SportsDbContext())
            {
                Author newAuthor = new Author
                {
                    Username = username,
                    Email = email,
                    Password = password,
                    AuthorName = authorName
                };

                db.Author.Add(newAuthor);

                db.SaveChanges();
            }

            Console.WriteLine($"Added User '{username}'");
        }

        static void AddTeamPage(string username, string teamName)
        {
            using (SportsDbContext db = new SportsDbContext())
            {
                int authorId =
                (
                    from au in db.Author
                    where au.Username == username
                    select au.AuthorId
                )
                .Single();

                TeamPage newTeamPage = new TeamPage
                {
                    AuthorId = authorId,
                    TeamName = teamName
                };

                db.TeamPage.Add(newTeamPage);

                db.SaveChanges();
            }

            Console.WriteLine($"Added Team: '{teamName}' which will feature articles from: '{username}'");
        }

        static void AddArticle(string authorName, string title, string content)
        {
            using (SportsDbContext db = new SportsDbContext())
            {
                int teamPageId =
                (
                    from au in db.Author
                    join tp in db.TeamPage on au.AuthorId equals tp.AuthorId
                    where au.AuthorName == authorName
                    select tp.TeamPageId
                )
                .Single();

                Article newArticle = new Article
                {
                    TeamPageId = teamPageId,
                    Title = title,
                    Content = content
                };

                db.Article.Add(newArticle);

                db.SaveChanges();
            }

            Console.WriteLine($"Added a new article by: '{authorName}'");
        }
    }
}
