using System;
using System.ComponentModel.DataAnnotations;

namespace DnD_Board.Data.Models
{
    public abstract class BaseModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public DateTime CreatedTime { get; set; }

        [Required]
        public DateTime UpdatedTime { get; set; }

        [Required]
        public bool IsActive { get; set; }
    }
}
