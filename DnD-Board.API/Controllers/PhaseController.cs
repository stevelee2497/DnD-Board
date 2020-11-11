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
    [Route("api/phases")]
    [ApiController]
    [Produces("application/json")]
    public class PhaseController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPhaseService _phaseService;

        public PhaseController(IPhaseService phaseService, IMapper mapper)
        {
            _mapper = mapper;
            _phaseService = phaseService;
        }

        [HttpGet]
        public SuccessResponse<IEnumerable<PhaseDto>> GetPhases([FromQuery] PhaseQuery query)
        {
            var res = _phaseService.GetPhases(query).Select(x => _mapper.Map<PhaseDto>(x));
            return new SuccessResponse<IEnumerable<PhaseDto>>(res);
        }

        [HttpPost]
        public SuccessResponse<PhaseDto> CreatePhase([FromBody] CreatePhaseDto createPhaseDto)
        {
            var res = _phaseService.CreatePhase(createPhaseDto);
            return new SuccessResponse<PhaseDto>(_mapper.Map<PhaseDto>(res));
        }

        [HttpGet("{id}")]
        public SuccessResponse<PhaseDto> GetPhase(Guid id)
        {
            var res = _phaseService.GetPhase(id);
            return new SuccessResponse<PhaseDto>(_mapper.Map<PhaseDto>(res));
        }

        [HttpPut("{id}")]
        public BaseResponse<PhaseDto> UpdatePhase([FromBody] UpdatePhaseDto phaseDto, Guid id)
        {
            var res = _phaseService.UpdatePhase(id, phaseDto);
            return new SuccessResponse<PhaseDto>(_mapper.Map<PhaseDto>(res));
        }

        [HttpDelete("{id}")]
        public SuccessResponse<string> DeletePhase(Guid id)
        {
            _phaseService.DeletePhase(id);
            return new SuccessResponse<string>("success");
        }
    }
}