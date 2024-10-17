using a_zApi.DTO.RequestDto;
using a_zApi.DTO.ResponseDto;

namespace a_zApi.IServices
{
    public interface IBatchService
    {
        Task<BatchResponse> CreateBatch(BatchRequest batchRequest);
        Task<List<BatchResponse>> GetAllBatches();
    }
}
