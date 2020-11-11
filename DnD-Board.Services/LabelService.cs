using DnD_Board.Common.Constants;
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
    public class LabelService : ILabelService
    {
        private readonly IUnitOfWork _unitOfWork;

        public LabelService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Label CreateLabel(Label label)
        {
            _unitOfWork.Repository<Label>().Add(label);
            _unitOfWork.Complete();
            return label;
        }

        public IEnumerable<Label> GetLabels(LabelQuery query)
        {
            var res = _unitOfWork.Repository<Label>().All();

            if (!string.IsNullOrEmpty(query.BoardId))
                res = res.Where(x => x.BoardId == Guid.Parse(query.BoardId));

            return res;
        }

        public Label GetLabel(Guid id)
        {
            return _unitOfWork.Repository<Label>().Find(id);
        }

        public Label UpdateLabel(Guid id, UpdateLabelDto labelDto)
        {
            var label = _unitOfWork.Repository<Label>().Find(id);

            label.Name = labelDto.Name;
            label.Color = labelDto.Color;

            _unitOfWork.Repository<Label>().Update(label);
            _unitOfWork.Complete();

            return label;
        }

        public void DeleteLabel(Guid id)
        {
            var label = _unitOfWork.Repository<Label>().Find(id);
            _unitOfWork.Repository<Label>().Remove(label);
            _unitOfWork.Complete();
        }
    }
}
