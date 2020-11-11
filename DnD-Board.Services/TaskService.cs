using AutoMapper;
using DnD_Board.Data.Models;
using DnD_Board.DTOs;
using DnD_Board.IRepositories;
using DnD_Board.IServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DnD_Board.Services
{
    public class TaskService : ITaskService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TaskService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IEnumerable<Task> GetTasks(TaskQuery query)
        {
            var res = _unitOfWork.Repository<Task>().All();

            if (!string.IsNullOrEmpty(query.BoardId))
            {
                res = res.Where(x => x.BoardId == Guid.Parse(query.BoardId));
            }

            if (!string.IsNullOrEmpty(query.MemberId))
            {
                res = res.Where(x => x.ReporterUserId == Guid.Parse(query.MemberId));
            }

            return res;
        }

        public Task GetTask(Guid id)
        {
            return _unitOfWork.Repository<Task>()
                              .Include(x => x.TaskActions)
                              .Include(x => x.TaskAssignees).ThenInclude(x => x.User)
                              .Include(x => x.TaskLabels).ThenInclude(x => x.Label)
                              .Include(x => x.Reporter)
                              .First(x => x.Id == id);
        }

        public Task CreateTask(CreateTaskDto taskDto)
        {
            var task = _mapper.Map<Task>(taskDto);
            _unitOfWork.Repository<Task>().Add(task);
            _unitOfWork.Complete();
            return task;
        }

        public Task UpdateTask(Guid id, UpdateTaskDto taskDto)
        {
            var task = _unitOfWork.Repository<Task>().Find(id);

            task.Title = taskDto.Title;
            task.Description = taskDto.Description;

            _unitOfWork.Repository<Task>().Update(task);
            _unitOfWork.Complete();

            return task;
        }

        public void DeleteTask(Guid id)
        {
            var task = _unitOfWork.Repository<Task>().Find(id);
            _unitOfWork.Repository<Task>().Remove(task);
            _unitOfWork.Complete();
        }

        public TaskAssignee AddTaskAssignee(TaskAssignee model)
        {
            _unitOfWork.Repository<TaskAssignee>().Add(model);
            _unitOfWork.Complete();
            return model;
        }  

        public void RemoveTaskAssignee(Guid id)
        {
            var model = _unitOfWork.Repository<TaskAssignee>().Find(id);
            _unitOfWork.Repository<TaskAssignee>().Remove(model);
            _unitOfWork.Complete();
        }

        public TaskLabel AddTaskLabel(TaskLabel model)
        {
            _unitOfWork.Repository<TaskLabel>().Add(model);
            _unitOfWork.Complete();
            return model;
        }  

        public void RemoveTaskLabel(Guid id)
        {
            var model = _unitOfWork.Repository<TaskLabel>().Find(id);
            _unitOfWork.Repository<TaskLabel>().Remove(model);
            _unitOfWork.Complete();
        }
    }
}