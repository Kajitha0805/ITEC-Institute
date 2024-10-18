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
            inputStudent.NicNo = studentRequest.NicNo;
            inputStudent.FirstName = studentRequest.FirstName;
            inputStudent.LastName = studentRequest.LastName;
            inputStudent.CourseId = studentRequest.CourseId;
            inputStudent.Batch = studentRequest.Batch;
            inputStudent.Date = studentRequest.Date;
            inputStudent.MobileNo = studentRequest.MobileNo;
            inputStudent.Email = studentRequest.Email;
            inputStudent.Address = studentRequest.Address;
            inputStudent.RegFee = studentRequest.RegFee;
            inputStudent.AdditionalFee = studentRequest.AdditionalFee;

            var addinputStudent=await _istudentRepository.CreateStudent(inputStudent);

            var response=new StudentResponse();
            response.NicNo=inputStudent.NicNo;
            response.FirstName=inputStudent.FirstName;
            response.LastName=inputStudent.LastName;
            response.CourseId=inputStudent.CourseId;
            response.Batch=inputStudent.Batch;
            response.Date = studentRequest.Date;
            response.MobileNo=inputStudent.MobileNo;
            response.Email=studentRequest.Email;
            response.Address=studentRequest.Address;
            response.RegFee=studentRequest.RegFee;
            response.AdditionalFee=studentRequest.AdditionalFee;
            return response;
        }

        //01

        public async Task<List<StudentResponse>>GetAllStudent()
        {
            var data=await _istudentRepository.GetAllStudent();
            var response=new List<StudentResponse>();
            foreach (var student in data)
            {
                var res=new StudentResponse();
               res.NicNo = student.NicNo;
                res.FirstName=student.FirstName;
                res.LastName=student.LastName;
                res.CourseId=student.CourseId;
                res.Batch=student.Batch;
                res.Date=student.Date;
                res.MobileNo=student.MobileNo;
                res.Email=student.Email;
                res.Address=student.Address;
                res.RegFee=student.RegFee;
                res.AdditionalFee=student.AdditionalFee;
                response.Add(res);
            }
            return response;
        }
        //02
        public async Task<StudentResponse>GetStudentById(string NicNo)
        {
            var data=await _istudentRepository.GetStudentById(NicNo);
            var response=new StudentResponse();
            response.NicNo=data.NicNo;
            response.FirstName=data.FirstName;
            response.LastName=data.LastName;
            response.CourseId=data.CourseId;
            response.Batch=data.Batch;
            response.Date=data.Date;
            response.MobileNo=data.MobileNo;
            response.Email=data.Email;
            response.Address=data.Address;
            response.RegFee=data.RegFee;
            response.AdditionalFee=data.AdditionalFee;
            return response;

        }
        //03
        public async Task<StudentResponse>DeleteStudentById(string NicNo)
        {
            var data=await _istudentRepository.DeleteStudentById(NicNo);
            var response=new StudentResponse();
            response.NicNo = data.NicNo;
            response.FirstName=data.FirstName;
            response.LastName=data.LastName;
            response.CourseId=data.CourseId;
            response.Batch=data.Batch;
            response.Date=data.Date;
            response.MobileNo=data.MobileNo;
            response.Email=data.Email;
            response.Address=data.Address;
            response.RegFee=data.RegFee;
            response.AdditionalFee=data.AdditionalFee;
            return response;
        }
        public async Task<StudentResponse>UpdateStudent(string NicNo, StudentRequest studentRequest)
        {
            var data=await _istudentRepository.FindStudentById(NicNo);
            if (data==null)
            {
                return null;
            }
            data.NicNo=studentRequest.NicNo;
            data.FirstName=studentRequest.FirstName;
            data.LastName=studentRequest.LastName;
            data.CourseId=studentRequest.CourseId;
            data.Batch=studentRequest.Batch;
            data.Date=studentRequest.Date;
            data.MobileNo=studentRequest.MobileNo;
            data.Email=studentRequest.Email;
            data.Address=studentRequest.Address;
            data.RegFee=studentRequest.RegFee;
            data.AdditionalFee=studentRequest.AdditionalFee;

            var updatedStudent=await _istudentRepository.UpdateStudent(data);
            if (updatedStudent==null)
            {
                return null;
            }

            var response = new StudentResponse
            {
                NicNo=updatedStudent.NicNo,
                FirstName=updatedStudent.FirstName,
                LastName=updatedStudent.LastName,
                CourseId=updatedStudent.CourseId,
                Batch=updatedStudent.Batch,
                Date=updatedStudent.Date,
                MobileNo=updatedStudent.MobileNo,
                Email=updatedStudent.Email,
                Address=updatedStudent.Address,
                RegFee=updatedStudent.RegFee,
                AdditionalFee=updatedStudent.AdditionalFee,

            };
            return response;
        }
    }
}
