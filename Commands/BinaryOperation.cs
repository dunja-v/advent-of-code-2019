using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2019.Commands
{
    abstract class BinaryOperation : ICommand
    {
        public bool Execute(ref int programCounter, ref int[] memory, int commandCode)
        {
            bool isFirstParameterImmediate = (commandCode % 1000) / 100 >= 1;
            bool isSecondParameterImmediate = (commandCode % 10000) / 1000 >= 1;
            int operand_1 = isFirstParameterImmediate ?  memory[programCounter + 1] : memory[memory[programCounter + 1]];
            int operand_2 = isSecondParameterImmediate ? memory[programCounter + 2] : memory[memory[programCounter + 2]];
            int result = Operation(operand_1, operand_2);
            memory[memory[programCounter + 3]] = result;
            programCounter += Step;

            return true;
        }

        public abstract int Operation(int operand_1, int operand_2);

        private const int Step = 4;
    }
}
