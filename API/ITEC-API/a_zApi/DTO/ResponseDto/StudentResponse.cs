using Microsoft.VisualBasic;

namespace a_zApi.DTO.ResponseDto
{
    public class StudentResponse
    {
        public Guid StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BOD { get; set; }
        public string NicNumber { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string TelNumber { get; set; }
    }
}
