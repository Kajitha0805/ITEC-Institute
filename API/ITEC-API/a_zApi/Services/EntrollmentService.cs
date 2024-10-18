using a_zApi.DTO.RequestDto;
using a_zApi.DTO.ResponseDto;
using a_zApi.Enitity;
using a_zApi.IRepository;
using a_zApi.IServices;
using a_zApi.Repository;

namespace a_zApi.Services
{
    public class EntrollmentService:IEntrollmentService
    {
        private readonly IEntrollmentRepository _ientrollmentRepository;
        public EntrollmentService(IEntrollmentRepository ientrollmentRepository)
        {
            _ientrollmentRepository = ientrollmentRepository; 
        }
        public async Task<Entrollment> CreateEntrollment(Entrollment entrollment)
        {
            var inputEntrollment = new Entrollment();
            inputEntrollment.EntrollmentID = entrollment.EntrollmentID;
            inputEntrollment.NicNo = entrollment.NicNo;
            inputEntrollment.CourseId = entrollment.CourseId;

            var addinputEntrollment = await _ientrollmentRepository.CreateEntrollment(inputEntrollment);

            var response = new Entrollment();
            response.EntrollmentID = inputEntrollment.EntrollmentID;
            response.NicNo = inputEntrollment.NicNo;
            response.CourseId = inputEntrollment.CourseId;
            return response;
        }
        public async Task<List<EntrollmentResponse>> GetAllEntrollment()
        {
            var data = await _ientrollmentRepository.GetAllentrollment();
            var response = new List<EntrollmentResponse>();
            foreach (var entroll in data)
            {
                var entrollmentResponse = new EntrollmentResponse();
                entrollmentResponse.EntrollmentID = entroll.EntrollmentID;
                entrollmentResponse.NicNo = entroll.NicNo;
                entrollmentResponse.CourseId = entroll.CourseId;
                
                response.Add(entrollmentResponse);
            }
            return response;
        }
        public async Task<EntrollmentResponse> GetEntrollment(string NicNo)
        {
            var data = await _ientrollmentRepository.GetEntrollment(NicNo);
            var response = new EntrollmentResponse();
            response.EntrollmentID = data.EntrollmentID;
            response.NicNo = data.NicNo;
            response.CourseId = data.CourseId;
            return response;

        }
        public async Task<EntrollmentResponse> DeleteEnrollmentById(string NicNo)
        {
            var data = await _ientrollmentRepository.GetEntrollment(NicNo);
            var response = new EntrollmentResponse();
            response.EntrollmentID = data.EntrollmentID;
            response.NicNo = data.NicNo;
            response.CourseId = data.CourseId;
            return response;
        }
        public async Task<EntrollmentResponse> UpdateEntrollment(string NicNo, EntrollmentRequest EntrollmentRequest)
        {
            var data = await _ientrollmentRepository.FindEntrollment(NicNo);
            if (data == null)
            {
                return null;
            }
            data.EntrollmentID = EntrollmentRequest.EntrollmentID;
            data.NicNo = EntrollmentRequest.NicNo;
            data.CourseId = EntrollmentRequest.CourseId;

            var UpdateEntrollment = await _ientrollmentRepository.UpdateEntrollment(data);
            if (UpdateEntrollment == null)
            {
                return null;
            }

            var response = new EntrollmentResponse
            {
                EntrollmentID = UpdateEntrollment.EntrollmentID,
                NicNo = UpdateEntrollment.NicNo,
                CourseId = UpdateEntrollment.CourseId,

            };
            return response;
        }
    }
}
