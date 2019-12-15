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

            for(int noun=0; noun <=99; noun++)
            {
                for(int verb=0; verb<=99; verb++)
                {
                    int programCounter = 0;
                    int[] memory = LoadProgram();

                    memory[1] = noun;
                    memory[2] = verb;

                    while (ExecuteCommand(ref memory, ref programCounter))
                    {
                        continue;
                    }
                    
                    if(memory[0] == 19690720)
                    {
                        Console.WriteLine("Found the right pair!");
                        Console.WriteLine(100 * noun + verb);
                        break;
                    }
                    
                }
            }
            
        }


        static int[] LoadProgram()
        {
            string inputFile = @"C:\Users\Dunja\Documents\Code\AdventOfCode2019\input_2.txt";
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

            if(!commands.TryGetValue((CommandCode) commandCode, out ICommand commandToExecute))
            {
                Console.WriteLine("Something went wrong!");
                return false;
            }
            return commandToExecute.Execute(ref programCounter, ref memory);            
        }


        enum CommandCode: int
        {
            Add = 1,
            Multiply = 2,
            Exit = 99
        }


        private static Dictionary<CommandCode, ICommand> commands = new Dictionary<CommandCode, ICommand>()
        {
            [CommandCode.Add] = new AddOperation(),
            [CommandCode.Multiply] = new MultiplyOperation(),
            [CommandCode.Exit] = new ExitCommand(),
        };
    }
}
