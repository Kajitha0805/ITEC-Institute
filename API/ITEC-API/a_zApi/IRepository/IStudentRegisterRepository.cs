using a_zApi.Enitity;

namespace a_zApi.IRepository
{
    public interface IStudentRegisterRepository
    {
        void AddStudentRegister(StudentRegister studentRegister);
        StudentRegister GetStudentRegisterByNIC(string nicNo);
        IEnumerable<StudentRegister> GetAllStudentRegister();
        void UpdateStudentRegister(StudentRegister studentRegister);
        void DeleteStudentRegister(string nicNo);
    }
}
