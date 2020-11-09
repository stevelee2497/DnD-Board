using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace DnD_Board.Data.Models
{
    [Table("BoardUser")]
    public class BoardUser : BaseModel
    {
        public Guid UserId { get; set; }

        public Guid BoardId { get; set; }

        [DefaultValue(BoardMemberType.Member)]
        public BoardMemberType MemberType { get; set; }

        public virtual User User { get; set; }

        public virtual Board Board { get; set; }
    }

    public enum BoardMemberType
    {
        Member,
        Admin
    }
}