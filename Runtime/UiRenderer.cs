using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Paper;

namespace Paper
{
    public class UiRenderer : MonoBehaviour
    {
        public void Render(VisualElement container, Element element)
        {
            var unityElement = CreateUnityElementOrView(element);

            container.Clear();
            container.Add(unityElement);

            Debug.Log(unityElement);
        }

        private VisualElement CreateUnityElementOrView(Element element)
        {
            if (element is View view)
            {
                return CreateUnityElementOrView(view.Render());
            }

            var unityElement = CreateUnityElement(element);

            foreach (var child in element.children)
            {
                var unityChild = CreateUnityElementOrView(child);

                unityElement.Add(unityChild);
            }

            return unityElement;
        }

        private VisualElement CreateUnityElement(Element element)
        {
            if (element is Box box)
            {
                return new BoxFactory().Create(box);
            }

            throw new System.NotImplementedException(element.GetType().Name);
        }
    }
}
