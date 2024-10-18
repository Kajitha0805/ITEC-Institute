using a_zApi.DTO.RequestDto;
using a_zApi.DTO.ResponseDto;

namespace a_zApi.IServices
{
    public interface IFollowUpService
    {
        Task<FollowUpResponseDto> CreateFollowUp(FollowUpRequestDto followRequest);
        Task<FollowUpResponseDto> GetFollowUpById(string Name);
        Task<FollowUpResponseDto> DeleteFollowUpById(string Name);
        Task<List<FollowUpResponseDto>> GetAllFollowUps();
    }
}
