namespace SundSalgBackend.Contracts
{
    public interface IRepositoryManager
    {
        ICounselorRepository Counselor { get; }
        IProductRepository Product { get; }
        IAccountRepository Account { get; }
        void Save();
    }
}
