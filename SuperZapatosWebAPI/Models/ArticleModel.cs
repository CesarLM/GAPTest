using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ArticleDTO = SuperZapatosDTO.Article;

namespace SuperZapatosWebAPI.Models
{
    public class ArticleModel : SuccessBase
    {
        public ArticleDTO Article { get; set; }
    }
}