using Microsoft.AspNetCore.Mvc;
using System;

namespace DnD_Board.DTOs
{
    public class TaskDto
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTimeOffset CreatedTime { get; set; }

        public DateTimeOffset DueDate { get; set; }

        public TimeSpan Estimation { get; set; }

        public TimeSpan SpentTime { get; set; }

        public string ReporterUserId { get; set; }

        public string BoardId { get; set; }

        //public IEnumerable<TaskAssigneeOutputDto> TaskAssignees { get; set; }

        //public IEnumerable<TaskLabelOutputDto> TaskLabels { get; set; }
    }

    public class CreateTaskDto
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public Guid ReporterUserId { get; set; }

        public Guid BoardId { get; set; }
    }

    public class UpdateTaskDto
    {
        public string Title { get; set; }

        public string Description { get; set; }
    }

    public class TaskAssigneeDto
    {
        public string Id { get; set; }

        public string UserId { get; set; }
    }

    public class TaskQuery
    {
        [FromQuery]
        public string BoardId { get; set; }

        [FromQuery]
        public string MemberId { get; set; }
    }
}
