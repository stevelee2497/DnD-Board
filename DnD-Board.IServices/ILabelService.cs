using DnD_Board.Data.Models;
using DnD_Board.DTOs;
using System;
using System.Collections.Generic;

namespace DnD_Board.IServices
{
    public interface ILabelService
    {
        Label CreateLabel(Label label);

        void DeleteLabel(Guid id);

        Label GetLabel(Guid id);

        IEnumerable<Label> GetLabels(LabelQuery query);

        Label UpdateLabel(Guid id, UpdateLabelDto labelDto);
    }
}