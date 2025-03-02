namespace AzureConfigCompare.Models
{
    public class CharacterDifference
    {
        public CharacterDifference(string text, bool isDifferent)
        {
            Text = text;
            IsDifferent = isDifferent;
        }

        public string Text { get; set; }
        public bool IsDifferent { get; set; }
    }
}
