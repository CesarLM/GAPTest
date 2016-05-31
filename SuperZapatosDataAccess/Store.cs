using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using GAPRepository;
using StoreDTO = SuperZapatosDTO.Store;
using StoreModel = SuperZapatosDomainModel.Store;

namespace SuperZapatosDataAccess
{
    public class Store : IDataAccess<StoreDTO>
    {
         IUnitOfWork<SuperZapatosContext> _repository;

         public Store(IUnitOfWork<SuperZapatosContext> repository)
        {
            _repository = repository;
            Mapper.CreateMap<StoreModel, StoreDTO>();
            Mapper.CreateMap<StoreDTO, StoreModel>();
        }

        public StoreDTO GetById(Guid? id)
        {
            var article = _repository.StoreRepository.GetEntityById(id);
            StoreDTO StoreDTO = Mapper.Map<StoreModel, StoreDTO>(article);
            return StoreDTO;
        }

        public List<StoreDTO> Get()
        {
            List<StoreModel> StoreModelList = _repository.StoreRepository.GetListCollection().ToList<StoreModel>();
            List<StoreDTO> StoreDTOList = Mapper.Map<List<StoreModel>, List<StoreDTO>>(StoreModelList);
            return StoreDTOList;
        }

        public void Insert(StoreDTO StoreModelToInsertDTO)
        {
            StoreModel StoreModelToInsert = Mapper.Map<StoreDTO, StoreModel>(StoreModelToInsertDTO);
            _repository.StoreRepository.Insert(StoreModelToInsert);
            _repository.Commit();
        }

        public void Update(StoreDTO StoreModelToUpdateDTO)
        {
            StoreModel StoreModelToUpdate = Mapper.Map<StoreDTO, StoreModel>(StoreModelToUpdateDTO);
            _repository.StoreRepository.Update(StoreModelToUpdate, StoreModelToUpdate.Id);
            _repository.Commit();
        }

        public void Delete(Guid? id)
        {
            _repository.StoreRepository.Delete(id);
            _repository.Commit();
        }
    }
}
