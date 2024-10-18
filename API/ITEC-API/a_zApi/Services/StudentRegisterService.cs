using a_zApi.DTO.RequestDto;
using a_zApi.DTO.ResponseDto;
using a_zApi.Enitity;
using a_zApi.IRepository;
using a_zApi.IServices;
using a_zApi.Repository;

namespace a_zApi.Services
{
    public class StudentRegisterService : IStudentRegisterService
    {
        private IStudentRegisterRepository _studentRegisterRepository;

        public StudentRegisterService(IStudentRegisterRepository studentRegisterRepository)
        {
            _studentRegisterRepository = studentRegisterRepository;
        }

        public StudentRegisterResponse AddStudentRegister(StudentRegisterRequest studentRegisterRequest)
        {
            var studentRegister = new StudentRegister
            {
                NICNo = studentRegisterRequest.NICNo,
                FirstName = studentRegisterRequest.FirstName,
                LastName = studentRegisterRequest.LastName,
                MobileNo = studentRegisterRequest.MobileNo,
                EmailId = studentRegisterRequest.EmailId,
                Address = studentRegisterRequest.Address,
                Password = studentRegisterRequest.Password
            };

            _studentRegisterRepository.AddStudentRegister(studentRegister);

            return new StudentRegisterResponse
            {
                NICNo = studentRegister.NICNo,
                FirstName = studentRegister.FirstName,
                LastName = studentRegister.LastName,
                MobileNo = studentRegister.MobileNo,
                EmailId = studentRegister.EmailId,
                Address = studentRegister.Address,
                Message = "StudentRegister added successfully!"
            };
        }

        public StudentRegisterResponse GetStudentRegister(string nicNo)
        {
            var studentRegister = _studentRegisterRepository.GetStudentRegisterByNIC(nicNo);
            if (studentRegister == null)
            {
                return null;
            }

            return new StudentRegisterResponse
            {
                NICNo = studentRegister.NICNo,
                FirstName = studentRegister.FirstName,
                LastName = studentRegister.LastName,
                MobileNo = studentRegister.MobileNo,
                EmailId = studentRegister.EmailId,
                Address = studentRegister.Address,
                Message = "StudentRegister retrieved successfully!"
            };
        }


        public StudentRegisterResponse UpdateStudentRegisterResponse(string nicNo, StudentRegisterRequest requestDto)
        {
            var existingStudentRegister = _studentRegisterRepository.GetStudentRegisterByNIC(nicNo);
            if (existingStudentRegister == null)
            {
                return null;
            }

            var StudentRegisterToUpdate = new StudentRegister
            {
                NICNo = nicNo,
                FirstName = requestDto.FirstName,
                LastName = requestDto.LastName,
                MobileNo = requestDto.MobileNo,
                EmailId = requestDto.EmailId,
                Address = requestDto.Address,
                Password = requestDto.Password
            };

            _studentRegisterRepository.UpdateStudentRegister(StudentRegisterToUpdate);

            return new StudentRegisterResponse
            {
                NICNo = StudentRegisterToUpdate.NICNo,
                FirstName = StudentRegisterToUpdate.FirstName,
                LastName = StudentRegisterToUpdate.LastName,
                MobileNo = StudentRegisterToUpdate.MobileNo,
                EmailId = StudentRegisterToUpdate.EmailId,
                Address = StudentRegisterToUpdate.Address,
                Message = "StudentRegister updated successfully!"
            };
        }


        public bool DeleteStudentRegister(string nicNo)
        {
            var existingStudentRegister = _studentRegisterRepository.GetStudentRegisterByNIC(nicNo);
            if (existingStudentRegister == null)
            {
                return false;
            }

            _studentRegisterRepository.DeleteStudentRegister(nicNo);
            return true;
        }

        public IEnumerable<StudentRegisterResponse> GetAllStudentRegister()
        {
            throw new NotImplementedException();
        }
    }
}

