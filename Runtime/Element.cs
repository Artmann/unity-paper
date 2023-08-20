namespace Paper
{
    public abstract class Element
    {
        public string background = "inherit";
        public string backgroundColor = "inherit";

        // Position
        public string position = "relative";
        public string bottom = "auto";
        public string left = "auto";
        public string right = "auto";
        public string top = "auto";

        // Sizing
        public string height = "auto";
        public string width = "auto";
        
        public Element[] children;

        public Element(params Element[] children)
        {
            this.children = children;
        }
    }
}