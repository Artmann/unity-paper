using UnityEngine.UIElements;

namespace Paper
{
    public class TextFactory : ElementFactory<Text>
    {
        public VisualElement Create(Text text)
        {
            var e = new TextElement();

            Apply(e, text);

            return e;
        }

        public VisualElement Apply(TextElement element, Text text)
        {
            element = base.Apply(element, text) as TextElement;

            element.text = text.text;

            return element;
        }
    }
}
