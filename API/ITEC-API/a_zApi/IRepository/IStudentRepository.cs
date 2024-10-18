using a_zApi.Enitity;

namespace a_zApi.IRepository
{
    public interface IStudentRepository
    {
        Task<Student> CreateStudent(Student student);

        Task<List<Student>> GetAllStudent();
        Task<Student> GetStudentById(string NicNo);
        Task<Student> DeleteStudentById(string NicNo);
        Task<Student> FindStudentById(string NicNo);
        Task<Student> UpdateStudent(Student student);

    }
}
