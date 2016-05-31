using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestSharp;
using RestSharp.Authenticators;
using AutoMapper;
using SuperZapatosMVC.Models;
using SuperZapatosMVC.ServicesConsumer.Contracts;
using ArticleDTO = SuperZapatosDTO.Article;

namespace SuperZapatosMVC.ServicesConsumer
{
    public class ArticleConsumer
    {
        RestClient _restClient;
        RestRequest _request;
        public ArticleConsumer()
        {
            _restClient = new RestClient(ServiceULR.server);
            _restClient.Authenticator = new HttpBasicAuthenticator("my_user", "my_password");
            Mapper.CreateMap<ArticleDTO, Article>();
            Mapper.CreateMap<ArticlesContract, IList<Article>>()
                .ConvertUsing<ConverterArticles>();
        }

        public Article GetArticle(Guid id)
        {
            _request = new RestRequest(Method.GET);
            _request.Resource = string.Format("{0}/{1}", ServiceULR.article, id);
            var response = _restClient.Execute<ArticleContract>(_request);
            var result = Mapper.Map<Article>(response.Data.Article);
            return result;
        }

        public IList<Article> GetArticles()
        {
            _request = new RestRequest(Method.GET);
            _request.Resource = ServiceULR.article;
            var response = _restClient.Execute<ArticlesContract>(_request);
            var data = Mapper.Map<ArticlesContract, List<Article>>(response.Data);
            return data;
        }

        public void InsertArticle(ArticleContract store)
        {
            _request = new RestRequest(ServiceULR.article, Method.POST) { RequestFormat = DataFormat.Json };
            _request.AddBody(store);
            var response = _restClient.Execute(_request);
        }

        public void UpdateArticle(ArticleContract store)
        {
            _request = new RestRequest(string.Format("{0}/{1}", ServiceULR.article, store.Article.Id),
                Method.PUT) { RequestFormat = DataFormat.Json };
            _request.AddBody(store);
            var response = _restClient.Execute(_request);
        }

        public void DeleteArticle(Guid Id)
        {
            _request = new RestRequest(string.Format("{0}/{1}", ServiceULR.article, Id),
                Method.DELETE);
            var response = _restClient.Execute(_request);
        }
    }

    class ConverterArticles : ITypeConverter<ArticlesContract, IList<Article>>
    {
        public IList<Article> Convert(ResolutionContext context)
        {
            ArticlesContract articleContract = (ArticlesContract)context.SourceValue;
            IList<Article> result = new List<Article>();
            if (articleContract != null)
            {
                articleContract.Articles.ForEach(x => result.Add(Mapper.Map<Article>(x)));
            }
            return result;
        }
    }
}