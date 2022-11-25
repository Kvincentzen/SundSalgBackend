using System.Linq.Expressions;
using SundSalgBackend.Contracts;
using SundSalgBackend.Models;

namespace SundSalgBackend.Data
{
    public class RepositoryManager : IRepositoryManager
    {
        private IdentityContext _identityContext;
        private ICounselorRepository _counselorRepository;
        private IProductRepository _productRepository;
        private IAccountRepository _accountRepository;
        public RepositoryManager(IdentityContext identityContext) 
        { 
            _identityContext = identityContext; 
        }
        public ICounselorRepository Counselor
        {
            get
            {
                if (_counselorRepository == null)
                {
                    _counselorRepository = new CounselorRepository(_identityContext);
                }
                return _counselorRepository;
            }
        }
        public IProductRepository Product
        {
            get
            {
                if (_productRepository == null)
                {
                    _productRepository = new ProductRepository(_identityContext);
                }
                return _productRepository;
            }
        }
        public IAccountRepository Account
        {
            get
            {
                if (_accountRepository == null)
                {
                    _accountRepository = new AccountRepository(_identityContext);
                }
                return _accountRepository;
            }
        }
        public void Save() => _identityContext.SaveChanges();
    }
}
