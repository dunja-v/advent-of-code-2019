using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2019.Commands
{
    class OutputCommand : UnaryCommand
    {
        public override void Command(int programCounter, ref int[] memory)
        {
            int address = memory[programCounter + 1];
            Console.WriteLine($"Output: {memory[address]}");
        }
    }
}
