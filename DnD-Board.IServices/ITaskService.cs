using DnD_Board.Data.Models;
using DnD_Board.DTOs;
using System;
using System.Collections.Generic;

namespace DnD_Board.IServices
{
    public interface ITaskService
    {
        TaskAssignee AddTaskAssignee(TaskAssignee model);

        TaskLabel AddTaskLabel(TaskLabel model);

        Task CreateTask(CreateTaskDto taskDto);

        void DeleteTask(Guid id);

        Task GetTask(Guid id);

        IEnumerable<Task> GetTasks(TaskQuery query);

        void RemoveTaskAssignee(Guid id);

        void RemoveTaskLabel(Guid id);

        Task UpdateTask(Guid id, UpdateTaskDto taskDto);
    }
}