using UnityEngine.UIElements;

namespace Paper
{
    public class BoxFactory : IFactory<Box>
    {
        public VisualElement Create(Box box)
        {
            var e = new VisualElement();

            Apply(e, box);

            return e;
        }

        public VisualElement Apply(VisualElement element, Box box)
        {
            var colorParser = new ColorParser();
            var styleLengthParser = new StyleLengthParser();

            element.style.backgroundColor = colorParser.Parse(box.backgroundColor);

            element.style.position =
                box.position == "absolute" ? Position.Absolute : Position.Relative;
            element.style.bottom = styleLengthParser.Parse(box.bottom);
            element.style.left = styleLengthParser.Parse(box.left);
            element.style.right = styleLengthParser.Parse(box.right);
            element.style.top = styleLengthParser.Parse(box.top);

            element.style.height = styleLengthParser.Parse(box.height);
            element.style.width = styleLengthParser.Parse(box.width);

            return element;
        }
    }
}
