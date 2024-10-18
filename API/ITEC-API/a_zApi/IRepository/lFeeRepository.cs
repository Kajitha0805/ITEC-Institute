using a_zApi.Enitity;

namespace a_zApi.IRepository
{
    public interface lFeeRepository
    {
        Task<Fee> CreateFee(Fee fee);
        Task<List<Fee>> GetAllFee();
        Task<Fee> GetFeeById(string StudentId);
        Task<Fee> DeleteFeeById(string StudentId);
        Task<Fee> FindFeeById(string StudentId);
        Task<Fee> UpdateFee(Fee fee);
    }
}
