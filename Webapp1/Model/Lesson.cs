namespace Webapp1.Model;

public class Lesson
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public string Subject { get; set; }
    public string LessonType { get; set; }
    public string Teacher { get; set; }

    public ICollection<Attantion> Attantions { get; set; } = new List<Attantion>();
}