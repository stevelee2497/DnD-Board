using System;

namespace DnD_Board.DTOs
{
    public class UserDto
    {
        public Guid Id { get; set; }

        public string DisplayName { get; set; }

        public string Email { get; set; }

        public string[] Roles { get; set; }
    }

    public class CreateUserDto
    {
        public string DisplayName { get; set; }

        public string Password { get; set; }

        public string AvatarUrl { get; set; }
    }
}
