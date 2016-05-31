using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using SuperZapatosDataAccess;
using StoreDTO = SuperZapatosDTO.Store;

namespace SuperZapatosBusiness
{
    public class StoreBusiness : Base
    {
        private IDataAccess<StoreDTO> _storeDataAccess;
        public StoreBusiness(IDataAccess<StoreDTO> storeDataAccess)
        {
            _storeDataAccess = storeDataAccess;
        }
        
        public StoreDTO GetById(Guid id)
        {
            try
            {
                StoreDTO store = _storeDataAccess.GetById(id);
                return store;
            }
            catch (Exception ex)
            {
                BuildErrorMessage(ex);
                return null;
            }
        }

        public IList<StoreDTO> Get(Expression<Func<StoreDTO, bool>> filter = null, string includeProperties = "")
        {
            try
            {
                List<StoreDTO> list = _storeDataAccess.Get();
                InfoMessage = "List of StoreDTO retrieved !";
                return list;
            }
            catch (Exception ex)
            {
                BuildErrorMessage(ex);
                return null;
            }
        }

        public void Insert(StoreDTO insert)
        {
            try
            {
                if (!this.Validate(insert))
                {
                    Exception ex = new Exception("Insert of new store did not pass business logic validation, please check validationerrors for more info !");
                    ex.Source = string.Format("{0}.{1}", this.GetType().AssemblyQualifiedName, this.GetType().Name);
                    BuildErrorMessage(ex);
                }
                else
                {
                    _storeDataAccess.Insert(insert);
                }
            }
            catch (Exception ex)
            {
                BuildErrorMessage(ex);
            }
        }

        public void Update(StoreDTO entityToUpdate)
        {
            try
            {
                if (!this.Validate(entityToUpdate))
                {
                    Exception ex = new Exception("Update of store did not pass business logic validation, please check validationerrors for more info !");
                    ex.Source = string.Format("{0}.{1}", this.GetType().AssemblyQualifiedName, this.GetType().Name);
                    BuildErrorMessage(ex);
                }
                else
                {
                    _storeDataAccess.Update(entityToUpdate);
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
                _storeDataAccess.Delete(id);
            }
            catch (Exception ex)
            {
                BuildErrorMessage(ex);
            }
        }

        public bool Validate(StoreDTO entityToValidate)
        {
            if (String.IsNullOrEmpty(entityToValidate.Name))
                return false;
            return true;
        }
    }
}
