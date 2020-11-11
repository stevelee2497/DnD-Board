using System.Collections.Generic;

namespace DnD_Board.DTOs
{
    public class PhaseDto
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<string> TaskOrder { get; set; }
    }

    public class CreatePhaseDto
    {
        public string Name { get; set; }

        public string BoardId { get; set; }
    }

    public class UpdatePhaseDto
    {
        public string Name { get; set; }

        public IEnumerable<string> TaskOrder { get; set; }
    }

    public class PhaseQuery
    {
        public string BoardId { get; set; }
    }
}
