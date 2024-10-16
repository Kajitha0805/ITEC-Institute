using a_zApi.DTO.RequestDto;
using a_zApi.DTO.ResponseDto;
using a_zApi.Enitity;
using a_zApi.IRepository;
using a_zApi.IServices;
using a_zApi.Repository;

namespace a_zApi.Services
{
    public class UpModuleService: IUpModuleService
    {
        private readonly IUploadModuleRepository _iuploadModuleRepository;
        public UpModuleService(IUploadModuleRepository iuploadModuleRepository)
        {
            _iuploadModuleRepository = iuploadModuleRepository;
        }
        public async Task<UploadModuleResponse> CreateUploadModule(UploadModuleRequest uploadModuleRequest)
        {
            var inputUploadModule = new UploadModule();
            inputUploadModule.Title = uploadModuleRequest.Title;
            inputUploadModule.CourseId = uploadModuleRequest.CourseId;
            inputUploadModule.Batch = uploadModuleRequest.Batch;
            inputUploadModule.Date = uploadModuleRequest.Date;
            inputUploadModule.Uplode = uploadModuleRequest.Uplode;
            inputUploadModule.Description = uploadModuleRequest.Description;

            var addedUploadModules = await _iuploadModuleRepository.CreateUploadModule(inputUploadModule);

            var response = new UploadModuleResponse();
            response.Title = addedUploadModules.Title;
            response.CourseId = addedUploadModules.CourseId;
            response.Batch = addedUploadModules.Batch;
            response.Date = addedUploadModules.Date;
            response.Uplode = addedUploadModules.Uplode;
            response.Description = addedUploadModules.Description;

            return response;

        }
    }
}
