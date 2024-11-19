using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Webapp1.Model;

namespace Webapp1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AttantionController:ControllerBase
{
    private DataDbContext db;

    public AttantionController(DataDbContext dataDbContext)
    {
        db = dataDbContext;
    }

    [HttpPost]
    public ActionResult<Attantion> Post(Attantion attantion)
    {
        var search = db.Attantions.Where(a => a.StudentId == attantion.StudentId && a.LessonId == attantion.LessonId);
        var res = attantion;
        if (search.Count() == 0) 
        {
            db.Attantions.Add(attantion);
            db.SaveChanges();
        }
        else
        {
            res = search.First();
            res.Status = attantion.Status;
            db.SaveChanges();
        }
        return Ok(res);
    }


}