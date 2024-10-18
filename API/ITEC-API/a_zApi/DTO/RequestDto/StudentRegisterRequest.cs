namespace a_zApi.DTO.RequestDto
{
    public class StudentRegisterRequest
    {
        public string NICNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int MobileNo { get; set; }
        public string EmailId { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
    }
}
