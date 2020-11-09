using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DnD_Board.Data.Models
{
    [Table("Phase")]
    public class Phase : BaseModel
    {
        public string Name { get; set; }

        public Guid BoardId { get; set; }

        public string TaskOrder { get; set; }

        public virtual Board Board { get; set; }
    }
}