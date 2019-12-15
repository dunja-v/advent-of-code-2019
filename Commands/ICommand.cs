using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2019.Commands
{
    interface ICommand
    {
        bool Execute(ref int programCounter, ref int[] memory);
    }
}
