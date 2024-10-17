namespace a_zApi.DTO.ResponseDto
{
    public class ExpenseResponse
    {
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public decimal Price { get; set; }
        public byte[] Receipt { get; set; }
        public string Description { get; set; }
    }
}
