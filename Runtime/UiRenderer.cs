using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Paper;

namespace Paper
{
    public class UiRenderer
    {
        //private Element tree;

        private UpdateQueue updateQueue = UpdateQueue.Instance;

        private StatelessComponent rootComponent;
        private VisualElement rootUnityElement;
        private Element rootElement;

        private bool isMounted;

        public UiRenderer() { }

        public void Mount(VisualElement container, StatelessComponent component)
        {
            Debug.Log("--- Mount ---");

            rootComponent = component;
            rootUnityElement = container;

            TraverseAndRender(rootComponent, rootUnityElement);

            isMounted = true;
        }

        public void Tick()
        {
            if (!isMounted)
            {
                return;
            }
        }

        // public void Render(VisualElement container, Element element)
        // {
        //     var newTree = CreateTree(element);
        //     var changes = CreateListOfChanges(tree, newTree);

        //     ApplyChanges(container, changes);
        // }

        // private void ApplyChanges(VisualElement container, ChangeRequest[] changes)
        // {
        //     Debug.Log("ApplyChanges");

        //     foreach (var change in changes)
        //     {
        //         if (change.type == ChangeType.Add)
        //         {
        //             var unityElement = CreateUnityElement(change.element);

        //             if (change.parentId == null)
        //             {
        //                 container.Add(unityElement);
        //             }
        //             else
        //             {
        //                 var unityParent = FindUnityElement(container, change.parentId);

        //                 unityParent.Add(unityElement);
        //             }
        //         }

        //         if (change.type == ChangeType.Update)
        //         {
        //             var unityElement = FindUnityElement(container, change.elementId);

        //             if (unityElement == null)
        //             {
        //                 Debug.LogError("Could not find element with id " + change.elementId);
        //                 continue;
        //             }

        //             if (change.element is Box box)
        //             {
        //                 new BoxFactory().Apply(unityElement, box);
        //             }
        //         }
        //     }
        // }

        // private ChangeRequest[] CreateListOfChanges(Element oldTree, Element newTree)
        // {
        //     var changes = new List<ChangeRequest>();

        //     Debug.Log("CreateListOfChanges");
        //     TraverseTree(
        //         newTree,
        //         (element, parentId) =>
        //         {
        //             if (oldTree == null)
        //             {
        //                 changes.Add(
        //                     new ChangeRequest(element.paperId, ChangeType.Add, element, parentId)
        //                 );

        //                 return;
        //             }

        //             var oldElement = FindElement(oldTree, element.paperId);

        //             if (oldElement == null)
        //             {
        //                 changes.Add(
        //                     new ChangeRequest(element.paperId, ChangeType.Add, element, parentId)
        //                 );
        //             }
        //             else if (oldElement.Equals(element))
        //             {
        //                 changes.Add(
        //                     new ChangeRequest(element.paperId, ChangeType.Update, element, parentId)
        //                 );
        //             }
        //         }
        //     );

        //     return changes.ToArray();
        // }

        private Element CreateTree(Renderable elementOrComponent)
        {
            if (elementOrComponent is StatelessComponent component)
            {
                return CreateTree(component.Render());
            }

            if (elementOrComponent is Element element)
            {
                var childElements = new List<Element>();

                foreach (var child in element.children)
                {
                    childElements.Add(CreateTree(child));
                }

                element.children = childElements.ToArray();

                return element;
            }

            throw new System.NotImplementedException(elementOrComponent.GetType().Name);
        }

        private VisualElement CreateUnityElement(Element element)
        {
            if (element is Box box)
            {
                return new BoxFactory().Create(box);
            }

            if (element is Text text)
            {
                return new TextFactory().Create(text);
            }

            throw new System.NotImplementedException(element.GetType().Name);
        }

        private List<Element> ElementTreeToList(Element element)
        {
            var list = new List<Element>();

            TraverseTree(element, (element, parentId) => list.Add(element));

            return list;
        }

        private Element FindElement(Element element, string id)
        {
            if (element.paperId == id)
            {
                return element;
            }

            foreach (var child in element.children)
            {
                var foundElement = FindElement(child, id);

                if (foundElement != null)
                {
                    return foundElement;
                }
            }

            return null;
        }

        private VisualElement FindUnityElement(VisualElement element, string id)
        {
            if (element.name == id)
            {
                return element;
            }

            foreach (var child in element.Children())
            {
                var foundElement = FindUnityElement(child, id);

                if (foundElement != null)
                {
                    return foundElement;
                }
            }

            return null;
        }

        private void TraverseAndRender(Renderable renderable, VisualElement parentUnityElement)
        {
            Debug.Log("TraverseAndRender");

            if (renderable is StatelessComponent component)
            {
                Debug.Log("Render Component: " + component.GetType().Name);

                Renderable renderResult = component.Render();

                component.ComponentDidMount();

                if (renderResult != null)
                {
                    // Recursively traverse the tree if we get a Component.
                    TraverseAndRender(renderResult, parentUnityElement);
                }
            }
            else if (renderable is Element element)
            {
                Debug.Log("Render Element: " + element.GetType().Name);
                var unityElement = CreateUnityElement(element);

                unityElement.AddToClassList(element.GetType().Name);
                Debug.Log(unityElement.name);

                parentUnityElement.Add(unityElement);

                foreach (var child in element.children)
                {
                    if (child != null)
                    {
                        TraverseAndRender(child, unityElement);
                    }
                }
            }
        }

        private void TraverseTree(
            Element element,
            System.Action<Element, string> action,
            string parentId = null
        )
        {
            action(element, parentId);

            foreach (var child in element.children)
            {
                TraverseTree(child, action, element.paperId);
            }
        }

        // TODO: Remove
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
    }
}
