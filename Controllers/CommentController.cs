using DynamicDll.Db;
using Microsoft.AspNetCore.Mvc;
using TaskRun.Models.Entity;

namespace Taskrun.Controllers {
    public class CommentController : Controller {
        public IActionResult ShowEdit(int id) {
            CommentDTO comm = new CommentDTO();
            try {
                using (TranMng mng = TranMng.BeginTransaction("TaskRun.DB")) {
                    CommentDAO cd=new CommentDAO();
                    // /Comment/ShowEdit/1
                    comm=cd.Find(id);
                }

            } catch (Exception ex) { 
                ViewData["Message"] = ex.ToString();
            }

            return View(comm);
        }
    }
}
