namespace a_zApi.DTO.RequestDto
{
    public class ExpenseRequest
    {
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public decimal Price { get; set; }
        public IFormFile Receipt { get; set; }
        public string Description { get; set; }
    }
}
