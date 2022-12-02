namespace AOCsharp2022 {
    public class InputReaderUtil {
        public static void ProcessInput(string inputFilePath, Action<string> lineProcessAction) {
            string[] lines = File.ReadAllLines($"D:\\AOC2022\\Inputs\\{inputFilePath}");
            foreach (string line in lines) {
                lineProcessAction(line);
            }
        }
    }
}
