using AdventOfCode2019.Commands;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2019
{
    class Computer
    {
        public static void CalculateResult()
        {

            int programCounter = 0;
            int[] memory = LoadProgram();

            while (ExecuteCommand(ref memory, ref programCounter))
            {
                continue;
            }            
        }


        static int[] LoadProgram()
        {
            string inputFile = @"C:\Users\Dunja\Documents\Code\AdventOfCode2019\inputs\input_5.txt";
            string text = File.ReadAllText(inputFile);
            string[] contents = text.Split(',');
            int[] program = new int[contents.Length];
            for (int i = 0; i < contents.Length; i++)
            {
                program[i] = Int32.Parse(contents[i]);
            }
            return program;
        }


        static bool ExecuteCommand(ref int[] memory, ref int programCounter)
        {
            int commandCode = memory[programCounter];
            //Console.WriteLine($"Command to be executed: {command}");
            //Array.ForEach(memory, Console.WriteLine);

            int commandKey = commandCode % 100;
            //Console.WriteLine($"Command: {commandCode}, Command key: {commandKey}");
            if(!commands.TryGetValue((CommandCode) commandKey, out ICommand commandToExecute))
            {
                Console.WriteLine("Something went wrong!");
                return false;
            }
            return commandToExecute.Execute(ref programCounter, ref memory, commandCode);            
        }


        enum CommandCode: int
        {
            Add = 1,
            Multiply = 2,
            Input = 3,
            Output = 4,
            Exit = 99
        }


        private static Dictionary<CommandCode, ICommand> commands = new Dictionary<CommandCode, ICommand>()
        {
            [CommandCode.Add] = new AddOperation(),
            [CommandCode.Multiply] = new MultiplyOperation(),
            [CommandCode.Input] = new InputCommand(1),
            [CommandCode.Output] = new OutputCommand(),
            [CommandCode.Exit] = new ExitCommand(),
        };
    }
}
