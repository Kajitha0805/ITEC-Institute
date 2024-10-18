using a_zApi.DTO.RequestDto;
using a_zApi.DTO.ResponseDto;

namespace a_zApi.IServices
{
    public interface IStudentRegisterService
    {
        StudentRegisterResponse AddStudentRegister(StudentRegisterRequest studentRegisterRequest);
        IEnumerable<StudentRegisterResponse> GetAllStudentRegister();
        StudentRegisterResponse GetStudentRegister(string nicNo);
        StudentRegisterResponse UpdateStudentRegisterResponse(string nicNo, StudentRegisterRequest requestDto);
        bool DeleteStudentRegister(string nicNo);
    }
}
