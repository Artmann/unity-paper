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

        public Element Position(string position)
        {
            this.position = position;
            return this;
        }

        public Element Bottom(string bottom)
        {
            this.bottom = bottom;
            return this;
        }

        public Element Left(string left)
        {
            this.left = left;
            return this;
        }

        public Element Right(string right)
        {
            this.right = right;
            return this;
        }

        public Element Top(string top)
        {
            this.top = top;
            return this;
        }

        public Element Height(string height)
        {
            this.height = height;
            return this;
        }

        public Element Width(string width)
        {
            this.width = width;
            return this;
        }

        public Element Background(string background)
        {
            this.background = background;
            return this;
        }

        public Element BackgroundColor(string backgroundColor)
        {
            this.backgroundColor = backgroundColor;
            return this;
        }
    }
}