namespace a_zApi.DTO.ResponseDto
{
    public class StudentRegisterResponse
    {
        public string NICNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int MobileNo { get; set; }
        public string EmailId { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        public string Message { get; internal set; }
    }
}
