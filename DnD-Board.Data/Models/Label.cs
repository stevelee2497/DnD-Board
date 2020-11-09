using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DnD_Board.Data.Models
{
    [Table("Label")]
    public class Label : BaseModel
    {
        public string Name { get; set; }

        public string Color { get; set; }

        public Guid BoardId { get; set; }

        public virtual ICollection<TaskLabel> TaskLabels { get; set; }
    }
}