using System.ComponentModel;

namespace AOCsharp2022.Day3 {
    public class DayThree : BaseSolution {
        public DayThree(string inputFilePath) : base(inputFilePath) { }

        protected override string PartOne() {
            return InputReaderUtil.RawLines(inputFilePath)
                .Select(line => {
                    int cutOff = line.Length / 2;
                    string first = line[..cutOff];
                    string second = line[cutOff..];
                    char duplicate = first.First(c => second.Contains(c));
                    return char.IsUpper(duplicate) ? duplicate % 32 + 26 : duplicate % 32;
                })
                .Sum()
                .ToString();
        }

        protected override string PartTwo() {
            int total = 0;
            List<char> itemTypes = new("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray());
            int elfIndex = 0;
            InputReaderUtil.ProcessInput(inputFilePath, (line) => {
                itemTypes.RemoveAll(c => !line.Contains(c));
                if(elfIndex == 2) {
                    total += char.IsUpper(itemTypes[0]) ? itemTypes[0] % 32 + 26 : itemTypes[0] % 32;
                    itemTypes = new("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray());
                    elfIndex = 0;
                }
                else {
                    ++elfIndex;
                }
            });

            return total.ToString();
        }
    }
}
