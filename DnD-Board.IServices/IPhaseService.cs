using DnD_Board.Data.Models;
using DnD_Board.DTOs;
using System;
using System.Collections.Generic;

namespace DnD_Board.IServices
{
    public interface IPhaseService
    {
        Phase CreatePhase(CreatePhaseDto phase);

        void DeletePhase(Guid id);

        Phase GetPhase(Guid id);

        IEnumerable<Phase> GetPhases(PhaseQuery query);

        Phase UpdatePhase(Guid id, UpdatePhaseDto phaseDto);
    }
}