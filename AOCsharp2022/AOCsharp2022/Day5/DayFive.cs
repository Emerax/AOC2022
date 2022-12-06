using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace AOCsharp2022.Day5 {
    public class DayFive : BaseSolution {
        public DayFive(string inputFilePath) : base(inputFilePath) {
        }

        protected override string PartOne() {
            string[] input = InputReaderUtil.RawText(inputFilePath).Split(new string[] { Environment.NewLine + Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            string[] stackLines = input[0].Split("\r\n").SkipLast(1).ToArray();
            string[] instructionLines = input[1].Split("\r\n").ToArray();

            List<Stack<char>> stacks = ReadStacks(stackLines);

            foreach(string instructionLine in instructionLines) {
                string[] numberInputs = instructionLine.Split(" ");
                int moves = int.Parse(numberInputs[1]);
                int sourceStack = int.Parse(numberInputs[3]) - 1;
                int destStack = int.Parse(numberInputs[5]) - 1;

                for(int i = 0; i < moves; ++i) {
                    char box = stacks[sourceStack].Pop();
                    stacks[destStack].Push(box);
                }
            }

            return new string(stacks.Select(stack => stack.Peek()).ToArray());
        }

        protected override string PartTwo() {
            string[] input = InputReaderUtil.RawText(inputFilePath).Split(new string[] { Environment.NewLine + Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            string[] stackLines = input[0].Split("\r\n").SkipLast(1).ToArray();
            string[] instructionLines = input[1].Split("\r\n").ToArray();

            List<Stack<char>> stacks = ReadStacks(stackLines);

            foreach(string instructionLine in instructionLines) {
                string[] numberInputs = instructionLine.Split(" ");
                int moves = int.Parse(numberInputs[1]);
                int sourceStack = int.Parse(numberInputs[3]) - 1;
                int destStack = int.Parse(numberInputs[5]) - 1;

                Stack<char> boxes = new();
                for(int i = 0; i < moves; ++i) {
                    char box = stacks[sourceStack].Pop();
                    boxes.Push(box);
                }

                foreach(char box in boxes) {
                    stacks[destStack].Push(box);
                }
            }

            return new string(stacks.Select(stack => stack.Peek()).ToArray());
        }

        private List<Stack<char>> ReadStacks(string[] stackLines) {
            List<Stack<char>> stacks = new();
            int lineLength = stackLines[0].Length;
            for(int i = 0; i * 4 + 1 < lineLength; ++i) {

                Stack<char> stack = new();
                foreach(string line in stackLines.Reverse().ToList()) {
                    char boxCandidate = line[i * 4 + 1];
                    if(char.IsLetter(boxCandidate)) {
                        stack.Push(boxCandidate);
                    }
                }

                if(stack.Count > 0) {
                    stacks.Add(stack);
                }
            }

            return stacks;
        }
    }
}
