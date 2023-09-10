using UnityEngine.UIElements;

namespace Paper
{
    public class BoxFactory : ElementFactory<Box>
    {
        public VisualElement Create(Box box)
        {
            var e = new VisualElement();

            Apply(e, box);

            return e;
        }

        public VisualElement Apply(VisualElement element, Box box)
        {
            return base.Apply(element, box);
        }
    }
}
