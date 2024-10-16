using a_zApi.DTO.RequestDto;
using a_zApi.DTO.ResponseDto;
using a_zApi.Enitity;
using Microsoft.AspNetCore.Mvc;

namespace a_zApi.IServices
{
    public interface IEntrollmentService
    {
        Task<Entrollment> CreateEntrollment(Entrollment entrollment);
        Task<List<EntrollmentResponse>> GetAllEntrollment();

        Task<EntrollmentResponse> GetEntrollment(string NicNo);

        Task<EntrollmentResponse> DeleteEnrollmentById(string NicNo);

        Task<EntrollmentResponse> UpdateEntrollment(string NicNo, EntrollmentRequest EntrollmentRequest);



    }
}
