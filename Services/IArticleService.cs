using NewsFeedAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsFeedAPI.Services
{
    public interface IArticleService
    {
        bool AddEditArticle(Article article);
        bool RemoveArticle(int id);
        IEnumerable<Article> GetArticleList();
        Article GetArticle(int id);
    }
}
