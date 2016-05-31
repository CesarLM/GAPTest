using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using SuperZapatosDataAccess;
using ArticleDTO = SuperZapatosDTO.Article;

namespace SuperZapatosBusiness
{

    public class ArticleBusiness : Base
    {
        private IDataAccess<ArticleDTO> _articleDataAccess;
        public ArticleBusiness(IDataAccess<ArticleDTO> storeDataAccess)
        {
            _articleDataAccess = storeDataAccess;
        }

        public ArticleDTO GetById(Guid id)
        {
            try
            {
                ArticleDTO store = _articleDataAccess.GetById(id);
                return store;
            }
            catch (Exception ex)
            {
                BuildErrorMessage(ex);
                return null;
            }
        }

        public IList<ArticleDTO> Get(Expression<Func<ArticleDTO, bool>> filter = null, string includeProperties = "")
        {
            try
            {
                List<ArticleDTO> list = _articleDataAccess.Get();
                InfoMessage = "List of ArticleDTO retrieved !";
                return list;
            }
            catch (Exception ex)
            {
                BuildErrorMessage(ex);
                return null;
            }
        }

        public void Insert(ArticleDTO insert)
        {
            try
            {
                if (!this.Validate(insert))
                {
                    Exception ex = new Exception("Insert of new article did not pass business logic validation, please check validationerrors for more info !");
                    ex.Source = string.Format("{0}.{1}", this.GetType().AssemblyQualifiedName, this.GetType().Name);
                    BuildErrorMessage(ex);
                }
                else
                {
                    _articleDataAccess.Insert(insert);
                }
            }
            catch (Exception ex)
            {
                BuildErrorMessage(ex);
            }
        }

        public void Update(ArticleDTO entityToUpdate)
        {
            try
            {
                if (!this.Validate(entityToUpdate))
                {
                    Exception ex = new Exception("Update of existing article did not pass business logic validation, please check validationerrors for more info !");
                    ex.Source = string.Format("{0}.{1}", this.GetType().AssemblyQualifiedName, this.GetType().Name);
                    BuildErrorMessage(ex);
                }
                else
                {
                    _articleDataAccess.Update(entityToUpdate);
                }
            }
            catch (Exception ex)
            {
                BuildErrorMessage(ex);
            }
        }

        public void Delete(Guid id)
        {
            try
            {
                _articleDataAccess.Delete(id);
            }
            catch (Exception ex)
            {
                BuildErrorMessage(ex);
            }
        }

        public bool Validate(ArticleDTO entityToValidate)
        {
            if (String.IsNullOrEmpty(entityToValidate.Name))
                return false;
            return true;
        }
    }
}
