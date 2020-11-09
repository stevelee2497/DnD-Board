using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DnD_Board.Data.Models
{
    [Table("TaskAssignee")]
    public class TaskAssignee : BaseModel
    {
        public Guid UserId { get; set; }

        public Guid TaskId { get; set; }

        public virtual User User { get; set; }

        public virtual Task Task { get; set; }
    }
}