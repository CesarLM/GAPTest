using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GAPRepository;
using SuperZapatosDomainModel;
using ArticleModel = SuperZapatosDomainModel.Article;
using StoreModel = SuperZapatosDomainModel.Store;

namespace SuperZapatosDataAccess
{
    public interface IUnitOfWork<TDBContext> : IDisposable
    {
        IGenericRepository<ArticleModel, TDBContext> ArticleRepository { get; }
        IGenericRepository<StoreModel, TDBContext> StoreRepository { get; }
        void Commit();
        void RollBack();
    }
}
