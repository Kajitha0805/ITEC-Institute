using a_zApi.Enitity;

namespace a_zApi.IRepository
{
    public interface IEntrollmentRepository
    {
        Task<Entrollment> CreateEntrollment(Entrollment entrollment);
        Task<List<Entrollment>> GetAllentrollment();
        Task<Entrollment> GetEntrollment(string NicNo);
        Task<Entrollment> DeleteEntrollment(string NicNo);
        Task<Entrollment> FindEntrollment(string NicNo);
        Task<Entrollment> UpdateEntrollment(Entrollment Entrollment);

    }
}



