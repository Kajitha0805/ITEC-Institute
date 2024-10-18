namespace a_zApi.Enitity
{
    public class Expense
    {
        public string Title {  get; set; }
        public DateTime Date { get; set; }
        public decimal Price {  get; set; }
        public byte[] Receipt { get; set; }
        public string Description{ get; set; }
    }
}
