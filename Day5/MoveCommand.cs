using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5
{
    public record MoveCommand
    {
        public int movecount { get; init; }
        public int origin { get; init; }
        public int destination { get; init; }
    }
}
