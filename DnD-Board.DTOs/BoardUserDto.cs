using System;

namespace DnD_Board.DTOs
{
    public class BoardUserDto
    {
        public string Id { get; set; }

        public string UserId { get; set; }

        public string DisplayName { get; set; }

        public string AvatarUrl { get; set; }

        public string MemberType { get; set; }
    }

    public class CreateBoardUserDto
    {
        public Guid UserId { get; set; }
    }
}