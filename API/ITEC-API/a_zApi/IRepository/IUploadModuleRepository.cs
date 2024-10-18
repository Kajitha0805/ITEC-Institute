using a_zApi.Enitity;

namespace a_zApi.IRepository
{
    public interface IUploadModuleRepository
    {
        Task<UploadModule> CreateUploadModule(UploadModule uploadModule);
        Task<List<UploadModule>> GetAllUpModules();
    }
}
