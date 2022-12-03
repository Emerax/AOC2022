namespace AOCsharp2022 {
    public class InputReaderUtil {
        public static void ProcessInput(string inputFilePath, Action<string> lineProcessAction) {
            string[] lines = File.ReadAllLines($"D:\\AOC2022\\Inputs\\{inputFilePath}");
            foreach (string line in lines) {
                lineProcessAction(line);
            }
        }

        public static string[] RawLines(string inputFilePath) {
            return File.ReadAllLines($"D:\\AOC2022\\Inputs\\{inputFilePath}");
        }

        public static string RawText(string inputFilePath) {
            return File.ReadAllText($"D:\\AOC2022\\Inputs\\{inputFilePath}");
        }
    }
}
