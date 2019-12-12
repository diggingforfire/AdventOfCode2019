using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._01
{
    class Program
    {
        /// <summary>
        /// https://adventofcode.com/2019/day/7
        /// Starting to feel like my college 'algorithms and data structures' class. Permutations, recursion, all the good stuff.
        /// I like the re-use of the Intcode computer. Starting to feel like it's mine now.
        /// </summary>
        static void Main()
        {
            var input = "3,8,1001,8,10,8,105,1,0,0,21,34,43,60,81,94,175,256,337,418,99999,3,9,101,2,9,9,102,4,9,9,4,9,99,3,9,102,2,9,9,4,9,99,3,9,102,4,9,9,1001,9,4,9,102,3,9,9,4,9,99,3,9,102,4,9,9,1001,9,2,9,1002,9,3,9,101,4,9,9,4,9,99,3,9,1001,9,4,9,102,2,9,9,4,9,99,3,9,102,2,9,9,4,9,3,9,1001,9,2,9,4,9,3,9,102,2,9,9,4,9,3,9,101,1,9,9,4,9,3,9,1002,9,2,9,4,9,3,9,1001,9,2,9,4,9,3,9,101,2,9,9,4,9,3,9,101,1,9,9,4,9,3,9,102,2,9,9,4,9,3,9,1002,9,2,9,4,9,99,3,9,101,2,9,9,4,9,3,9,1001,9,1,9,4,9,3,9,101,1,9,9,4,9,3,9,102,2,9,9,4,9,3,9,1002,9,2,9,4,9,3,9,1001,9,1,9,4,9,3,9,1001,9,2,9,4,9,3,9,101,1,9,9,4,9,3,9,1001,9,1,9,4,9,3,9,1001,9,2,9,4,9,99,3,9,1002,9,2,9,4,9,3,9,102,2,9,9,4,9,3,9,1002,9,2,9,4,9,3,9,102,2,9,9,4,9,3,9,1001,9,1,9,4,9,3,9,1002,9,2,9,4,9,3,9,1001,9,2,9,4,9,3,9,101,1,9,9,4,9,3,9,101,2,9,9,4,9,3,9,1001,9,2,9,4,9,99,3,9,101,2,9,9,4,9,3,9,101,1,9,9,4,9,3,9,101,1,9,9,4,9,3,9,101,1,9,9,4,9,3,9,1001,9,1,9,4,9,3,9,1001,9,2,9,4,9,3,9,1001,9,2,9,4,9,3,9,102,2,9,9,4,9,3,9,1001,9,2,9,4,9,3,9,1002,9,2,9,4,9,99,3,9,1001,9,1,9,4,9,3,9,1001,9,1,9,4,9,3,9,1002,9,2,9,4,9,3,9,1001,9,1,9,4,9,3,9,1002,9,2,9,4,9,3,9,102,2,9,9,4,9,3,9,1001,9,2,9,4,9,3,9,1001,9,2,9,4,9,3,9,101,2,9,9,4,9,3,9,102,2,9,9,4,9,99";

            var instructions = input.Split(',').Select(int.Parse).ToArray();

            var allPossibleSequences = GetAllPossibleSequences(new[] { 0, 1, 2, 3, 4 }.ToArray());

            int output = allPossibleSequences.Max(sequence => GetThrusterOutput(instructions, sequence.ToArray()));

            Console.WriteLine(output);
        }

        static List<List<int>> GetAllPossibleSequences(int[] numbers)
        {
            var allSequences = new List<List<int>>();

            foreach (var number in numbers)
            {
                foreach (var sequences in GetAllPossibleSequences(numbers.Except(new[] { number }).ToArray()))
                {
                    sequences.Insert(0, number);
                    allSequences.Add(sequences);
                }
            }

            if (!allSequences.Any())
            {
                allSequences.Add(new List<int>());
            }

            return allSequences;

        }

        static int GetThrusterOutput(int[] instructions, int[] sequence)
        {
            int output = 0;

            foreach (var x in sequence)
            {
                output = RunAmplifierControllerSoftware(instructions, new[] { x, output });
            }

            return output;
        }

        static int RunAmplifierControllerSoftware(int[] instructions, int[] inputs)
        {
            int inputIndex = 0;
            int pc = 0;
            int opcode = 0;
            int output = 0;

            while (opcode != 99)
            {
                int instruction = instructions[pc];
                opcode = instruction % 100;

                if (opcode == 1)
                {
                    int op1 = GetOp(instructions, instruction, 1, pc + 1);
                    int op2 = GetOp(instructions, instruction, 2, pc + 2);
                    Store(instructions, op1 + op2, pc + 3);
                    pc += 4;
                }
                else if (opcode == 2)
                {
                    int op1 = GetOp(instructions, instruction, 1, pc + 1);
                    int op2 = GetOp(instructions, instruction, 2, pc + 2);
                    Store(instructions, op1 * op2, pc + 3);
                    pc += 4;
                }
                else if (opcode == 3)
                {
                    Store(instructions, inputs[inputIndex++], pc + 1);
                    pc += 2;
                }
                else if (opcode == 4)
                {
                    output = GetOp(instructions, instruction, 1, pc + 1);
                    pc += 2;
                }
                else if (opcode == 5)
                {
                    var op = GetOp(instructions, instruction, 1, pc + 1);
                    if (op > 0)
                    {
                        pc = GetOp(instructions, instruction, 2, pc + 2);
                    }
                    else
                    {
                        pc += 3;
                    }
                }
                else if (opcode == 6)
                {
                    var op = GetOp(instructions, instruction, 1, pc + 1);
                    if (op == 0)
                    {
                        pc = GetOp(instructions, instruction, 2, pc + 2);
                    }
                    else
                    {
                        pc += 3;
                    }
                }
                else if (opcode == 7)
                {
                    int op1 = GetOp(instructions, instruction, 1, pc + 1);
                    int op2 = GetOp(instructions, instruction, 2, pc + 2);
                    Store(instructions, op1 < op2 ? 1 : 0, pc + 3);
                    pc += 4;
                }
                else if (opcode == 8)
                {
                    int op1 = GetOp(instructions, instruction, 1, pc + 1);
                    int op2 = GetOp(instructions, instruction, 2, pc + 2);
                    Store(instructions, op1 == op2 ? 1 : 0, pc + 3);
                    pc += 4;
                }
            }

            return output;
        }

        static int GetOp(int[] instructions, int instruction, int offset, int i)
        {
            int opMode = GetOpMode(instruction, offset);
            return opMode == 0 ? instructions[instructions[i]] : instructions[i];
        }

        static int GetOpMode(int instruction, int offset)
        {
            return instruction / (int)Math.Pow(10, offset + 1) % 10;
        }

        static void Store(int[] instructions, int value, int addressPointer)
        {
            instructions[instructions[addressPointer]] = value;
        }

    }
}
