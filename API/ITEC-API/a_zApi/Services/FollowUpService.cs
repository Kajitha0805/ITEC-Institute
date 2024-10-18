using a_zApi.DTO.RequestDto;
using a_zApi.DTO.ResponseDto;
using a_zApi.Enitity;
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

        public async Task<FollowUpResponseDto> CreateFollowUp(FollowUpRequestDto followRequest)
        {
            var inputFollowUp = new FollowUp();
            inputFollowUp.Name = followRequest.Name;
            inputFollowUp.Moblie = followRequest.Moblie;
            inputFollowUp.CourseId = followRequest.CourseId;
            inputFollowUp.Date = followRequest.Date;
            inputFollowUp.Email = followRequest.Email;
            inputFollowUp.Address = followRequest.Address;
            inputFollowUp.Description = followRequest.Description;

            var addedFollowUps = await _ifollowUpRepository.CreateFollowUp(inputFollowUp);

            var response = new FollowUpResponseDto();
            response.Name = addedFollowUps.Name;
            response.Moblie = addedFollowUps.Moblie;
            response.CourseId = addedFollowUps.CourseId;
            response.Date = addedFollowUps.Date;
            response.Email = addedFollowUps.Email;
            response.Address = addedFollowUps.Address;
            response.Description = addedFollowUps.Description;

            return response;

        }
        public async Task<FollowUpResponseDto> GetFollowUpById(string Name)
        {
            var data = await _ifollowUpRepository.GetFollowUpById(Name);
            var response = new FollowUpResponseDto();
            response.Name = data.Name;
            response.Moblie = data.Moblie;
            response.CourseId = data.CourseId;
            response.Date = data.Date;
            response.Email = data.Email;
            response.Address = data.Address;
            response.Description = data.Description;
            return response;
        }
        public async Task<FollowUpResponseDto> DeleteFollowUpById(string Name)
        {
            var data = await _ifollowUpRepository.DeleteFollowUpById(Name);
            var response = new FollowUpResponseDto();
            response.Name = data.Name;
            response.Moblie = data.Moblie;
            response.CourseId = data.CourseId;
            response.Date = data.Date;
            response.Email = data.Email;
            response.Address = data.Address;
            response.Description = data.Description;
            return response;

        }
        public async Task<List<FollowUpResponseDto>> GetAllFollowUps()
        {
            var data = await _ifollowUpRepository.GetAllFollowUp();
            var response = new List<FollowUpResponseDto>();
            foreach (var course in data)
            {
                var followResponse = new FollowUpResponseDto();
                followResponse.Name = course.Name;
                followResponse.Moblie = course.Moblie;
                followResponse.CourseId = course.CourseId;
                followResponse.Date = course.Date;
                followResponse.Email = course.Email;
                followResponse.Address = course.Address;
                followResponse.Description = course.Description;
                response.Add(followResponse);
            }
            return response;
        }
    }
}
