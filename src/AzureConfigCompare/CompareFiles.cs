using AzureConfigCompare.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Drawing;

namespace AzureConfigCompare
{
    public class CompareFiles
    {
        public List<TextDifference> TextDifferences { get; set; }
        public List<CharacterDifference> CharacterDifferences { get; set; }

        public CompareFiles(string filePath1, string filePath2)
        {
            TextDifferences = new();
            CharacterDifferences = new();
            if (string.IsNullOrEmpty(filePath1) || string.IsNullOrEmpty(filePath2))
            {
                throw new ArgumentException("Both file paths must be provided");
            }
            string file1Contents = File.ReadAllText(filePath1);
            string file2Contents = File.ReadAllText(filePath2);
            CompareFileContents(file1Contents, file2Contents);
        }

        public void CompareFileContents(string fileContents1, string fileContents2)
        {
            TextDifferences = CompareJsonFiles(fileContents1, fileContents2);
            CharacterDifferences = GetCharacterDifferences(fileContents1, fileContents2);
        }

        public List<TextDifference> CompareJsonFiles(string fileContents1, string fileContents2)
        {
            List<TextDifference> differences = new();

            string[] file1Lines = fileContents1.Split(Environment.NewLine);
            string[] file2Lines = fileContents2.Split(Environment.NewLine);

            JToken json1 = JToken.Parse(fileContents1);
            JToken json2 = JToken.Parse(fileContents2);

            CompareTokens(json1, json2, differences, file1Lines, file2Lines);

            return differences;
        }

        public void CompareTokens(JToken token1, JToken token2, List<TextDifference> differences, string[] file1Lines, string[] file2Lines, string path = "")
        {
            if (!JToken.DeepEquals(token1, token2))
            {
                if (token1.Type != token2.Type)
                {
                    differences.Add(new TextDifference(
                        GetLineNumber(token1, file1Lines),
                        $"Type mismatch at {path}: {token1.Type} vs {token2.Type}"
                        ));
                }
                else if (token1 is JValue value1 && token2 is JValue value2)
                {
                    differences.Add(new TextDifference(
                        GetLineNumber(token1, file1Lines),
                        $"Value mismatch at {path}: {value1} vs {value2}"
                        ));
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

        public int GetLineNumber(JToken token, string[] fileLines)
        {
            IJsonLineInfo lineInfo = (IJsonLineInfo)token;
            return lineInfo.HasLineInfo() ? lineInfo.LineNumber : -1;
        }

        public List<CharacterDifference> GetCharacterDifferences(string original, string modified)
        {
            List<CharacterDifference> differences = new List<CharacterDifference>();

            int minLength = Math.Min(original.Length, modified.Length);
            for (int i = 0; i < minLength; i++)
            {
                if (original[i] != modified[i])
                {
                    differences.Add(new(modified[i].ToString(), true));
                }
                else
                {
                    differences.Add(new(modified[i].ToString(), false));
                }
            }

            if (original.Length > minLength)
            {
                differences.Add(new(original.Substring(minLength), true));
            }
            else if (modified.Length > minLength)
            {
                differences.Add(new(modified.Substring(minLength), true));
            }

            return differences;
        }
    }


}


