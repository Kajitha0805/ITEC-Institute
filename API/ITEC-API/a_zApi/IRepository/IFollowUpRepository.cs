using a_zApi.Enitity;

namespace a_zApi.IRepository
{
    public interface IFollowUpRepository
    {
        Task<FollowUp> CreateFollowUp(FollowUp followUp);
        Task<FollowUp> GetFollowUpById(string Name);
        Task<FollowUp> DeleteFollowUpById(string Name);
        Task<List<FollowUp>> GetAllFollowUp();
    }
}
