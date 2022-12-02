namespace AOCsharp2022.Day2 {
    public class DayTwo : BaseSolution {
        public DayTwo(string inputFilePath) : base(inputFilePath) { }

        private enum RPS {
            ROCK,
            PAPER,
            SCISSORS
        }

        protected override string PartOne() {
            int totalScore = 0;
            InputReaderUtil.ProcessInput(inputFilePath, (line) => {
                var opponentMove = line[..1] switch {
                    "A" => RPS.ROCK,
                    "B" => RPS.PAPER,
                    "C" => RPS.SCISSORS,
                    _ => throw new NotImplementedException()
                };

                var myMove = line[2..] switch {
                    "X" => RPS.ROCK,
                    "Y" => RPS.PAPER,
                    "Z" => RPS.SCISSORS,
                    _ => throw new NotImplementedException()
                };

                totalScore += RoundScore(myMove, opponentMove);
            });

            return totalScore.ToString();
        }

        protected override string PartTwo() {
            int totalScore = 0;
            InputReaderUtil.ProcessInput(inputFilePath, (line) => {
                var opponentMove = line[..1] switch {
                    "A" => RPS.ROCK,
                    "B" => RPS.PAPER,
                    "C" => RPS.SCISSORS,
                    _ => throw new NotImplementedException()
                };

                var myMove = line[2..] switch {
                    "X" => opponentMove switch {
                        RPS.ROCK => RPS.SCISSORS,
                        RPS.PAPER => RPS.ROCK,
                        RPS.SCISSORS => RPS.PAPER,
                        _ => throw new NotImplementedException(),
                    },
                    "Y" => opponentMove,
                    "Z" => opponentMove switch {
                        RPS.ROCK => RPS.PAPER,
                        RPS.PAPER => RPS.SCISSORS,
                        RPS.SCISSORS => RPS.ROCK,
                        _ => throw new NotImplementedException(),
                    },
                    _ => throw new NotImplementedException()
                };

                totalScore += RoundScore(myMove, opponentMove);
            });

            return totalScore.ToString();
        }

        private int RoundScore(RPS myMove, RPS opponentMove) {
            int moveScore = myMove switch {
                RPS.ROCK => 1,
                RPS.PAPER => 2,
                RPS.SCISSORS => 3,
                _ => throw new NotImplementedException(),
            };

            int resultScore = myMove switch {
                RPS.ROCK => opponentMove switch {
                    RPS.ROCK => 3,
                    RPS.PAPER => 0,
                    RPS.SCISSORS => 6,
                    _ => throw new NotImplementedException(),
                },
                RPS.PAPER => opponentMove switch {
                    RPS.ROCK => 6,
                    RPS.PAPER => 3,
                    RPS.SCISSORS => 0,
                    _ => throw new NotImplementedException(),
                },
                RPS.SCISSORS => opponentMove switch {
                    RPS.ROCK => 0,
                    RPS.PAPER => 6,
                    RPS.SCISSORS => 3,
                    _ => throw new NotImplementedException(),
                },
                _ => throw new NotImplementedException()
            };

            return moveScore + resultScore;
        }
    }
}
