using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using GAPRepository;
using ArticleDTO = SuperZapatosDTO.Article;
using ArticleModel = SuperZapatosDomainModel.Article;

namespace SuperZapatosDataAccess
{
    public class Article : IDataAccess<ArticleDTO>
    {
        IUnitOfWork<SuperZapatosContext> _repository;

        public Article(IUnitOfWork<SuperZapatosContext> repositoryService)
        {
            _repository = repositoryService;
            Mapper.CreateMap<ArticleModel, ArticleDTO>();
            Mapper.CreateMap<ArticleDTO, ArticleModel>();
        }

        public ArticleDTO GetById(Guid? id)
        {
            var article = _repository.ArticleRepository.GetEntityById(id);
            ArticleDTO ArticleDTO = Mapper.Map<ArticleModel, ArticleDTO>(article);
            return ArticleDTO;
        }

        public List<ArticleDTO> Get()
        {
            List<ArticleModel> ArticleModelList = _repository.ArticleRepository.GetListCollection().ToList<ArticleModel>();
            List<ArticleDTO> ArticleDTOList = Mapper.Map<List<ArticleModel>, List<ArticleDTO>>(ArticleModelList);
            return ArticleDTOList;
        }

        public void Insert(ArticleDTO ArticleModelToInsertDTO)
        {
            ArticleModel ArticleModelToInsert = Mapper.Map<ArticleDTO, ArticleModel>(ArticleModelToInsertDTO);
            _repository.ArticleRepository.Insert(ArticleModelToInsert);
            _repository.Commit();
        }

        public void Update(ArticleDTO ArticleModelToUpdateDTO)
        {
            ArticleModel ArticleModelToUpdate = Mapper.Map<ArticleDTO, ArticleModel>(ArticleModelToUpdateDTO);
            _repository.ArticleRepository.Update(ArticleModelToUpdate, ArticleModelToUpdate.Id);
            _repository.Commit();
        }

        public void Delete(Guid? id)
        {
            _repository.ArticleRepository.Delete(id);
            _repository.Commit();
        }
    }
}
