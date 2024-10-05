using a_zApi.Enitity;

namespace a_zApi.IRepository
{
    public interface IStudentRepository
    {
        Task<Student> CreateStudent(Student student);
        Task<List<Student>> GetAllStudent();
        Task<Student> GetStudentById(Guid StudentId);
        Task<Student> DeleteStudentById(Guid StudentId);
        Task<Student> FindStudentById(Guid StudentId);
        Task<Student> UpdateStudent(Student student);

    }
}
