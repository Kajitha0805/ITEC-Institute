namespace a_zApi.Enitity
{
    public class FollowUp
    {
        public string Name { get; set; }

        public string Moblie { get; set; }

        public string CourseId { get; set; }
        public Course Course { get; set; }

        public DateTime Date { get; set; }

        public string Email {  get; set; }

        public string Description {  get; set; }
    }
}
