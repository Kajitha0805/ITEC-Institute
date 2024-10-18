namespace a_zApi.Enitity
{
    public class Entrollment
    {
        public string EntrollmentID { get; set; }
        public string NicNo  { get; set; }
        public Student student { get; set; }
        public string CourseId{ get; set; }
        public  Course Course   { get; set; }
    }
}
