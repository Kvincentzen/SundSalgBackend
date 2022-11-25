using SundSalgBackend.Contracts;
using SundSalgBackend.Models;
using SundSalgBackend.Models.DataTransferObjects;

namespace SundSalgBackend.Data
{
    public class AccountRepository : RepositoryBase<User>, IAccountRepository
    {
        public AccountRepository(IdentityContext identityContext) : base(identityContext)
        {
        }

        public void DeleteAccount(User user)
        {
            throw new NotImplementedException();
        }

        public void UpdateAccount(User user)
        {
            Update(user);
            Save();
        }
    }
}
