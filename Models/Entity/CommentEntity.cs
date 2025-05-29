using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace TaskRun.Models.Entity {
    [Serializable]
    public class CommentEntity {
        public int Id { get; set; }
        public int TaskId { get; set; }
        public int UserId { get; set; }
        public string Comment { get; set; }
        public DateTime UpdateDateTime { get; set; }
    }
}

