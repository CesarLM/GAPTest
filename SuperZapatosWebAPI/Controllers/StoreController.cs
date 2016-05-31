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
using StoreDTO = SuperZapatosDTO.Store;

namespace SuperZapatosWebAPI.Controllers
{

    [BasicAuthenticationFilter]
    public class StoreController : ApiController
    {
        IUnitOfWork<SuperZapatosContext> _unitOfWork;
        IDataAccess<StoreDTO> _dataAccess;
        StoreBusiness _storeServices;

        public StoreController()
        {
            _unitOfWork = new UnitOfWork();
            _dataAccess = new Store(_unitOfWork);
            _storeServices = new StoreBusiness(_dataAccess);
        }

        // GET: api/Store
        public StoresModel Get()
        {
            var model = new StoresModel();
            try
            {
                var stores = _storeServices.Get();
                model.Success = true;
                model.Stores = stores;
                model.TotalElements = stores.Count;
            }
            catch
            {
                model.Success = false;
                model.ErrorCode = ((int)HttpStatusCode.InternalServerError).ToString();
                model.ErrorMessage = "Server Error";
            }
            return model;
        }

        // GET: api/Store/5
        public StoreModel Get(string id)
        {
            var model = new StoreModel();
            try
            {
                Guid Id;
                if (Guid.TryParse(id, out Id))
                {
                    var store = _storeServices.GetById(Id);
                    if (store == null)
                    {
                        model.Success = false;
                        model.ErrorCode = ((int)HttpStatusCode.NotFound).ToString();
                        model.ErrorMessage = "Record Not Found";
                    }
                    else
                    {
                        model.Success = true;
                        model.Store = store;
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

        // POST: api/Store
        public void Post([FromBody] StoreModel store)
        {
            _storeServices.Insert(store.Store);
        }

        // PUT: api/Store/5
        public void Put(Guid id, [FromBody] StoreModel store)
        {
            _storeServices.Update(store.Store);
        }

        // DELETE: api/Store/5
        public void Delete(Guid id)
        {
            _storeServices.Delete(id);
        }
    }
}
