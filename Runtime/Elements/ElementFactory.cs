using UnityEngine.UIElements;

namespace Paper
{
    public class ElementFactory<T> : IFactory<Element>
    {
        public VisualElement Create(Element paperElement)
        {
            var e = new VisualElement();

            Apply(e, paperElement);

            return e;
        }

        public VisualElement Apply(VisualElement element, Element paperElement)
        {
            element.name = paperElement.paperId;

            var colorParser = new ColorParser();
            var styleLengthParser = new StyleLengthParser();

            element.style.backgroundColor = colorParser.Parse(paperElement.backgroundColor);

            element.style.position =
                paperElement.position == "absolute" ? Position.Absolute : Position.Relative;
            element.style.bottom = styleLengthParser.Parse(paperElement.bottom);
            element.style.left = styleLengthParser.Parse(paperElement.left);
            element.style.right = styleLengthParser.Parse(paperElement.right);
            element.style.top = styleLengthParser.Parse(paperElement.top);

            element.style.height = styleLengthParser.Parse(paperElement.height);
            element.style.width = styleLengthParser.Parse(paperElement.width);

            return element;
        }
    }
}
