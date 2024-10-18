namespace a_zApi.Enitity
{
    public class UploadModule
    {
        public string Title {  get; set; }
        public string CourseId { get; set; }
        public Course Course { get; set; }
        public string Batch {  get; set; }
        public DateTime Date { get; set; }
        public byte[] Uplode { get; set; }
        public string Description {  get; set; }
    }
}
