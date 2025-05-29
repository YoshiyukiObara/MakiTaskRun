using System.ComponentModel.DataAnnotations;
using TaskRun.Models.Entity;

namespace TaskRun.Models.Entity {
    public class CommentDTO : CommentEntity {
        //taskname
        public string TaskName { get; set; }

        //username
        public string UserName { get; set; }
    }
}