using a_zApi.DTO.RequestDto;
using a_zApi.DTO.ResponseDto;

namespace a_zApi.IServices
{
    public interface IFeeServices
    {
        Task<FeeResponse> CreateFee(FeeRequest feeRequest);
        Task<List<FeeResponse>> GetAllFee();
        Task<FeeResponse> GetStudentById(string StudentId);
        Task<FeeResponse> DeleteFeeById(string StudentId);
        Task<FeeResponse> UpdateStudent(string StudentId, FeeRequest feeRequest);
        Task GetFeeById(string studentId);
    }
}
