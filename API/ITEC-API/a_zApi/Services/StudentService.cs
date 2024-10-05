using a_zApi.DTO.RequestDto;
using a_zApi.DTO.ResponseDto;
using a_zApi.Enitity;
using a_zApi.IRepository;
using a_zApi.IServices;

namespace a_zApi.Services
{
    public class StudentService:IStudentService
    {
        private readonly IStudentRepository _istudentRepository;
        public StudentService(IStudentRepository istudentRepository)
        {
            _istudentRepository = istudentRepository;
        }
        public async Task<StudentResponse>CreateStudent(StudentRequest studentRequest)
        {
            var inputStudent = new Student();
            inputStudent.FirstName = studentRequest.FirstName;
            inputStudent.LastName = studentRequest.LastName;
            inputStudent.BOD = studentRequest.BOD;
            inputStudent.NicNumber = studentRequest.NicNumber;
            inputStudent.Age = studentRequest.Age;
            inputStudent.Gender = studentRequest.Gender;
            inputStudent.TelNumber = studentRequest.TelNumber;

            var addinputStudent=await _istudentRepository.CreateStudent(inputStudent);

            var response=new StudentResponse();
            response.StudentId = addinputStudent.StudentId;
            response.FirstName = addinputStudent.FirstName;
            response.LastName = addinputStudent.LastName;
            response.BOD = addinputStudent.BOD;
            response.NicNumber=addinputStudent.NicNumber;
            response.Age = addinputStudent.Age;
            response.Gender = addinputStudent.Gender;
            response.TelNumber = addinputStudent.TelNumber;
            return response;
        }

        public async Task<List<StudentResponse>>GetAllStudent()
        {
            var data=await _istudentRepository.GetAllStudent();
            var response=new List<StudentResponse>();
            foreach (var student in data)
            {
                var res=new StudentResponse();
                res.StudentId = student.StudentId;
                res.FirstName=student.FirstName;
                res.LastName=student.LastName;
                res.BOD=student.BOD;
                res.NicNumber = student.NicNumber;
                res.Age = student.Age;
                res.Gender = student.Gender;
                res.TelNumber = student.TelNumber;
                response.Add(res);
            }
            return response;
        }
        public async Task<StudentResponse>GetStudentById(Guid StudentId)
        {
            var data=await _istudentRepository.GetStudentById(StudentId);
            var response=new StudentResponse();
            response.StudentId = data.StudentId;
            response.FirstName=data.FirstName;
            response.LastName=data.LastName;
            response.BOD=data.BOD;
            response.NicNumber=data.NicNumber;
            response.Age=data.Age;
            response.Gender=data.Gender;
            response.TelNumber=data.TelNumber;
            return response;

        }
        public async Task<StudentResponse>DeleteStudentById(Guid StudentId)
        {
            var data=await _istudentRepository.DeleteStudentById(StudentId);
            var response=new StudentResponse();
            response.StudentId = data.StudentId;
            response.FirstName=data.FirstName;
            response.LastName=data.LastName;
            response.BOD=data.BOD;
            response.NicNumber = data.NicNumber;
            response.Age=data.Age;
            response.Gender=data.Gender;
            response.TelNumber=data.TelNumber;
            return response;
        }
        public async Task<StudentResponse>UpdateStudent(Guid StudentId, StudentRequest studentRequest)
        {
            var data=await _istudentRepository.FindStudentById(StudentId);
            if (data==null)
            {
                return null;
            }
            data.FirstName=studentRequest.FirstName;
            data.LastName=studentRequest.LastName;
            data.BOD=studentRequest.BOD;
            data.NicNumber=studentRequest.NicNumber;
            data.Age=studentRequest.Age;
            data.Gender=studentRequest.Gender;
            data.TelNumber=studentRequest.TelNumber;

            var updatedStudent=await _istudentRepository.UpdateStudent(data);
            if (updatedStudent==null)
            {
                return null;
            }

            var response = new StudentResponse
            {
                StudentId = updatedStudent.StudentId,
                FirstName=updatedStudent.FirstName,
                LastName=updatedStudent.LastName,
                BOD=updatedStudent.BOD,
                NicNumber=updatedStudent.NicNumber,
                Age=updatedStudent.Age,
                Gender=updatedStudent.Gender,
                TelNumber=updatedStudent.TelNumber,
            };
            return response;
        }
    }
}
