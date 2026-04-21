using System.Text;

namespace CcWc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string? flag = null;
            string? filePath = null;

            foreach (var arg in args)
            {
                if (arg.StartsWith('-'))
                    flag = arg;
                else
                    filePath = arg;
            }

            byte[] contents = ReadInput(filePath);

            if (flag == null)
            {
                int byteCount = CountBytes(contents);
                int lineCount = CountLines(contents);
                int wordCount = CountWords(contents);
                Console.WriteLine($"\t{byteCount}\t{lineCount}\t{wordCount} {filePath}");
                return;
            }

            switch (flag)
            {
                case "-c":
                    Console.WriteLine($"\t{CountBytes(contents)} {filePath}");
                    break;
                case "-l":
                    Console.WriteLine($"\t{CountLines(contents)} {filePath}");
                    break;
                case "-w":
                    Console.WriteLine($"\t{CountWords(contents)} {filePath}");
                    break;
                case "-m":
                    Console.WriteLine($"\t{CountChars(contents)} {filePath}");
                    break;
                default:
                    throw new Exception($"invalid flag {flag}");
            }
        }

        private static byte[] ReadInput(string? filePath)
        {
            if (filePath != null)
            {
                return File.ReadAllBytes(filePath);
            }
            string pipedText = Console.In.ReadToEnd();
            return Encoding.UTF8.GetBytes(pipedText);
        }

        private static int CountBytes(byte[] bytes)
        {
            return bytes.Length;
        }

        private static int CountLines(byte[] bytes)
        {
            return bytes.Count(b => b == 10);
        }

        private static int CountWords(byte[] bytes)
        {
            int words = 0;
            bool insideAWord = false;

            char[] chars = Encoding.UTF8.GetString(bytes).ToCharArray();

            foreach (char c in chars)
            {
                if (!char.IsWhiteSpace(c))
                {
                    insideAWord = true;
                }
                else
                {
                    if (insideAWord)
                    {
                        words++;
                    }
                    insideAWord = false;
                }
            }

            if (insideAWord)
            {
                words++;
            }
            return words;
        }

        private static int CountChars(byte[] bytes)
        {
            return Encoding.UTF8.GetString(bytes).ToCharArray().Length;
        }

        private static byte[] ReadFile(string filePath)
        {
            byte[] bytes = File.ReadAllBytes(filePath);
            return bytes;
        }
    }
}
