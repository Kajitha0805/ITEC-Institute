using a_zApi.DTO.RequestDto;
using a_zApi.DTO.ResponseDto;
using a_zApi.Enitity;
using a_zApi.IRepository;
using a_zApi.IServices;
using a_zApi.Repository;

namespace a_zApi.Services
{
    public class BatchService:IBatchService
    {
        private readonly IBatchRepository _ibatchRepository;
        public BatchService(IBatchRepository ibatchRepository)
        {
            _ibatchRepository = ibatchRepository;
        }
        public async Task<BatchResponse> CreateBatch(BatchRequest batchRequest)
        {
            var inputBatch = new Batch();
            //inputBatch.BatchId = batchRequest.BatchId;
            inputBatch.BatchName = batchRequest.BatchName;
            
            var addedCourses = await _ibatchRepository.CreateBatch(inputBatch);

            var response = new BatchResponse();
            //response.BatchId = addedCourses.BatchId;
            response.BatchName = addedCourses.BatchName;
           

            return response;

        }
        public async Task<List<BatchResponse>> GetAllBatches()
        {
            var data = await _ibatchRepository.GetAllBatch();
            var response = new List<BatchResponse>();
            foreach (var batch in data)
            {
                var batchResponse = new BatchResponse();
                //batchResponse.BatchId = batch.BatchId;
                batchResponse.BatchName = batch.BatchName;
                response.Add(batchResponse);
            }
            return response;
        }
    }
}
