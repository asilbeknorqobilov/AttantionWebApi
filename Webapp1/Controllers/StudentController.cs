using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Webapp1.Model;

namespace Webapp1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentController : ControllerBase
{
    private DataDbContext db;

    public StudentController(DataDbContext dataDbContext)
    {
        db = dataDbContext;
    }

    [HttpPost]
    public ActionResult<Student> Post(Student student)
    {
        db.Students.Add(student);
        db.SaveChanges();
        return Ok(student);
    }

    [HttpPut("{id}")]
    public ActionResult<Student> Put(int id, Student student)
    {
        var old_student = db.Students.Find(id);
        if (old_student == null)
        {
            return NotFound();
        }

        old_student.Name = student.Name;
        old_student.Surname = student.Surname;
        old_student.Group = student.Group;
        db.SaveChanges();
        return Ok(student);
    }

    [HttpGet]
    public ActionResult<IEnumerable<Student>> Get(string? name, string? surname)
    {
        var search = db.Students.AsQueryable();
        if (name is not null)
        {
            search = search.Where(x => EF.Functions.ILike(x.Name, $"%{name}%"));
        }

        if (surname != null)
        {
            search = search.Where(x => EF.Functions.ILike(x.Surname, $"%{surname}%"));
        }

        var res = search.Include(s => s.Attantions).ToList();
        return Ok(res);
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var del_stnd = db.Students.Find(id);
        db.Students.Remove(del_stnd);
        db.SaveChanges();
        return Ok();
    }
}