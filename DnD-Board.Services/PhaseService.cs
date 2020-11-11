using AutoMapper;
using DnD_Board.Common.Constants;
using DnD_Board.Data.Models;
using DnD_Board.DTOs;
using DnD_Board.IRepositories;
using DnD_Board.IServices;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DnD_Board.Services
{
    public class PhaseService : IPhaseService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PhaseService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Phase CreatePhase(CreatePhaseDto phaseDto)
        {
            var phase = _mapper.Map<Phase>(phaseDto);
            _unitOfWork.Repository<Phase>().Add(phase);
            _unitOfWork.Complete();
            return phase;
        }

        public IEnumerable<Phase> GetPhases(PhaseQuery query)
        {
            var res = _unitOfWork.Repository<Phase>().All();

            if (!string.IsNullOrEmpty(query.BoardId))
                res = res.Where(x => x.BoardId == Guid.Parse(query.BoardId));

            return res;
        }

        public Phase GetPhase(Guid id)
        {
            return _unitOfWork.Repository<Phase>().Find(id);
        }

        public Phase UpdatePhase(Guid id, UpdatePhaseDto phaseDto)
        {
            var phase = _unitOfWork.Repository<Phase>().Find(id);

            phase.Name = phaseDto.Name;
            phase.TaskOrder = JsonConvert.SerializeObject(phaseDto.TaskOrder);

            _unitOfWork.Repository<Phase>().Update(phase);
            _unitOfWork.Complete();

            return phase;
        }

        public void DeletePhase(Guid id)
        {
            var phase = _unitOfWork.Repository<Phase>().Find(id);
            _unitOfWork.Repository<Phase>().Remove(phase);
            _unitOfWork.Complete();
        }
    }
}
