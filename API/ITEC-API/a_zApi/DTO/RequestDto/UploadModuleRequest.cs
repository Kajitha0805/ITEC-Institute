using a_zApi.Enitity;

namespace a_zApi.DTO.RequestDto
{
    public class UploadModuleRequest
    {
        public string Title { get; set; }
        public string CourseId { get; set; }
        public string Batch { get; set; }
        public DateTime Date { get; set; }
        public IFormFile Uplode { get; set; }
        public string Description { get; set; }
    }
}
