using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using SuperZapatosWebAPI.Models;
using SuperZapatosDataAccess;
using SuperZapatosBusiness;
using GAPRepository;
using ArticleDTO = SuperZapatosDTO.Article;

namespace SuperZapatosWebAPI.Controllers
{
    [BasicAuthenticationFilter]
    public class ArticleController : ApiController
    {
        IUnitOfWork<SuperZapatosContext> _unitOfWork;
        IDataAccess<ArticleDTO> _dataAccess;
        ArticleBusiness _articleServices;

        public ArticleController()
        {
            _unitOfWork = new UnitOfWork();
            _dataAccess = new Article(_unitOfWork);
            _articleServices = new ArticleBusiness(_dataAccess);
        }

        // GET: api/Article
        public ArticlesModel Get()
        {
            var model = new ArticlesModel();
            try
            {
                var articles = _articleServices.Get();
                model.Success = true;
                model.Articles = articles;
                model.TotalElements = articles.Count;
            }
            catch
            {
                model.Success = false;
                model.ErrorCode = ((int)HttpStatusCode.InternalServerError).ToString();
                model.ErrorMessage = "Server Error";
            }

            return model;
        }

        // GET: api/Article/5
        public ArticleModel Get(string id)
        {
            var model = new ArticleModel();
            try
            {
                Guid Id;
                if (Guid.TryParse(id, out Id))
                {
                    var article = _articleServices.GetById(Id);
                    if (article == null)
                    {
                        model.Success = false;
                        model.ErrorCode = ((int)HttpStatusCode.NotFound).ToString();
                        model.ErrorMessage = "Record Not Found";
                    }
                    else
                    {
                        model.Success = true;
                        model.Article = article;
                    }
                }
                else
                {
                    model.Success = false;
                    model.ErrorCode = ((int)HttpStatusCode.BadRequest).ToString();
                    model.ErrorMessage = "Bad Request";
                }
            }
            catch
            {
                model.Success = false;
                model.ErrorCode = ((int)HttpStatusCode.InternalServerError).ToString();
                model.ErrorMessage = "Server Error";
            }

            return model;
        }

        // POST: api/Article
        public void Post([FromBody] ArticleModel article)
        {
            _articleServices.Insert(article.Article);
        }

        // PUT: api/Article/5
        public void Put(Guid id, [FromBody] ArticleModel article)
        {
            _articleServices.Update(article.Article);
        }

        // DELETE: api/Article/5
        public void Delete(Guid id)
        {
            _articleServices.Delete(id);
        }
    }
}
