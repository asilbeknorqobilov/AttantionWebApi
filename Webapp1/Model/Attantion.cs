namespace Webapp1.Model;


public class Attantion
{
    public int Id { get; set; }
    public bool Status { get; set; }
    // Student modeliga ulash
    public int StudentId { get; set; }
    public Student? Student { get; set; }
    //Lesson modeliga ulash
    public int LessonId { get; set; }
    public Lesson? Lesson { get; set; }
}