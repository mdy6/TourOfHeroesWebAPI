namespace TourOfHeroesCore.Model
{
    public struct PaperContent
    {
        public string Value { get; private set; } = string.Empty;
        public PaperContent(string content)
        {
            Value = content;
        }
        public void SetContent(string value)
        {
            Value = value;
        }
    }
}