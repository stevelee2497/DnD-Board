using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DnD_Board.DTOs
{
    public class CreateBoardDto
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public Guid UserId { get; set; }
    }

    public class UpdateBoardDto
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        [Required]
        public IEnumerable<string> PhaseOrder { get; set; }
    }

    public class BoardOutputDto
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public IEnumerable<string> PhaseOrder { get; set; }

        public IEnumerable<BoardUserDto> Users { get; set; }
    }

    public class BoardQuery
    {
        [FromQuery]
        public string Name { get; set; }
    }
}
