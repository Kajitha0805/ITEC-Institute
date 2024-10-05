using a_zApi.DTO.RequestDto;
using a_zApi.DTO.ResponseDto;

namespace a_zApi.IServices
{
    public interface IStudentService
    {
        Task<StudentResponse> CreateStudent(StudentRequest studentRequest);
        Task<List<StudentResponse>> GetAllStudent();
        Task<StudentResponse> GetStudentById(Guid StudentId);
        Task<StudentResponse> DeleteStudentById(Guid StudentId);
        Task<StudentResponse> UpdateStudent(Guid StudentId, StudentRequest studentRequest);
    }
}
