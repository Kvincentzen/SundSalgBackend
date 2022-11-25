using SundSalgBackend.Models;
using SundSalgBackend.Models.DataTransferObjects;

namespace SundSalgBackend.Contracts
{
    public interface ICounselorRepository : IRepositoryBase<Counselor>
    {
        IEnumerable<Counselor> GetAllCounselors(bool trackChanges);
        Counselor GetCounselorById(int counselorId, bool trackChanges);
        Counselor GetCounselorWithDetails(int counselorId, bool trackChanges);
        void CreateCounselor(Counselor counselor);
        void UpdateCounselor(Counselor counselor);
        void DeleteCounselor(Counselor counselor);
    }
}
