using a_zApi.DTO.RequestDto;
using a_zApi.DTO.ResponseDto;
using a_zApi.Enitity;
using a_zApi.IRepository;
using a_zApi.IServices;

namespace a_zApi.Services
{
    public class CourseService:ICourseService
    {
        private readonly ICourseRepository _icourseRepository;
        public CourseService(ICourseRepository icourseRepository)
        {
            _icourseRepository = icourseRepository;
        }
        public async Task CreateCourse(CourseRequest courseRequest)
        {
            var inputCourse = new Course();
            inputCourse.CourseId = courseRequest.CourseId;
            inputCourse.CourseName = courseRequest.CourseName;
            if (courseRequest.CourseImage != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await courseRequest.CourseImage.CopyToAsync(memoryStream);
                    inputCourse.CourseImage = memoryStream.ToArray();
                }
        }
        inputCourse.Duration = courseRequest.Duration;
            inputCourse.Fee = courseRequest.Fee;
            inputCourse.Instructor = courseRequest.Instructor;
            inputCourse.Syllabus = courseRequest.Syllabus;

            await _icourseRepository.CreateCourse(inputCourse);

        }
        public async Task<List<CourseResponse>>GetAllCourses()
        {
            var data=await _icourseRepository.GetAllCourse();
            var response= new List<CourseResponse>();
            foreach (var course in data)
            {
                var courseResponse = new CourseResponse();
                courseResponse.CourseId =course.CourseId;
                courseResponse.CourseName=course.CourseName;
                courseResponse.CourseImage = course.CourseImage;
                courseResponse.Duration=course.Duration;
                courseResponse.Fee=course.Fee;
                courseResponse.Instructor =course.Instructor;
                courseResponse.Syllabus =course.Syllabus;
                response.Add(courseResponse);
            }
            return response;
        }
        public async Task<CourseResponse>GetCourseById(string CourseId)
        {
            var data=await _icourseRepository.GetCourseById(CourseId);
            var response=new CourseResponse();
            response.CourseId=data.CourseId;
            response.CourseName =data.CourseName;
            response.Duration =data.Duration;
            response.Fee=data.Fee;
            response.Instructor=data.Instructor;
            response.Syllabus=data.Syllabus;
            return response;
        }
        public async Task<CourseResponse>DeleteCourseById(string CourseId)
        {
            var data=await _icourseRepository.DeleteCourseById(CourseId);
            var response=new CourseResponse();
            response.CourseId=data.CourseId;
            response.CourseName =data.CourseName;
            response.Duration =data.Duration;
            response.Fee=data.Fee;
            response.Instructor =data.Instructor;
            response.Syllabus =data.Syllabus;
            return response;

        }
        public async Task<CourseResponse>UpdateCourse(string CourseId, CourseRequest courseRequest)
        {
            var data = await _icourseRepository.FindCourseById(CourseId);
            if (data==null)
            {
                return null;
            }
            data.CourseId=courseRequest.CourseId;
            data.CourseName=courseRequest.CourseName;
            data.Duration=courseRequest.Duration;
            data.Fee=courseRequest.Fee;
            data.Instructor =courseRequest.Instructor;
            data.Syllabus =courseRequest.Syllabus;

            var updatedCourse=await _icourseRepository.UpdateCourse(data);
            var response=new CourseResponse();  

            response.CourseId = updatedCourse.CourseId;
            response.CourseName=updatedCourse.CourseName;
            response.Duration=updatedCourse.Duration;
            response.Fee=updatedCourse.Fee;
            response.Instructor=updatedCourse.Instructor;
            response.Syllabus=updatedCourse.Syllabus;
            return response;
        }
    }
}
