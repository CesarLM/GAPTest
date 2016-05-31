using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using GAPRepository;
using SuperZapatosDomainModel;
using ArticleModel = SuperZapatosDomainModel.Article;
using StoreModel = SuperZapatosDomainModel.Store;


namespace SuperZapatosDataAccess
{

    public partial class UnitOfWork : IUnitOfWork<SuperZapatosContext>
    {
        private bool _disposed = false;
        private SuperZapatosContext _context;

        private GenericRepository<StoreModel, SuperZapatosContext> _storeRepository;
        private GenericRepository<ArticleModel, SuperZapatosContext> _articleRepository;

        public IGenericRepository<StoreModel, SuperZapatosContext> StoreRepository
        {
            get
            {
                if (_storeRepository == null)
                {
                    _storeRepository = new GenericRepository<StoreModel, SuperZapatosContext>(_context);
                }
                return _storeRepository;
            }
        }

        public IGenericRepository<ArticleModel, SuperZapatosContext> ArticleRepository
        {
            get
            {
                if (_articleRepository == null)
                {
                    _articleRepository = new GenericRepository<ArticleModel, SuperZapatosContext>(_context);
                }
                return _articleRepository;
            }
        }

        public UnitOfWork()
        {
            _context = new SuperZapatosContext();
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void RollBack()
        {
            throw new NotImplementedException();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
