using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ArticleDTO = SuperZapatosDTO.Article;

namespace SuperZapatosMVC.ServicesConsumer.Contracts
{
    public class ArticleContract : SuccessBase
    {
        public ArticleDTO Article { get; set; }
    }
}