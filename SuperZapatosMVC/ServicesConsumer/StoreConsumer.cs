using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestSharp;
using RestSharp.Authenticators;
using AutoMapper;
using SuperZapatosMVC.Models;
using SuperZapatosMVC.ServicesConsumer.Contracts;
using StoreDTO = SuperZapatosDTO.Store;

namespace SuperZapatosMVC.ServicesConsumer
{
    public class StoreConsumer
    {
        RestClient _restClient;
        RestRequest _request;
        public StoreConsumer()
        {
            _restClient = new RestClient(ServiceULR.server);
            _restClient.Authenticator = new HttpBasicAuthenticator("my_user", "my_password");
            Mapper.CreateMap<StoreDTO, Store>();
            Mapper.CreateMap<StoresContract, IList<Store>>()
                .ConvertUsing<ConverterStores>();
        }

        public Store GetStore(Guid id)
        {
            _request = new RestRequest(Method.GET);
            _request.Resource = string.Format("{0}/{1}", ServiceULR.store, id);
            var response = _restClient.Execute<StoreContract>(_request);
            var result = Mapper.Map<Store>(response.Data.Store);
            return result;
        }

        public IList<Store> GetStores()
        {
            _request = new RestRequest(Method.GET);
            _request.Resource = ServiceULR.store;
            var response = _restClient.Execute<StoresContract>(_request);
            var data = Mapper.Map<StoresContract, List<Store>>(response.Data);
            return data;
        }

        public void InsertStore(StoreContract store)
        {
            _request = new RestRequest(ServiceULR.store, Method.POST) { RequestFormat = DataFormat.Json };
            _request.AddBody(store);
            var response = _restClient.Execute(_request);
        }

        public void UpdateStore(StoreContract store)
        {
            _request = new RestRequest(string.Format("{0}/{1}", ServiceULR.store, store.Store.Id),
                Method.PUT) { RequestFormat = DataFormat.Json };
            _request.AddBody(store);
            var response = _restClient.Execute(_request);
        }

        public void DeleteStore(Guid Id)
        {
            _request = new RestRequest(string.Format("{0}/{1}", ServiceULR.store, Id),
                Method.DELETE);
            var response = _restClient.Execute(_request);
        }
    }

    class ConverterStores : ITypeConverter<StoresContract, IList<Store>>
    {
        public IList<Store> Convert(ResolutionContext context)
        {
            IList<Store> result = new List<Store>();
            StoresContract storesContract = (StoresContract)context.SourceValue;
            if (storesContract != null && storesContract.Stores != null)
            {                
                storesContract.Stores.ForEach(x => result.Add(Mapper.Map<Store>(x)));
            }
            return result;
        }
    }
}