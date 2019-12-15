using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2019.Commands
{
    class AddOperation : BinaryOperation
    {
        public override int Operation(int operand_1, int operand_2)
        {
            return operand_1 + operand_2;
        }
    }
}
