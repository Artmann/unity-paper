# Unity Paper

A modern UI framework for Unity.

## Example

Create Views

```cs
using Paper;

public class BarView : View
{
    public string color;
    public string height;
    public float width;
    public float progress = 1f;

    public override Element Render()
    {
        var w = $"{width * progress}";

        return new Box(
            new Box()
            {
                background = "rgba(10, 10, 15, 0.75)",
                height = height,
                width = w,
                left = "4px",
                top = "4px"
            },
            new Box()
            {
                background = "project://database/Assets/gradient.png",
                backgroundColor = color,
                height = height,
                width = w
            }
        );
    }
}

```

```cs
using UnityEngine;
using Paper;

public class StatusView : View
{
    public float health;
    public float maxHealth;

    public override Element Render()
    {
        return new Box(
            new BarView()
            {
                color = "#15C120",
                height = "20px",
                width = 240,
                progress = Mathf.Clamp01(health / maxHealth)
            }
        )
        {
            position = "absolute",
            left = "40px",
            bottom = "40px"
        };
    }
}


```

Then render the views.

```cs
using UnityEngine;
using UnityEngine.UIElements;
using Paper;

public class PaperComponent : MonoBehaviour
{
    public float maxHealth = 100f;
    public float health = 100f;

    private UiRenderer uiRenderer = new();

    private void Start()
    {
        var document = GetComponent<UIDocument>();

        var container = document.rootVisualElement.Q("root");

        Debug.Log("container.name: " + container.name);

        uiRenderer.Render(container, new StatusView() { health = health, maxHealth = maxHealth });
    }
}

```
