using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2019
{
    class Password
    {
        public static void CalculateResult()
        {
            int count = 0;
            int number = 0;

            for(int d1=1; d1 < 7; d1++)
            {
                for (int d2 = d1; d2 < 10; d2++)
                {
                    for (int d3 = d2; d3 < 10; d3++)
                    {
                        for (int d4 = d3; d4 < 10; d4++)
                        {
                            for (int d5 = d4; d5 < 10; d5++)
                            {
                                for (int d6 = d5; d6 < 10; d6++)
                                {
                                                                       
                                    if (containsDubleDigit(new int[] { d1, d2, d3, d4, d5, d6 })){
                                        number = d1 * (int)Math.Pow(10, 5) + d2 * (int)Math.Pow(10, 4)
                                        + d3 * (int)Math.Pow(10, 3) + d4 * (int)Math.Pow(10, 2) + d5 * 10 + d6;

                                        if (number < 172851 || number > 675869)
                                        {
                                            continue;
                                        }
                                        count++;
                                    }                                    
                                }
                            }
                        }
                    }
                }
            }
            Console.WriteLine(count);
        }

        public static bool containsDubleDigit(int[] password)
        {
            int previous = password[0];
            int sequenceLength = 1;
            for(int i=1; i<password.Length; i++)
            {
                if(password[i] != previous)
                {
                   if(sequenceLength == 2)
                    {
                        return true;
                    }
                    sequenceLength = 1;
                }
                else
                {
                    sequenceLength += 1;
                }
                previous = password[i];

                if(i == (password.Length - 1) && sequenceLength == 2)
                {
                    return true;
                }
            }
            return false;
        }


    }
}
