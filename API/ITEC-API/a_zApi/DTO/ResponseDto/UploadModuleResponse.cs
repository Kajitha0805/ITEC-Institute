using a_zApi.Enitity;

namespace a_zApi.DTO.ResponseDto
{
    public class UploadModuleResponse
    {
        public string Title { get; set; }
        public string CourseId { get; set; }
        public string Batch { get; set; }
        public DateTime Date { get; set; }
        public byte[] Uplode { get; set; }
        public string Description { get; set; }
    }
}
