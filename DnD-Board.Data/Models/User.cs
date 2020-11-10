using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DnD_Board.Data.Models
{
    [Table("User")]
    public class User : BaseModel
    {
        public string DisplayName { get; set; }

        public string Email { get; set; }

        public string AvatarUrl { get; set; }

        public string PasswordHash { get; set; }

        public string PasswordSalt { get; set; }

        [InverseProperty("Reporter")]
        public virtual ICollection<Task> CreatedTasks { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<TaskAssignee> TaskAssignees { get; set; }

        public virtual ICollection<TaskAction> TaskActions { get; set; }
    }
}
