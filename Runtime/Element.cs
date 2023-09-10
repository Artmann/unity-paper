using System;

namespace Paper
{
    public abstract class Element : Renderable
    {
        public readonly string paperId = Guid.NewGuid().ToString();

        public string background = "transparent";
        public string backgroundColor = "transparent";

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

        public Element Bottom(string bottom)
        {
            this.bottom = bottom;
            return this;
        }

        public bool Equals(Element other)
        {
            if (other == null)
            {
                return false;
            }

            if (other.paperId != paperId)
            {
                return false;
            }

            return other.background.Equals(background)
                && other.backgroundColor.Equals(backgroundColor)
                && other.position.Equals(position)
                && other.bottom.Equals(bottom)
                && other.height.Equals(height)
                && other.left.Equals(left)
                && other.right.Equals(right)
                && other.top.Equals(top)
                && other.width.Equals(width)
                && other.children.Length == children.Length;
        }

        public Element Left(string left)
        {
            this.left = left;
            return this;
        }

        public Element Height(string height)
        {
            this.height = height;
            return this;
        }

        public Element Position(string position)
        {
            this.position = position;
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

        public override string ToString()
        {
            var str =
                $"<{GetType().Name} height=\"{height}\" width=\"{width}\" backgroundColor=\"{backgroundColor}\">\n";

            foreach (var child in children)
            {
                str += $"\t{child.ToString()}\n";
            }

            str += $"</{GetType().Name}>";

            return str;
        }

        public Element Width(string width)
        {
            this.width = width;
            return this;
        }
    }
}
