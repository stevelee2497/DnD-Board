using AutoMapper;
using DnD_Board.Data.Models;
using DnD_Board.IServices;
using DnD_Board.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System;

namespace DnD_Board.API.Controllers
{
    [Route("api/labels")]
    [ApiController]
    [Produces("application/json")]
    public class LabelController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILabelService _labelService;

        public LabelController(ILabelService labelService, IMapper mapper)
        {
            _mapper = mapper;
            _labelService = labelService;
        }

        [HttpGet]
        public SuccessResponse<IEnumerable<LabelDto>> GetLabels([FromQuery] LabelQuery query)
        {
            return new SuccessResponse<IEnumerable<LabelDto>>(_labelService.GetLabels(query).Select(x => _mapper.Map<LabelDto>(x)));
        }

        [HttpPost]
        public SuccessResponse<LabelDto> CreateLabel([FromBody] CreateLabelDto createLabelDto)
        {
            var label = _mapper.Map<Label>(createLabelDto);
            var response = _labelService.CreateLabel(label);
            return new SuccessResponse<LabelDto>(_mapper.Map<LabelDto>(response));
        }

        [HttpGet("{id}")]
        public SuccessResponse<LabelDto> GetLabel(Guid id)
        {
            var res = _labelService.GetLabel(id);
            return new SuccessResponse<LabelDto>(_mapper.Map<LabelDto>(res));
        }

        [HttpPut("{id}")]
        public BaseResponse<LabelDto> UpdateLabel([FromBody] UpdateLabelDto labelDto, Guid id)
        {
            var res = _labelService.UpdateLabel(id, labelDto);
            return new SuccessResponse<LabelDto>(_mapper.Map<LabelDto>(res));
        }

        [HttpDelete("{id}")]
        public SuccessResponse<string> DeleteLabel(Guid id)
        {
            _labelService.DeleteLabel(id);
            return new SuccessResponse<string>("success");
        }
    }
}