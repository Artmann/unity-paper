using UnityEngine.UIElements;

namespace Paper
{
    public interface IFactory<T>
        where T : Element
    {
        VisualElement Create(T element);
        VisualElement Apply(VisualElement unityElement, T element);
    }
}
