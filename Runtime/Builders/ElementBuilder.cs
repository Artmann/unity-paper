namespace Paper
{
    public class BoxBuilder : ElementBuilder<Box>
    {
    }

    public class ElementBuilder<T> where T : Element
    {
        private readonly T element;

        public ElementBuilder<T> Position(string position)
        {
            element.position = position;
            return this;
        }

        public T Build()
        {
            return element;
        }
    }
}