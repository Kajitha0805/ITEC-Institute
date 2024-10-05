using a_zApi.Enitity;

namespace a_zApi.IRepository
{
    public interface ICourseRepository
    {
        Task<Course> CreateCourse(Course course);
        Task<List<Course>> GetAllCourse();
        Task<Course> GetCourseById(string CourseId);
        Task<Course> DeleteCourseById(string CourseId);
        Task<Course> FindCourseById(string CourseId);
        Task<Course> UpdateCourse(Course course);
    }
}
