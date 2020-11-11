using Microsoft.AspNetCore.Mvc;
using System;

namespace DnD_Board.DTOs
{
    public class LabelDto
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Color { get; set; }
    }

    public class CreateLabelDto
    {
        public string Name { get; set; }

        public string Color { get; set; }
    }
    
    public class UpdateLabelDto
    {
        public string Name { get; set; }

        public string Color { get; set; }
    }

    public class TaskLabelDto
    {
        public string Id { get; set; }

        public string LabelId { get; set; }
    }

    public class LabelQuery
    {
        [FromQuery]
        public string BoardId { get; set; }
    }
}
