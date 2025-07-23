using UnityEngine;

public class TextEasing : MonoBehaviour
{
    public enum EaseType
    {
        Linear,
        EaseInQuad, EaseOutQuad, EaseInOutQuad,
        EaseInCubic, EaseOutCubic, EaseInOutCubic,
        EaseInQuart, EaseOutQuart, EaseInOutQuart,
        EaseInQuint, EaseOutQuint, EaseInOutQuint,
        EaseInSine, EaseOutSine, EaseInOutSine,
        EaseInExpo, EaseOutExpo, EaseInOutExpo,
        EaseInCirc, EaseOutCirc, EaseInOutCirc
    }

    [SerializeField] private RectTransform rectTransform;

    private Vector2 startPos;
    private Vector2 endPos;
    private float duration;
    private float timeElapsed;
    private EaseType easeType;
    private bool isPlaying = false;

    [SerializeField] private bool loop = false;

    void Start()
    {
        if (rectTransform == null)
            rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        if (!isPlaying || rectTransform == null)
            return;

        timeElapsed += Time.deltaTime;
        float t = Mathf.Clamp01(timeElapsed / duration);
        float easedT = ApplyEasing(t, easeType);
        rectTransform.anchoredPosition = Vector2.Lerp(startPos, endPos, easedT);

        if (t >= 1f)
        {
            if (loop)
            {
                Play(endPos, startPos, duration, easeType);
            }
            else
            {
                isPlaying = false;
            }
        }
    }

    public void Play(Vector2 start, Vector2 end, float time, EaseType ease)
    {
        this.startPos = start;
        this.endPos = end;
        this.duration = time;
        this.easeType = ease;
        this.timeElapsed = 0f;
        this.isPlaying = true;
        if (rectTransform != null)
            rectTransform.anchoredPosition = startPos;
    }

    float ApplyEasing(float t, EaseType type)
    {
        switch (type)
        {
            case EaseType.Linear: return t;
            case EaseType.EaseInQuad: return t * t;
            case EaseType.EaseOutQuad: return t * (2 - t);
            case EaseType.EaseInOutQuad: return t < 0.5f ? 2 * t * t : -1 + (4 - 2 * t) * t;
            case EaseType.EaseInCubic: return t * t * t;
            case EaseType.EaseOutCubic: return 1f - Mathf.Pow(1f - t, 3);
            case EaseType.EaseInOutCubic: return t < 0.5f ? 4 * t * t * t : 1 - Mathf.Pow(-2 * t + 2, 3) / 2;
            case EaseType.EaseInQuart: return t * t * t * t;
            case EaseType.EaseOutQuart: return 1 - Mathf.Pow(1 - t, 4);
            case EaseType.EaseInOutQuart: return t < 0.5f ? 8 * Mathf.Pow(t, 4) : 1 - Mathf.Pow(-2 * t + 2, 4) / 2;
            case EaseType.EaseInQuint: return t * t * t * t * t;
            case EaseType.EaseOutQuint: return 1 - Mathf.Pow(1 - t, 5);
            case EaseType.EaseInOutQuint: return t < 0.5f ? 16 * Mathf.Pow(t, 5) : 1 - Mathf.Pow(-2 * t + 2, 5) / 2;
            case EaseType.EaseInSine: return 1 - Mathf.Cos((t * Mathf.PI) / 2);
            case EaseType.EaseOutSine: return Mathf.Sin((t * Mathf.PI) / 2);
            case EaseType.EaseInOutSine: return -(Mathf.Cos(Mathf.PI * t) - 1) / 2;
            case EaseType.EaseInExpo: return t == 0 ? 0 : Mathf.Pow(2, 10 * (t - 1));
            case EaseType.EaseOutExpo: return t == 1 ? 1 : 1 - Mathf.Pow(2, -10 * t);
            case EaseType.EaseInOutExpo:
                if (t == 0) return 0;
                if (t == 1) return 1;
                return t < 0.5f
                    ? Mathf.Pow(2, 20 * t - 10) / 2
                    : (2 - Mathf.Pow(2, -20 * t + 10)) / 2;
            case EaseType.EaseInCirc: return 1 - Mathf.Sqrt(1 - Mathf.Pow(t, 2));
            case EaseType.EaseOutCirc: return Mathf.Sqrt(1 - Mathf.Pow(t - 1, 2));
            case EaseType.EaseInOutCirc:
                return t < 0.5f
                    ? (1 - Mathf.Sqrt(1 - Mathf.Pow(2 * t, 2))) / 2
                    : (Mathf.Sqrt(1 - Mathf.Pow(-2 * t + 2, 2)) + 1) / 2;
            default: return t;
        }
    }
}
