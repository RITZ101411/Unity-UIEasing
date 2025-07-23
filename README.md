# Sample.cs

using UnityEngine;
```
public class Sample : MonoBehaviour
{
    private UIEasing easing;
    private UIEasing.EaseType  easeType;

    void Start()
    {
        easing = gameObject.AddComponent<UIEasing>();
        easeType = UIEasing.EaseType.EaseInCubic;
        easing.Play(new Vector2(0, 0), new Vector2(0, 10), 4f, easeType);
    }
}
```
