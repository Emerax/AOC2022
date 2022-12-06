namespace AOCsharp2022.Day6 {
    public class DaySix : BaseSolution {
        public DaySix(string inputFilePath) : base(inputFilePath) { }

        protected override string PartOne() {
            string input = InputReaderUtil.RawText(inputFilePath);

            return (input.Select((char symbol, int i) => input[i..(i + 4)])
                .Select((candidate, index) => (candidate, index))
                .First(tuple => tuple.candidate.Distinct().Count() == 4)
                .index + 4)
                .ToString();
        }

        protected override string PartTwo() {
            string input = InputReaderUtil.RawText(inputFilePath);

            return (input.Select((char symbol, int i) => input[i..(i + 14)])
                .Select((candidate, index) => (candidate, index))
                .First(tuple => tuple.candidate.Distinct().Count() == 14)
                .index + 14)
                .ToString();
        }
    }
}
