using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2019.Commands
{
    class InputCommand : UnaryCommand
    {
        public InputCommand(int input)
        {
            this.input = input;
        }

        public override void Command(int programCounter, ref int[] memory)
        {
            int address = memory[programCounter + 1];
            memory[address] = this.input;
        }

        private int input;
    }
}
