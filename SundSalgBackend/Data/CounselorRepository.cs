using SundSalgBackend.Contracts;
using SundSalgBackend.Models;

namespace SundSalgBackend.Data
{
    public class CounselorRepository : RepositoryBase<Counselor>, ICounselorRepository
    {
        public CounselorRepository(IdentityContext identityContext)
            : base(identityContext)
        {
        }
        public IEnumerable<Counselor> GetAllCounselors(bool trackChanges)
        {
            return FindAll(trackChanges)
                .OrderBy(ow => ow.Id)
                .ToList();
        }
        public Counselor GetCounselorById(int counselorId, bool trackChanges)
        {
            return FindByCondition(counselor => counselor.Id.Equals(counselorId), trackChanges)
                .FirstOrDefault();
        }

        public Counselor GetCounselorWithDetails(int counselorId, bool trackChanges)
        {
            return FindByCondition(counselor => counselor.Id.Equals(counselorId), trackChanges)
                .FirstOrDefault();
        }

        public void CreateCounselor(Counselor counselor) => Create(counselor);

        public void UpdateCounselor(Counselor counselor) => Update(counselor);

        public void DeleteCounselor(Counselor counselor) => Delete(counselor);
    }
}
