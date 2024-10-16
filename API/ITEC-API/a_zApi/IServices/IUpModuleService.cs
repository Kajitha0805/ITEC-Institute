using a_zApi.DTO.RequestDto;
using a_zApi.DTO.ResponseDto;

namespace a_zApi.IServices
{
    public interface IUpModuleService
    {
        Task<UploadModuleResponse> CreateUploadModule(UploadModuleRequest uploadModuleRequest);
    }
}
