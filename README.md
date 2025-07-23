# Sample.cs

```
using UnityEngine;

public class Sample : MonoBehaviour
{
    [SerializeField] private GameObject targetGameObject;
    
    void Start()
    {
        Vector2 startPos = new Vector2(0, 0);
        Vector2 endPos = new Vector2(0, 100);
        float time = 1.5f;
        bool loop = false;

        // イージング再生
        UIEasing.PlayEase(
            targetGameObject,
            startPos,
            endPos,
            time,
            UIEasing.EaseType.EaseInCubic,
            loop
        );
    }
}

```
