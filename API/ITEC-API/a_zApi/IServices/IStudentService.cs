using a_zApi.DTO.RequestDto;
using a_zApi.DTO.ResponseDto;
using a_zApi.Enitity;

namespace a_zApi.IServices
{
    public interface IStudentService
    {
        Task<StudentResponse> CreateStudent(StudentRequest studentRequest);
        Task<List<StudentResponse>> GetAllStudent();
        Task<StudentResponse> GetStudentById(string NicNo);
        Task<StudentResponse> DeleteStudentById(string NicNo);
        Task<StudentResponse> UpdateStudent(string NicNo, StudentRequest studentRequest);
    }
}

