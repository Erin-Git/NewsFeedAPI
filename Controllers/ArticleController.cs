using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsFeedAPI.Models;
using NewsFeedAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsFeedAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleService _articleService;
        ApiResponse apiResponse = new ApiResponse();
        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }
        [HttpPost("AddEditArticle")]
        public IActionResult AddEditArticle(Article article)
        {
            try
            {
                bool isDone = _articleService.AddEditArticle(article);
                if (isDone)
                {
                    apiResponse.Status = "OK";
                    apiResponse.IsExecuted = true;
                }
                else
                {
                    apiResponse.IsExecuted = false;
                    apiResponse.Status = "Failed";
                }
                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                apiResponse.IsExecuted = false;
                apiResponse.Status = ex.InnerException.ToString();
                return Ok(apiResponse);
            }
        }
        [HttpDelete("RemoveArticle/{id}")]
        public IActionResult RemoveArticle(int id)
        {
            try
            {
                bool isRemoved = _articleService.RemoveArticle(id);
                if (isRemoved)
                {
                    apiResponse.IsExecuted = true;
                    apiResponse.Status = "OK";
                }
                else
                {
                    apiResponse.IsExecuted = false;
                    apiResponse.Status = "Failed";
                }
                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                apiResponse.IsExecuted = false;
                apiResponse.Status = ex.InnerException.ToString();
                return Ok(apiResponse);
            }
        }
        [HttpGet("GetArticle/{id}")]
        public IActionResult GetArticle(int id)
        {
            try
            {
                Article article = _articleService.GetArticle(id);
                if (article != null)
                {
                    apiResponse.IsExecuted = true;
                    apiResponse.Result = article;
                    apiResponse.Status = "OK";
                    return Ok(apiResponse);
                }
                else
                {
                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                apiResponse.Status = ex.InnerException.ToString();
                return Ok(apiResponse);
            }
        }
        [HttpGet("GetArticleList")]
        public IActionResult GetArticleList()
        {
            try
            {
                List<Article> articles = _articleService.GetArticleList().ToList();
                if (articles.Count != 0)
                {
                    apiResponse.IsExecuted = true;
                    apiResponse.NumResult = articles.Count;
                    apiResponse.Result = articles;
                    apiResponse.Status = "OK";
                    return Ok(apiResponse);
                }
                else
                {
                    apiResponse.IsExecuted = false;
                    apiResponse.Result = null;
                    apiResponse.Status = "No Content";
                    return Ok(apiResponse);
                }
            }
            catch (Exception ex)
            {
                apiResponse.IsExecuted = false;
                apiResponse.Status = ex.InnerException.ToString();
                return Ok(apiResponse);
            }
        }
    }
}
