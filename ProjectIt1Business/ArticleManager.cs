using System.Collections.Generic;
using System.Linq;

namespace ProjectIt1Business
{
    public class ArticleManager
    {
        public Article SelectedArticle { get; set; }

        public void Create(int articleId, string title, string content, string teamPageId)
        {
            var newArt = new Article() { ArticleId = articleId, Title = title, Content = content };
            using (var db = new SportsDbContext())
            {
                db.Article.Add(newArt);
                db.SaveChanges();
            }
        }

        public void Update(int articleId, string title, string content)
        {
            using (var db = new SportsDbContext())
            {
                SelectedArticle = db.Article.Where(a => a.ArticleId == articleId).FirstOrDefault();
                SelectedArticle.Title = title;
                SelectedArticle.Content = content;
                // write changes to database
                db.SaveChanges();
            }
        }

        public void Delete()
        {

        }

        public List<Article> RetrieveAll()
        {
            using (var db = new SportsDbContext())
            {
                return db.Article.ToList();
            }
        }

        public void SetSelectedArticle(object selectedItem)
        {
            SelectedArticle = (Article)selectedItem;
        }
    }
}
