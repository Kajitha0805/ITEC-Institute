using a_zApi.Enitity;

namespace a_zApi.DTO.RequestDto
{
    public class FollowUpRequestDto
    {
        public string Name { get; set; }

        public string Moblie { get; set; }

        public string CourseId { get; set; }
       
        public DateTime Date { get; set; }

        public string Email { get; set; }
        public string Address { get; set; }

        public string Description { get; set; }
    }
}
