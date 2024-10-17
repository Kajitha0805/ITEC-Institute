using a_zApi.Enitity;

namespace a_zApi.IRepository
{
    public interface IBatchRepository
    {
        Task<Batch> CreateBatch(Batch batch);
        Task<List<Batch>> GetAllBatch();
    }
}
