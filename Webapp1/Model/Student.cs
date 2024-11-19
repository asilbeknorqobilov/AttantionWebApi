namespace Webapp1.Model;

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Group { get; set; }

        public ICollection<Attantion> Attantions { get; set; } = new List<Attantion>();
}