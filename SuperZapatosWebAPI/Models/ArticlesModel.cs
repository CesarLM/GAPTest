using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ArticleDTO = SuperZapatosDTO.Article;

namespace SuperZapatosWebAPI.Models
{
    public class ArticlesModel : SuccessBase
    {
        public IList<ArticleDTO> Articles { get; set; }
        public int TotalElements { get; set; }
    }
}