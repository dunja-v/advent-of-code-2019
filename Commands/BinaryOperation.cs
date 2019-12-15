using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2019.Commands
{
    abstract class BinaryOperation : ICommand
    {
        public bool Execute(ref int programCounter, ref int[] memory)
        {
            int operand_1 = memory[memory[programCounter + 1]];
            int operand_2 = memory[memory[programCounter + 2]];
            int result = Operation(operand_1, operand_2);
            memory[memory[programCounter + 3]] = result;
            programCounter += Step;

            return true;
        }

        public abstract int Operation(int operand_1, int operand_2);

        private const int Step = 4;
    }
}
