using NewsFeedAPI.HelperConst;
using NewsFeedAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsFeedAPI.Services
{
    public class ArticleService : IArticleService
    {
        private readonly NFDbContext _nFDbContext;
        public ArticleService(NFDbContext nFDbContext)
        {
            _nFDbContext = nFDbContext;
        }
        public bool AddEditArticle(Article article)
        {
            bool isDone;
            if(article.ArticleId == 0)
            {
                _nFDbContext.Add(article);
                _nFDbContext.SaveChanges();
                isDone = true;
            }
            else
            {
                _nFDbContext.Update(article);
                _nFDbContext.SaveChanges();
                isDone = true;
            }
            return isDone;
        }

        public Article GetArticle(int id)
        {
            Article article = _nFDbContext.Article.FirstOrDefault(q => q.ArticleId == id);
            return article;
        }

        public IEnumerable<Article> GetArticleList()
        {
            IEnumerable<Article> articles = _nFDbContext.Article.AsEnumerable();
            return articles;
        }

        public bool RemoveArticle(int id)
        {
            bool isDone = false;
            Article article = GetArticle(id);
            if(article != null)
            {
                _nFDbContext.Remove(article);
                Multimedia multimedia = _nFDbContext.Multimedia.FirstOrDefault(q => q.ArticleId == id);
                if(multimedia != null)
                {
                    _nFDbContext.Remove(multimedia);
                }
                _nFDbContext.SaveChanges();
                isDone = true;
            }
            return isDone;
        }
    }
}
