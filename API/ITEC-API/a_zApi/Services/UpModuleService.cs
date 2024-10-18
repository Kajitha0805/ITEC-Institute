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
            if (uploadModuleRequest.Uplode != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await uploadModuleRequest.Uplode.CopyToAsync(memoryStream);
                    inputUploadModule.Uplode = memoryStream.ToArray();
                }
            };
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
        public async Task<List<UploadModuleResponse>> GetAllUpModules()
        {
            var data = await _iuploadModuleRepository.GetAllUpModules();
            var response = new List<UploadModuleResponse>();
            foreach (var module in data)
            {
                var upModuleResponse = new UploadModuleResponse();
                upModuleResponse.Title = module.Title;
                upModuleResponse.CourseId = module.CourseId;
                upModuleResponse.Batch = module.Batch;
                upModuleResponse.Date = module.Date;
                upModuleResponse.Uplode = module.Uplode;
                upModuleResponse.Description = module.Description;
                response.Add(upModuleResponse);
            }
            return response;
        }
    }
}
