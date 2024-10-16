using a_zApi.IRepository;
using a_zApi.IServices;
using a_zApi.Repository;

namespace a_zApi.Services
{
    public class FollowUpService:IFollowUpService
    {
        private readonly IFollowUpRepository _ifollowUpRepository;
        public FollowUpService(IFollowUpRepository ifollowUpRepository)
        {
            _ifollowUpRepository = ifollowUpRepository;
        }
    }
}
