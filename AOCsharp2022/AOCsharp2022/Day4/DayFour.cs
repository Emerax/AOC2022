namespace AOCsharp2022.Day4 {
    public class DayFour : BaseSolution {
        public DayFour(string inputFilePath) : base(inputFilePath) { }

        protected override string PartOne() {
            return InputReaderUtil.RawLines(inputFilePath)
                .Where(line => {
                    string[] assignments = line.Split(",");
                    string[] elfOneStrings = assignments[0].Split("-");
                    string[] elfTwoStrings = assignments[1].Split("-");
                    Range elfOne = new(int.Parse(elfOneStrings[0]), int.Parse(elfOneStrings[1]));
                    Range elfTwo = new(int.Parse(elfTwoStrings[0]), int.Parse(elfTwoStrings[1]));
                    return RangeContains(elfOne, elfTwo) || RangeContains(elfTwo, elfOne);
                })
                .Count()
                .ToString();
        }

        protected override string PartTwo() {
            return InputReaderUtil.RawLines(inputFilePath)
                .Where(line => {
                    string[] assignments = line.Split(",");
                    string[] elfOneStrings = assignments[0].Split("-");
                    string[] elfTwoStrings = assignments[1].Split("-");
                    Range elfOne = new(int.Parse(elfOneStrings[0]), int.Parse(elfOneStrings[1]));
                    Range elfTwo = new(int.Parse(elfTwoStrings[0]), int.Parse(elfTwoStrings[1]));
                    return RangeOverlaps(elfOne, elfTwo) || RangeOverlaps(elfTwo, elfOne);
                })
                .Count()
                .ToString();
        }

        public static bool RangeContains(Range r1, Range r2) {
            return r1.Start.Value >= r2.Start.Value && r1.End.Value <= r2.End.Value;
        }

        public static bool RangeOverlaps(Range r1, Range r2) {
            return r2.Start.Value <= r1.Start.Value && r1.Start.Value <= r2.End.Value
                || r2.Start.Value <= r1.End.Value && r1.End.Value <= r2.End.Value;
        }
    }
}
