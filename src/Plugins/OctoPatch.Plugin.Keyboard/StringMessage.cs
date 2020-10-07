namespace OctoPatch.Plugin.Keyboard
{
    public struct StringMessage
    {
        public string Content { get; set; }

        public StringMessage(string content)
        {
            Content = content;
        }

        public override string ToString() => Content;
    }
}
