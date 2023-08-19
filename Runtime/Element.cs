namespace Paper
{
    public abstract class Element
    {
        public Element[] children;

        public Element(params Element[] children)
        {
            this.children = children;
        }
    }
}
