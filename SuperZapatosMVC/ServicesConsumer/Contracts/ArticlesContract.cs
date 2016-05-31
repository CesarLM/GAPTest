using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ArticleDTO = SuperZapatosDTO.Article;

namespace SuperZapatosMVC.ServicesConsumer.Contracts
{
    public class ArticlesContract : SuccessBase
    {
        public List<ArticleDTO> Articles { get; set; }
        public int TotalElements { get; set; }
    }
}