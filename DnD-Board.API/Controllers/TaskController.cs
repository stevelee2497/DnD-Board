using AutoMapper;
using DnD_Board.Data.Models;
using DnD_Board.DTOs;
using DnD_Board.IServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DnD_Task.API.Controllers
{
    [Route("api/tasks")]
    [ApiController]
    [Produces("application/json")]
    public class TaskController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService, IMapper mapper)
        {
            _mapper = mapper;
            _taskService = taskService;
        }

        [HttpPost]
        public SuccessResponse<TaskDto> Create([FromBody] CreateTaskDto taskInputDto)
        {
            var res = _taskService.CreateTask(taskInputDto);
            return new SuccessResponse<TaskDto>(_mapper.Map<TaskDto>(res));
        }

        [HttpGet]
        public SuccessResponse<IEnumerable<TaskDto>> Get([FromQuery] TaskQuery query)
        {
            var res = _taskService.GetTasks(query).Select(_mapper.Map<TaskDto>);
            return new SuccessResponse<IEnumerable<TaskDto>>(res);
        }

        [HttpGet("{id}")]
        public SuccessResponse<TaskDto> Get(Guid id)
        {
            var res = _taskService.GetTask(id);
            return new SuccessResponse<TaskDto>(_mapper.Map<TaskDto>(res));
        }

        [HttpPut("{id}")]
        public BaseResponse<TaskDto> Update([FromBody] UpdateTaskDto taskDto, Guid id)
        {
            var res = _taskService.UpdateTask(id, taskDto);
            return new SuccessResponse<TaskDto>(_mapper.Map<TaskDto>(res));
        }

        [HttpDelete("{id}")]
        public SuccessResponse<string> Delete(Guid id)
        {
            _taskService.DeleteTask(id);
            return new SuccessResponse<string>("success");
        }

        [HttpPost("{id}/assignees")]
        public SuccessResponse<TaskAssigneeDto> AddTaskAssignee([FromBody] TaskAssigneeDto assigneeDto, Guid id)
        {
            var model = new TaskAssignee { TaskId = id, UserId = Guid.Parse(assigneeDto.UserId) };
            var res = _taskService.AddTaskAssignee(model);
            return new SuccessResponse<TaskAssigneeDto>(_mapper.Map<TaskAssigneeDto>(res));
        }

        [HttpDelete("{id}/assignees/{taskAssigneeId}")]
        public SuccessResponse<string> RemoveTaskAssignee(Guid taskAssigneeId)
        {
            _taskService.RemoveTaskAssignee(taskAssigneeId);
            return new SuccessResponse<string>("success");
        }

        [HttpPost("{id}/labels")]
        public SuccessResponse<TaskLabelDto> AddTaskLabel([FromBody] TaskLabelDto labelDto, Guid id)
        {
            var model = new TaskLabel { TaskId = id, LabelId = Guid.Parse(labelDto.LabelId) };
            var res = _taskService.AddTaskLabel(model);
            return new SuccessResponse<TaskLabelDto>(_mapper.Map<TaskLabelDto>(res));
        }

        [HttpDelete("{id}/labels/{taskLabelId}")]
        public SuccessResponse<string> RemoveTaskLabel(Guid taskLabelId)
        {
            _taskService.RemoveTaskLabel(taskLabelId);
            return new SuccessResponse<string>("success");
        }
    }
}