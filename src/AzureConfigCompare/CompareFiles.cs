using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AzureConfigCompare
{
    public class CompareFiles
    {
        public List<Difference> Differences { get; set; }

        public CompareFiles(string filePath1, string filePath2)
        {
            if (string.IsNullOrEmpty(filePath1) || string.IsNullOrEmpty(filePath2))
            {
                throw new ArgumentException("Both file paths must be provided");
            }
            Differences = CompareJsonFiles(filePath1, filePath2);
            foreach (Difference difference in Differences)
            {
                Console.WriteLine($"Line {difference.LineNumber}: {difference.Message}");
            }
        }

        public List<Difference> CompareJsonFiles(string filePath1, string filePath2)
        {
            List<Difference> differences = new ();

            string[] file1Lines = File.ReadAllLines(filePath1);
            string[] file2Lines = File.ReadAllLines(filePath2);

            JToken json1 = JToken.Parse(File.ReadAllText(filePath1));
            JToken json2 = JToken.Parse(File.ReadAllText(filePath2));

            CompareTokens(json1, json2, differences, file1Lines, file2Lines);

            return differences;
        }

        public static void CompareTokens(JToken token1, JToken token2, List<Difference> differences, string[] file1Lines, string[] file2Lines, string path = "")
        {
            if (!JToken.DeepEquals(token1, token2))
            {
                if (token1.Type != token2.Type)
                {
                    differences.Add(new Difference
                    {
                        LineNumber = GetLineNumber(token1, file1Lines),
                        Message = $"Type mismatch at {path}: {token1.Type} vs {token2.Type}"
                    });
                }
                else if (token1 is JValue value1 && token2 is JValue value2)
                {
                    differences.Add(new Difference
                    {
                        LineNumber = GetLineNumber(token1, file1Lines),
                        Message = $"Value mismatch at {path}: {value1} vs {value2}"
                    });
                }
                else if (token1 is JObject obj1 && token2 is JObject obj2)
                {
                    HashSet<string> allKeys = new(obj1.Properties().Select(p => p.Name));
                    allKeys.UnionWith(obj2.Properties().Select(p => p.Name));

                    foreach (string key in allKeys)
                    {
                        CompareTokens(obj1[key], obj2[key], differences, file1Lines, file2Lines, $"{path}/{key}");
                    }
                }
                else if (token1 is JArray array1 && token2 is JArray array2)
                {
                    for (int i = 0; i < Math.Max(array1.Count, array2.Count); i++)
                    {
                        CompareTokens(array1.ElementAtOrDefault(i), array2.ElementAtOrDefault(i), differences, file1Lines, file2Lines, $"{path}[{i}]");
                    }
                }
            }
        }

        public static int GetLineNumber(JToken token, string[] fileLines)
        {
            IJsonLineInfo lineInfo = (IJsonLineInfo)token;
            return lineInfo.HasLineInfo() ? lineInfo.LineNumber : -1;
        }
    }

    public class Difference
    {
        public int LineNumber { get; set; }
        public string Message { get; set; }
    }
}


