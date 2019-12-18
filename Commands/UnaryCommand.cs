using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2019.Commands
{
    abstract class UnaryCommand : ICommand
    {
        public bool Execute(ref int programCounter, ref int[] memory, int commandCode)
        {
            Command(programCounter, ref memory);
            programCounter += Step;
            return true;
        }

        public abstract void Command(int programCounter, ref int[] memory);

        public virtual int GetOutput()
        {
            throw new NotImplementedException();
        }

        public virtual void SetInput(int input)
        {
            throw new NotImplementedException();
        }

        private const int Step = 2;
    }
}
