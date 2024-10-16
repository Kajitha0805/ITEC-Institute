using a_zApi.Enitity;
using a_zApi.IRepository;

namespace a_zApi.Repository
{
    public class FollowUpRepository:IFollowUpRepository
    {

        private readonly string _connectionString;

        public FollowUpRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
       
    }
}
