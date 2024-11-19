using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Webapp1.Model;

namespace Webapp1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LessonController:ControllerBase
{
    private DataDbContext db;

    public LessonController(DataDbContext dataDbContext)
    {
        db = dataDbContext;
    }
    
    [HttpPost]
    public ActionResult<Lesson> Post(Lesson lesson)
    {
        db.Lessons.Add(lesson);
        db.SaveChanges();
        return Ok(lesson);
    }
    
    [HttpPut("{id}")]
    public ActionResult<Lesson> Put(int id, Lesson lesson)
    {
        var old_lesson = db.Lessons.Find(id);
        if (lesson==null)
        {
            return NotFound();
        }

        old_lesson.Date = lesson.Date;
        old_lesson.Subject = lesson.Subject;
        old_lesson.LessonType = lesson.LessonType;
        old_lesson.Teacher = lesson.Teacher;
        db.SaveChanges();
        return Ok(lesson);
    }
    
    
    [HttpGet]
    public ActionResult<IEnumerable<Lesson>> Get(string? subject)
    {
        var search = db.Lessons.AsQueryable();
        if (subject != null)
        {
            search = search.Where(x => EF.Functions.ILike(x.Subject,$"%{subject}"));
        }

        var res = search.ToList();
        return Ok(res);
    }
    
    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var del_lsn = db.Lessons.Find(id);
        db.Lessons.Remove(del_lsn);
        db.SaveChanges();
        return Ok();
    }
}