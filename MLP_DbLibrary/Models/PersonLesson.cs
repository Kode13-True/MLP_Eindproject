namespace MLP_DbLibrary.Models
{
    public class PersonLesson
    {
        public int PersonId { get; set; }
        public Person Person { get; set; }

        public int LessonId { get; set; }
        public Lesson Lesson { get; set; }
    }
}