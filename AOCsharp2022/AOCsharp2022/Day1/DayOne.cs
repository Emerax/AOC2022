namespace AOCsharp2022.Day1 {
    public class DayOne : BaseSolution {
        public DayOne(string inputFilePath) : base(inputFilePath) { }

        protected override string PartOne() {
            int leader = 0;
            int contestant = 0;
            InputReaderUtil.ProcessInput(inputFilePath, (line) => {
                if (int.TryParse(line, out int cals)) {
                    contestant += cals;
                }
                else {
                    if (contestant > leader) {
                        leader = contestant;
                    }

                    contestant = 0;
                }
            });

            if (contestant > leader) {
                leader = contestant;
            }

            return leader.ToString();
        }

        protected override string PartTwo() {
            List<int> calCounts = new();
            int current = 0;
            InputReaderUtil.ProcessInput(inputFilePath, (line) => {
                if (int.TryParse(line, out int cals)) {
                    current += cals;
                }
                else {
                    calCounts.Add(current);
                    current = 0;
                }
            });

            calCounts.Add(current);

            return calCounts.OrderDescending().Take(3).Sum().ToString();
        }
    }
}
